//using Sandbox.Dtos;
//using Sandbox.Extensions;
//using System.Text;

//namespace Sandbox.Example.UseCases;

//public class GerarArquivoGareDrRendimentoUseCase(
//    IBancoRendimentoRepository bancoRendimentoRepository,
//    IClienteRepository clienteRepository
//    ) : IGerarArquivoGareDrRendimentoUseCase
//{
//    private readonly IBancoRendimentoRepository _bancoRendimentoRepository = bancoRendimentoRepository;
//    private readonly IClienteRepository _clienteRepository = clienteRepository;

//    public async Task<(byte[], string)> Executar(IEnumerable<int> rendimentoIds)
//    {
//        if (!rendimentoIds.Any()) return ([], string.Empty);

//        var (header, detalhes, trailler) = await MontarRegistros(rendimentoIds);

//        var gareDto = new GareDto
//        {
//            RegistroHeader = header,
//            RegistrosDetalhes = detalhes,
//            RegistroTrailler = trailler
//        };

//        var texto = GareHelper.Montar(gareDto);
//        var cripto = CryptographyHelper.CodificarCifraDeCesar(texto);

//        var rendimento = await _bancoRendimentoRepository.GetByConditionsWithInclude(
//            conditions: [r => r.Id == rendimentoIds.First()],
//            includes: [r => r.Cliente!]);

//        var cliente = rendimento.FirstOrDefault()?.Cliente;
//        if (cliente is null || cliente.SSP is null) return ([], string.Empty);

//        var numeroSequenciaGeracaoGareDr = await _clienteRepository.ObterProximoNumeroSequenciaGareDrAsync(cliente.Id);

//        var nomeArquivo = $"G{cliente.SSP}{$"{numeroSequenciaGeracaoGareDr}".PadLeft(2, '0')}";
//        return (Encoding.Latin1.GetBytes(cripto), nomeArquivo);
//    }

//    private async Task<(GareRegistroHeader, List<GareRegistroDetalhe>, GareRegistroTrailler)> MontarRegistros(IEnumerable<int> rendimentoIds)
//    {
//        GareRegistroHeader? header = null;
//        List<GareRegistroDetalhe> detalhes = [];
//        GareRegistroTrailler? trailler = null;

//        decimal valorTotal = decimal.Zero;
//        int sequencia = 1;

//        foreach (var id in rendimentoIds)
//        {
//            var rendimento = await _bancoRendimentoRepository.ObterDadosTemplateGareDr(id);
//            if (rendimento is null) break;

//            if (header is null)
//            {
//                header = CriarHeader(rendimento, ref sequencia);
//            }

//            valorTotal += rendimento.Valor ?? decimal.Zero;

//            var detalhe = CriarDetalhe(rendimento, ref sequencia);
//            detalhes.Add(detalhe);

//            if (trailler is null)
//            {
//                trailler = CriarTrailler(rendimentoIds.Count(), valorTotal, sequencia);
//            }
//        }

//        return (header!, detalhes, trailler!);
//    }

//    private GareRegistroHeader CriarHeader(dynamic rendimento, ref int sequencia) => new()
//    {
//        TipoRegistro = 0,
//        AgenciaDebito = rendimento.Cliente?.Recebimento?.Agencia ?? string.Empty,
//        ContaDebito = rendimento.Cliente?.Recebimento?.Conta ?? string.Empty,
//        Cliente = rendimento.Cliente?.RazaoSocial ?? string.Empty,
//        Filler = string.Empty,
//        FoneContato = rendimento.Cliente?.Telefone ?? string.Empty,
//        VersaoArquivo = "000003",
//        DataMovimento = rendimento.DataCriacao?.Date.ToString("ddMMyyyy") ?? DateTime.UtcNow.Date.ToString("ddMMyyyy"),
//        Sequencia = sequencia++
//    };

//    private GareRegistroDetalhe CriarDetalhe(dynamic rendimento, ref int sequencia)
//    {
//        var detalhe1 = new GareRegistroDetalhe1
//        {
//            TipoRegistro = 1,
//            TipoRecolhimento = "GARE/DR",
//            CodigoReceita = 4005,
//            Vencimento = rendimento.DataVencimento?.ToString("ddMMyyyy") ?? string.Empty,
//            Contribuinte = rendimento.Processo?.Proprietario?.Nome ?? string.Empty,
//            CgcCpf = rendimento.Processo?.Proprietario?.Documento ?? string.Empty,
//            Fone = rendimento.Processo?.Proprietario?.Telefone ?? string.Empty,
//            Endereco = $"{rendimento.Processo?.Proprietario?.Endereco}, {rendimento.Processo?.Proprietario?.Numero}",
//            MunicipioUf = $"{rendimento.Processo?.Proprietario?.Municipio?.Descricao}/{rendimento.Processo?.Proprietario?.Municipio?.Uf}",
//            Referencia2 = string.Empty,
//            Referencia3 = string.Empty,
//            ValorBase = rendimento.Valor ?? decimal.Zero,
//            Multa = decimal.Zero,
//            Juros = decimal.Zero,
//            Exercicio = "01",
//            OutrosValores1 = decimal.Zero,
//            ValorTotal = rendimento.Valor ?? decimal.Zero,
//            Controle = rendimento.Processo?.CodigoProcesso!,
//            Filler1 = string.Empty,
//            TipoServico = "P",
//            CodigoServico = "2",
//            Renavam = rendimento.Processo?.Veiculo?.Renavam ?? string.Empty,
//            Filler2 = string.Empty,
//            Sequencia = sequencia++
//        };

//        var detalhe2 = new GareRegistroDetalhe2
//        {
//            TipoRegistro = 2,
//            TributoReceita = "VIDE CAMPO 21 OBS.",
//            Cae = string.Empty,
//            Placa = rendimento.Placa ?? string.Empty,
//            Observacoes1 = string.Empty,
//            Observacoes2 = string.Empty,
//            Observacoes3 = string.Empty,
//            Observacoes4 = string.Empty,
//            Observacoes5 = string.Empty,
//            Observacoes6 = string.Empty,
//            Chassi = rendimento.Processo?.Veiculo?.Chassi ?? string.Empty,
//            Filler = string.Empty,
//            Sequencia = sequencia++
//        };

//        return new GareRegistroDetalhe
//        {
//            RegistroDetalhe1 = detalhe1,
//            RegistroDetalhe2 = detalhe2
//        };
//    }

//    private GareRegistroTrailler CriarTrailler(int quantidadeGuias, decimal valorTotal, int sequencia) => new()
//    {
//        TipoRegistro = 9,
//        QuantidadeGuias = quantidadeGuias,
//        QuantidadeRegistros = quantidadeGuias * 2,
//        ValorTotalPagar = valorTotal,
//        ValorTotalImprimir = decimal.Zero,
//        ValorTotal = valorTotal,
//        QuantidadeGuiasPagar = quantidadeGuias,
//        QuantidadeGuiasImprimir = 0,
//        Filler = string.Empty,
//        Sequencia = sequencia
//    };
//}
