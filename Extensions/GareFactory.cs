using Sandbox.Dtos;
using System.Globalization;
using System.Text;

namespace Sandbox.Extensions;

public static class GareFactory
{
    /// <summary>
    /// Monta o texto da GARE-DR a partir do DTO fornecido.
    /// O formato do texto segue o padrão definido no template 
    /// do layout de pagamento de guias em LOTE fornecido pelo Banco Rendimento.
    /// </summary>
    /// <param name="gareDto"></param>
    /// <returns></returns>
    public static string Montar(GareDto gareDto)
    {
        StringBuilder texto = new StringBuilder();
        // Header
        texto.Append($"{gareDto.RegistroHeader.TipoRegistro.PreencherNumero(1)}");
        texto.Append($"{gareDto.RegistroHeader.AgenciaDebito.PreencherNumero(4)}");
        texto.Append($"{gareDto.RegistroHeader.ContaDebito.PreencherNumero(8)}");
        texto.Append($"{gareDto.RegistroHeader.Cliente.PreencherAlpha(35)}");
        texto.Append($"{gareDto.RegistroHeader.FoneContato.PreencherAlpha(15)}");
        texto.Append($"{gareDto.RegistroHeader.Filler.PreencherAlpha(318)}");
        texto.Append($"{gareDto.RegistroHeader.VersaoArquivo.PreencherAlpha(6)}");
        texto.Append($"{gareDto.RegistroHeader.DataMovimento.MontarData().PreencherAlpha(8)}");
        texto.Append($"{gareDto.RegistroHeader.Sequencia.PreencherNumero(5)}");
        // Quebra de linha
        texto.AppendLine();

        // Detalhe 1
        foreach (var detalhe in gareDto.RegistrosDetalhes)
        {
            texto.Append($"{detalhe.RegistroDetalhe1.TipoRegistro.PreencherNumero(1)}");
            texto.Append($"{detalhe.RegistroDetalhe1.TipoRecolhimento.PreencherAlpha(10)}");
            texto.Append($"{detalhe.RegistroDetalhe1.CodigoReceita.PreencherNumero(4)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Vencimento.MontarData().PreencherNumero(8)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Contribuinte.PreencherAlpha(45)}");
            texto.Append($"{detalhe.RegistroDetalhe1.CgcCpf.MontarCnpj().PreencherAlpha(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Fone.PreencherAlpha(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Endereco.PreencherAlpha(45)}");
            texto.Append($"{detalhe.RegistroDetalhe1.MunicipioUf.PreencherAlpha(25)}");
            texto.Append($"{"".PreencherNumero(8)}"); // CEP
            texto.Append($"{"".PreencherAlpha(11)}"); // Referencia1
            texto.Append($"{detalhe.RegistroDetalhe1.Referencia2.PreencherAlpha(10)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Referencia3.PreencherAlpha(10)}");
            texto.Append($"{detalhe.RegistroDetalhe1.ValorBase.MontarDecimal().PreencherNumero(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Multa.MontarDecimal().PreencherNumero(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Juros.MontarDecimal().PreencherNumero(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Exercicio.PreencherAlpha(10)}");
            texto.Append($"{detalhe.RegistroDetalhe1.OutrosValores1.MontarDecimal().PreencherNumero(15)}");
            texto.Append($"{"".PreencherNumero(15)}"); // OutrosValores2
            texto.Append($"{"".PreencherNumero(15)}"); // OutrosValores3
            texto.Append($"{detalhe.RegistroDetalhe1.ValorTotal.MontarDecimal().PreencherNumero(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Controle.PreencherAlpha(15)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Filler1.PreencherAlpha(1)}");
            texto.Append($"{detalhe.RegistroDetalhe1.TipoServico.PreencherAlpha(1)}");
            texto.Append($"{detalhe.RegistroDetalhe1.CodigoServico.PreencherAlpha(3)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Renavam.PreencherNumero(11)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Filler2.PreencherAlpha(42)}");
            texto.Append($"{detalhe.RegistroDetalhe1.Sequencia.PreencherNumero(5)}");
            texto.AppendLine();

            // Detalhe 2
            if (detalhe.RegistroDetalhe2 != null)
            {
                texto.Append($"{detalhe.RegistroDetalhe2.TipoRegistro.PreencherNumero(1)}");
                texto.Append($"{detalhe.RegistroDetalhe2.TributoReceita.PreencherAlpha(18)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Cae.PreencherAlpha(15)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Placa.PreencherAlpha(8)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes1.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes2.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes3.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes4.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes5.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Observacoes6.PreencherAlpha(50)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Chassi.PreencherAlpha(20)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Filler.PreencherAlpha(33)}");
                texto.Append($"{detalhe.RegistroDetalhe2.Sequencia.PreencherNumero(5)}");
                texto.AppendLine();
            }
        }

        // Trailer
        texto.Append($"{gareDto.RegistroTrailler.TipoRegistro.PreencherNumero(1)}");
        texto.Append($"{gareDto.RegistroTrailler.QuantidadeGuias.PreencherNumero(6)}");
        texto.Append($"{gareDto.RegistroTrailler.QuantidadeRegistros.PreencherNumero(6)}");
        texto.Append($"{gareDto.RegistroTrailler.ValorTotalPagar.MontarDecimal().PreencherNumero(15)}");
        texto.Append($"{gareDto.RegistroTrailler.ValorTotalImprimir.MontarDecimal().PreencherNumero(15)}");
        texto.Append($"{gareDto.RegistroTrailler.ValorTotal.MontarDecimal().PreencherNumero(15)}");
        texto.Append($"{gareDto.RegistroTrailler.QuantidadeGuiasPagar.PreencherNumero(6)}");
        texto.Append($"{gareDto.RegistroTrailler.QuantidadeGuiasImprimir.PreencherNumero(6)}");
        texto.Append($"{gareDto.RegistroTrailler.Filler.PreencherAlpha(325)}");
        texto.Append($"{gareDto.RegistroTrailler.Sequencia.PreencherNumero(5)}");
        texto.AppendLine();

        return texto.ToString();
    }

    private static string PreencherAlpha(this string linha, int tamanho)
    {
        return linha.PadRight(tamanho, ' ');
    }

    private static string PreencherNumero(this string linha, int tamanho)
    {
        return linha.PadLeft(tamanho, '0');
    }

    private static string PreencherNumero(this int linha, int tamanho)
    {
        return linha.ToString().PadLeft(tamanho, '0');
    }

    private static string MontarDecimal(this decimal valor)
    {
        return (valor * 100).ToString("F0", CultureInfo.InvariantCulture).PadLeft(15, '0');
    }

    private static string MontarCnpj(this string cnpj)
    {
        return cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
    }

    private static string MontarData(this string data)
    {
        if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
            return dt.ToString("ddMMyyyy");
        return data;
    }
}
