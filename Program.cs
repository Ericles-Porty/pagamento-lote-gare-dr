using Sandbox.Dtos;
using Sandbox.Extensions;
using System.Text;

const string sourcePath = @"C:\Users\Eris\Desktop\";
//const string sourcePath = """C:\Users\Eris\Desktop\Pagamento Lote GareDr\""";

// Lista de arquivos para teste
// G9488077_unidesp.TXT
// G9399903.TXT
// Entrada.txt
// Saida.txt

/// Padrão do nome do arquivo: 
/// GSSSSSNN.TXT onde:
/// G – Identificação do tipo de arquivo de pagamento (G = GARE)
/// S – Número do SSP do despachante. Sempre com 5 posições
/// N – Número sequencial para evitar duplicidade (1)

var gare = ReadAndExtractGare(sourcePath + "G9867701.txt");

gare.Show();

WriteEncryptedGare(gare, sourcePath + "Saida.txt");

static GareDto ReadAndExtractGare(string path)
{
    var originalContent = File.ReadAllText(path, Encoding.Latin1);
    var decodedContent = CryptHandler.DecodificarCifraDeCesar(originalContent);

    return GareParser.ExtrairGareDr(decodedContent);
}

static void WriteEncryptedGare(GareDto gare, string path)
{
    var rebuiltContent = GareFactory.Montar(gare);
    var encryptedContent = CryptHandler.CodificarCifraDeCesar(rebuiltContent);

    File.WriteAllText(path, encryptedContent, Encoding.Latin1);
}
