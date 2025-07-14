namespace Sandbox.Dtos;

public class GareRegistroTrailler
{
    public required int TipoRegistro { get; set; } = 9; // 9
    public required int QuantidadeGuias { get; set; } // Quantidade total de guias sendo pagas (quantidade de Registros Detalhe 1)
    public required int QuantidadeRegistros { get; set; } // Quantidade total de Registros Detalhe (1 e 2)
    public required decimal ValorTotalPagar { get; set; } // Somatória dos campos “Valor Total” dos Registros Detalhe 1, quando campo “Tipo Serviço = P"
    public required decimal ValorTotalImprimir { get; set; } // Somatória dos campos “Valor Total” dos Registros Detalhe 1,quando campo “Tipo Serviço = I"
    public required decimal ValorTotal { get; set; } // Somatória de todos os campos "Valor Total" dos Registros Detalhe 1 (Serviços P + I)
    public required int QuantidadeGuiasPagar { get; set; } // Total de Guias “Tipo Serviço = P”
    public required int QuantidadeGuiasImprimir { get; set; } // Total de Guias “Tipo Serviço = I”
    public required string Filler { get; set; }
    public required int Sequencia { get; set; }
}
