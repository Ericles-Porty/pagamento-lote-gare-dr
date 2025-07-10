namespace Sandbox.Dtos;

public class GareRegistroHeader
{
    public required int TipoRegistro { get; set; } = 0; // 0 = Header
    public required string AgenciaDebito { get; set; }
    public required string ContaDebito { get; set; } // Sem digito verificador?
    public required string Cliente { get; set; } // Nome do Titular da conta (Despachante ou Jotatei)?
    public required string Filler { get; set; }
    public required string FoneContato { get; set; } // Telefone de contato do cliente 
    public required string VersaoArquivo { get; set; } // 000003
    public required string DataMovimento { get; set; } // Data do movimento contábil a que se referem as guias (data da autenticação). Now()
    public required int Sequencia { get; set; }
}
