namespace Sandbox.Extensions;

public static class CryptHandler
{
    // Função para codificar (somar 127 aos caracteres)
    public static string Codificar(string input)
    {
        char[] resultado = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultado[i] = (char)(input[i] + 127);
        }
        return new string(resultado);
    }

    // Função para decodificar (subtrair 127 dos caracteres)
    public static string Decodificar(string input)
    {
        char[] resultado = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultado[i] = (char)(input[i] - 127);
        }
        return new string(resultado);
    }
}
