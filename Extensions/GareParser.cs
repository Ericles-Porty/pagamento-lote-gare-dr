using Sandbox.Dtos;
using System.Globalization;

namespace Sandbox.Extensions;

public static class GareParser
{
    public static GareRegistroHeader ExtrairRegistroHeader(string texto)
    {
        return new GareRegistroHeader
        {
            TipoRegistro = int.Parse(texto.Substring(0, 1).Limpar()),
            AgenciaDebito = texto.Substring(1, 4).Limpar(),
            ContaDebito = texto.Substring(5, 8).Limpar(),
            Cliente = texto.Substring(13, 35).Limpar(),
            FoneContato = texto.Substring(48, 15).Limpar(),
            Filler = texto.Substring(63, 318).Limpar(),
            VersaoArquivo = texto.Substring(381, 6).Limpar(),
            DataMovimento = FormatarData(texto.Substring(387, 8)).Limpar(),
            Sequencia = int.TryParse(texto.Substring(395, 5).Limpar(), out var valor) ? valor : 0
        };
    }

    public static GareRegistroDetalhe1 ExtrairRegistroDetalhe1(string texto)
    {
        return new GareRegistroDetalhe1
        {
            TipoRegistro = int.Parse(texto.Substring(0, 1).Limpar()),
            TipoRecolhimento = texto.Substring(1, 10).Limpar(),
            CodigoReceita = int.Parse(texto.Substring(11, 4).Limpar()),
            Vencimento = FormatarData(texto.Substring(15, 8).Limpar()),
            Contribuinte = texto.Substring(23, 45).Limpar(),
            CgcCpf = FormatarCpfCnpj(texto.Substring(68, 15).Limpar()),
            Fone = texto.Substring(83, 15).Limpar(),
            Endereco = texto.Substring(98, 45).Limpar(),
            MunicipioUf = texto.Substring(143, 25).Limpar(),
            Referencia2 = texto.Substring(187, 10).Limpar(),
            Referencia3 = texto.Substring(197, 10).Limpar(),
            ValorBase = ParseDecimal(texto.Substring(207, 15).Limpar()),
            Multa = ParseDecimal(texto.Substring(222, 15).Limpar()),
            Juros = ParseDecimal(texto.Substring(237, 15).Limpar()),
            Exercicio = texto.Substring(252, 10).Limpar(),
            OutrosValores1 = ParseDecimal(texto.Substring(262, 15).Limpar()),
            ValorTotal = ParseDecimal(texto.Substring(307, 15).Limpar()),
            Controle = texto.Substring(322, 15).Limpar(),
            Filler1 = texto.Substring(337, 1).Limpar(),
            TipoServico = texto.Substring(338, 1).Limpar(),
            CodigoServico = texto.Substring(339, 3).Limpar(),
            Renavam = texto.Substring(342, 11).Limpar(),
            Filler2 = texto.Substring(351, 42).Limpar(),
            Sequencia = int.TryParse(texto.Substring(395, 5).Limpar(), out var valor) ? valor : 0
        };
    }

    public static GareRegistroDetalhe2 ExtrairRegistroDetalhe2(string texto)
    {
        return new GareRegistroDetalhe2
        {
            TipoRegistro = int.Parse(texto.Substring(0, 1).Limpar()),
            TributoReceita = texto.Substring(1, 18).Limpar(),
            Cae = texto.Substring(19, 15).Limpar(),
            Placa = texto.Substring(34, 8).Limpar(),
            Observacoes1 = texto.Substring(42, 50).Limpar(),
            Observacoes2 = texto.Substring(92, 50).Limpar(),
            Observacoes3 = texto.Substring(142, 50).Limpar(),
            Observacoes4 = texto.Substring(192, 50).Limpar(),
            Observacoes5 = texto.Substring(242, 50).Limpar(),
            Observacoes6 = texto.Substring(292, 50).Limpar(),
            Chassi = texto.Substring(342, 20).Limpar(),
            Filler = texto.Substring(262, 33).Limpar(),
            Sequencia = int.TryParse(texto.Substring(395, 5).Limpar(), out var valor) ? valor : 0
        };
    }

    public static GareRegistroTrailler ExtrairRegistroTrailler(string texto)
    {
        return new GareRegistroTrailler
        {
            TipoRegistro = int.Parse(texto.Substring(0, 1)),
            QuantidadeGuias = int.Parse(texto.Substring(1, 6).Limpar()),
            QuantidadeRegistros = int.Parse(texto.Substring(7, 6).Limpar()),
            ValorTotalPagar = ParseDecimal(texto.Substring(13, 15).Limpar()),
            ValorTotalImprimir = ParseDecimal(texto.Substring(28, 15).Limpar()),
            ValorTotal = ParseDecimal(texto.Substring(43, 15).Limpar()),
            QuantidadeGuiasPagar = int.Parse(texto.Substring(58, 6).Limpar()),
            QuantidadeGuiasImprimir = int.Parse(texto.Substring(64, 6).Limpar()),
            Filler = texto.Substring(28, 325).Limpar(),
            Sequencia = int.Parse(texto.Substring(395, 5).Limpar())
        };

    }

    public static GareDto ExtrairGareDr(string texto)
    {
        int tamanhoRegistro = 402; // 2 chars são da quebra de linha

        GareRegistroHeader? registroHeader = null;
        List<GareRegistroDetalhe> registrosDetalhes = [];
        GareRegistroTrailler? registroTrailler = null;

        for (int i = 0; i <= texto.Length - tamanhoRegistro; i += tamanhoRegistro)
        {
            string linha = texto.Substring(i, tamanhoRegistro);

            // Header
            if (linha.StartsWith("0"))
            {
                registroHeader = ExtrairRegistroHeader(linha);
            }
            // Detalhes
            else if (linha.StartsWith("1") && linha.Substring(1, 10).StartsWith("GARE/DR"))
            {
                GareRegistroDetalhe1 registroDetalhe1 = ExtrairRegistroDetalhe1(linha);
                var proximaLinha = i + tamanhoRegistro < texto.Length ? texto.Substring(i + tamanhoRegistro, tamanhoRegistro) : null;
                if (proximaLinha == null)
                    throw new ArgumentException("Ausência de linha após o registro 1.");

                GareRegistroDetalhe2? registroDetalhe2 = null;
                if (proximaLinha.StartsWith("2"))
                {
                    registroDetalhe2 = ExtrairRegistroDetalhe2(proximaLinha);
                    i += tamanhoRegistro;
                }
                registrosDetalhes.Add(new GareRegistroDetalhe
                {
                    RegistroDetalhe1 = registroDetalhe1,
                    RegistroDetalhe2 = registroDetalhe2
                });

            }
            // Trailler
            else if (linha.StartsWith("9"))
            {
                registroTrailler = ExtrairRegistroTrailler(linha);
            }


        }

        GareDto gareDto = new GareDto
        {
            RegistroHeader = registroHeader!,
            RegistrosDetalhes = registrosDetalhes,
            RegistroTrailler = registroTrailler!
        };

        return gareDto;
    }

    private static string FormatarData(string data)
    {
        if (DateTime.TryParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            return dt.ToString("dd/MM/yyyy");
        return data;
    }

    private static string FormatarCpfCnpj(string texto)
    {

        if (texto.Length == 11 && ulong.TryParse(texto, out var cpf))
            return cpf.ToString(@"000\.000\.000\-00");

        if (texto.Length == 14 && ulong.TryParse(texto, out var cnpj))
            return cnpj.ToString(@"00\.000\.000\/0000\-00");

        return texto;
    }

    private static decimal ParseDecimal(string valor)
    {
        if (decimal.TryParse(valor, out var result))
            return result / 100;
        return 0;
    }


    private static int ParseInt(string valor)
    {
        if (int.TryParse(valor, out var result))
            return result;
        return 0;
    }


    private static string Limpar(this string linha)
    {
        return linha.Replace(((char)127).ToString(), " ").Trim();
    }

}
