namespace Sandbox.Dtos;

public class GareDto
{
	public GareRegistroHeader RegistroHeader { get; set; } = null!;
	public IEnumerable<GareRegistroDetalhe> RegistrosDetalhes { get; set; } = [];
	public GareRegistroTrailler RegistroTrailler { get; set; } = null!;

	public void Show()
	{
		Console.WriteLine("Header:");
		Console.WriteLine($"TipoRegistro: {RegistroHeader.TipoRegistro}");
		Console.WriteLine($"AgenciaDebito: {RegistroHeader.AgenciaDebito}");
		Console.WriteLine($"ContaDebito: {RegistroHeader.ContaDebito}");
		Console.WriteLine($"Cliente: {RegistroHeader.Cliente}");
		Console.WriteLine($"FoneContato: {RegistroHeader.FoneContato}");
		Console.WriteLine($"Filler: {RegistroHeader.Filler}");
		Console.WriteLine($"VersaoArquivo: {RegistroHeader.VersaoArquivo}");
		Console.WriteLine($"DataMovimento: {RegistroHeader.DataMovimento}");
		Console.WriteLine($"Sequencia: {RegistroHeader.Sequencia}");

		Console.WriteLine();
		Console.WriteLine("Detalhe 1:");
		foreach (var detalhe in RegistrosDetalhes)
		{
			Console.WriteLine($"TipoRegistro: {detalhe.RegistroDetalhe1.TipoRegistro}");
			Console.WriteLine($"TipoRecolhimento: {detalhe.RegistroDetalhe1.TipoRecolhimento}");
			Console.WriteLine($"CodigoReceita: {detalhe.RegistroDetalhe1.CodigoReceita}");
			Console.WriteLine($"Vencimento: {detalhe.RegistroDetalhe1.Vencimento}");
			Console.WriteLine($"Contribuinte: {detalhe.RegistroDetalhe1.Contribuinte}");
			Console.WriteLine($"CgcCpf: {detalhe.RegistroDetalhe1.CgcCpf}");
			Console.WriteLine($"Fone: {detalhe.RegistroDetalhe1.Fone}");
			Console.WriteLine($"Endereco: {detalhe.RegistroDetalhe1.Endereco}");
			Console.WriteLine($"MunicipioUf: {detalhe.RegistroDetalhe1.MunicipioUf}");
			Console.WriteLine($"Referencia2: {detalhe.RegistroDetalhe1.Referencia2}");
			Console.WriteLine($"Referencia3: {detalhe.RegistroDetalhe1.Referencia3}");
			Console.WriteLine($"ValorBase: {detalhe.RegistroDetalhe1.ValorBase}");
			Console.WriteLine($"Multa: {detalhe.RegistroDetalhe1.Multa}");
			Console.WriteLine($"Juros: {detalhe.RegistroDetalhe1.Juros}");
			Console.WriteLine($"Exercicio: {detalhe.RegistroDetalhe1.Exercicio}");
			Console.WriteLine($"OutrosValores1: {detalhe.RegistroDetalhe1.OutrosValores1}");
			Console.WriteLine($"ValorTotal: {detalhe.RegistroDetalhe1.ValorTotal}");
			Console.WriteLine($"Controle: {detalhe.RegistroDetalhe1.Controle}");
			Console.WriteLine($"Filler1: {detalhe.RegistroDetalhe1.Filler1}");
			Console.WriteLine($"TipoServico: {detalhe.RegistroDetalhe1.TipoServico}");
			Console.WriteLine($"CodigoServico: {detalhe.RegistroDetalhe1.CodigoServico}");
			Console.WriteLine($"Renavam: {detalhe.RegistroDetalhe1.Renavam}");
			Console.WriteLine($"Filler2: {detalhe.RegistroDetalhe1.Filler2}");
			Console.WriteLine($"Sequencia: {detalhe.RegistroDetalhe1.Sequencia}");
			Console.WriteLine();

			if (detalhe.RegistroDetalhe2 != null)
			{
				Console.WriteLine("Detalhe 2:");
				Console.WriteLine($"TipoRegistro: {detalhe.RegistroDetalhe2.TipoRegistro}");
				Console.WriteLine($"TributoReceita: {detalhe.RegistroDetalhe2.TributoReceita}");
				Console.WriteLine($"Cae: {detalhe.RegistroDetalhe2.Cae}");
				Console.WriteLine($"Placa: {detalhe.RegistroDetalhe2.Placa}");
				Console.WriteLine($"Observacoes1: {detalhe.RegistroDetalhe2.Observacoes1}");
				Console.WriteLine($"Observacoes2: {detalhe.RegistroDetalhe2.Observacoes2}");
				Console.WriteLine($"Observacoes3: {detalhe.RegistroDetalhe2.Observacoes3}");
				Console.WriteLine($"Observacoes4: {detalhe.RegistroDetalhe2.Observacoes4}");
				Console.WriteLine($"Observacoes5: {detalhe.RegistroDetalhe2.Observacoes5}");
				Console.WriteLine($"Observacoes6: {detalhe.RegistroDetalhe2.Observacoes6}");
				Console.WriteLine($"Chassi: {detalhe.RegistroDetalhe2.Chassi}");
				Console.WriteLine($"Filler: {detalhe.RegistroDetalhe2.Filler}");
				Console.WriteLine($"Sequencia: {detalhe.RegistroDetalhe2.Sequencia}");
				Console.WriteLine();
			}
		}

		Console.WriteLine();
		Console.WriteLine("Trailler:");
		Console.WriteLine($"TipoRegistro: {RegistroTrailler.TipoRegistro}");
		Console.WriteLine($"QuantidadeGuias: {RegistroTrailler.QuantidadeGuias}");
		Console.WriteLine($"QuantidadeRegistros: {RegistroTrailler.QuantidadeRegistros}");
		Console.WriteLine($"ValorTotalPagar: {RegistroTrailler.ValorTotalPagar}");
		Console.WriteLine($"ValorTotalImprimir: {RegistroTrailler.ValorTotalImprimir}");
		Console.WriteLine($"ValorTotal: {RegistroTrailler.ValorTotal}");
		Console.WriteLine($"QuantidadeGuiasPagar: {RegistroTrailler.QuantidadeGuiasPagar}");
		Console.WriteLine($"QuantidadeGuiasImprimir: {RegistroTrailler.QuantidadeGuiasImprimir}");
		Console.WriteLine($"Filler: {RegistroTrailler.Filler}");
		Console.WriteLine($"Sequencia: {RegistroTrailler.Sequencia}");
	}
}
