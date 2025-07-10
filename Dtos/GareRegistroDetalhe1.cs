using System.Diagnostics;

namespace Sandbox.Dtos;

public class GareRegistroDetalhe1
{
    public required int TipoRegistro { get; set; } = 1; // 1 = Detalhe 1
    public required string TipoRecolhimento { get; set; } // GARE/DR
    public required int CodigoReceita { get; set; } = 4005; // 4005
    public required string Vencimento { get; set; } // Ultimo dia util do mes?
    public required string Contribuinte { get; set; } // Nome do despachante
    public required string CgcCpf { get; set; } // CNPJ ou cpf do despachante
    public required string Fone { get; set; } // DDD e Telefone do despachante
    public required string Endereco { get; set; } // Logradouro do despachante
    public required string MunicipioUf { get; set; } // Municio/UF do despachante
    public required string Referencia2 { get; set; } // Alguns casos é o número da casa do despachante
    public required string Referencia3 { get; set; }
    public required decimal ValorBase { get; set; } // Valor original do recolhimento
    public required decimal Multa { get; set; }  // Valor da multa por mora
    public required decimal Juros { get; set; } // Valor dos Juros/Encargos por Mora,
    public required string Exercicio { get; set; } // "01"
    public required decimal OutrosValores1 { get; set; } 
    public required decimal ValorTotal { get; set; } // Valor efetivo do recolhimento (principal + encargos)
    public required string Controle { get; set; } // Codigo_Processo
    public required string Filler1 { get; set; } 
    public required string TipoServico { get; set; } // P = Imprimir e pagar (guias são impressas e autenticadas)
    public required string CodigoServico { get; set; } // 2 = Código de Serviço de GARE da SEFAZ
    public required string Renavam { get; set; } // Renavam do veículo
    public required string Filler2 { get; set; }
    public required int Sequencia { get; set; }
}
