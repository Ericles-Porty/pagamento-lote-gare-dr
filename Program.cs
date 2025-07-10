using Sandbox.Dtos;
using Sandbox.Extensions;
using System.Text;

var original = File.ReadAllText("C:\\Users\\Eris\\Desktop\\Saida.txt", encoding: Encoding.Latin1);
//var original = File.ReadAllText("C:\\Users\\Eris\\Desktop\\G9488077_unidesp.TXT", encoding: Encoding.Latin1);

//Console.WriteLine("Original: " + original);

//string codificada = CryptHandler.Codificar(original);
//Console.WriteLine("Codificada: " + codificada);

string decodificada = CryptHandler.Decodificar(original);
//Console.WriteLine("Decodificada: " + decodificada);

//File.WriteAllText("C:\\Users\\Eris\\Downloads\\decodificado4.txt", decodificada, Encoding.ASCII);

//string caminho = "C:\\Users\\Eris\\Downloads\\decodificado.txt";
//var linhas = File.ReadAllLines(caminho, Encoding.Latin1);

//var texto = string.Join("", linhas);

var gare = GareParser.ExtrairGareDr(decodificada);
gare.Show();

var texto = GareFactory.Montar(gare);
var textoCriptografado = CryptHandler.Codificar(texto);
string desktop = "C:\\Users\\Eris\\Desktop\\Saida.txt";
File.WriteAllText(desktop, textoCriptografado, Encoding.Latin1);
//File.WriteAllText(desktop, texto, Encoding.Latin1);

static GareDto ReadAndExtractGare(string path)
{
    var originalContent = File.ReadAllText(path, Encoding.Latin1);
    var decodedContent = CryptHandler.Decodificar(originalContent);

    return GareParser.ExtrairGareDr(decodedContent);
}

// Recebe o objeto GARE/DR, reconstrói o layout, criptografa e salva no disco
static void WriteEncryptedGare(GareDto gare, string path)
{
    var rebuiltContent = GareFactory.Montar(gare);
    var encryptedContent = CryptHandler.Codificar(rebuiltContent);

    File.WriteAllText(path, encryptedContent, Encoding.Latin1);
}
