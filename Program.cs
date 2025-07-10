using Sandbox.Dtos;
using Sandbox.Extensions;
using System.Text;

const string sourcePath = """C:\Users\Eris\Desktop\Pagamento Lote GareDr\""";

// Lista de arquivos para teste
// G9488077_unidesp.TXT
// G9399903.TXT
// Entrada.txt
// Saida.txt

var gare = ReadAndExtractGare(sourcePath + "Entrada.txt");

gare.Show();

WriteEncryptedGare(gare, sourcePath + "Saida.txt");

static GareDto ReadAndExtractGare(string path)
{
    var originalContent = File.ReadAllText(path, Encoding.Latin1);
    var decodedContent = CryptHandler.Decodificar(originalContent);

    return GareParser.ExtrairGareDr(decodedContent);
}

static void WriteEncryptedGare(GareDto gare, string path)
{
    var rebuiltContent = GareFactory.Montar(gare);
    var encryptedContent = CryptHandler.Codificar(rebuiltContent);

    File.WriteAllText(path, encryptedContent, Encoding.Latin1);
}
