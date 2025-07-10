namespace Sandbox.Dtos;

public class GareRegistroDetalhe2
{
    public required int TipoRegistro { get; set; } = 2; // 2 = Detalhe 2
    public required string TributoReceita { get; set; } // Tributo/Receita - Geralmente é "VIDE CAMPO 21 OBS."
    public required string Cae { get; set; }
    public required string Placa { get; set; }
    public required string Observacoes1 { get; set; }
    public required string Observacoes2 { get; set; }
    public required string Observacoes3 { get; set; }
    public required string Observacoes4 { get; set; }
    public required string Observacoes5 { get; set; }
    public required string Observacoes6 { get; set; }
    public required string Chassi { get; set; }
    public required string Filler { get; set; }
    public required int Sequencia { get; set; }
}
