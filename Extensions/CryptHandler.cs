namespace Sandbox.Extensions;

public static class CryptHandler
{
    /// <summary>
    /// Função para codificar uma string usando a cifra de César (adicionando 127 aos caracteres)
    /// </summary>
    /// <param name="input"> A string a ser codificada</param>
    /// <returns> A string codificada</returns>
    public static string CodificarCifraDeCesar(string input)
    {
        char[] resultado = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultado[i] = (char)(input[i] + 127);
        }
        return new string(resultado);
    }

    /// <summary>
    /// Função para decodificar uma string usando a cifra de César (subtraindo 127 dos caracteres)
    /// </summary>
    /// <param name="input"> A string a ser decodificada</param>
    /// <returns> A string decodificada</returns>
    public static string DecodificarCifraDeCesar(string input)
    {
        char[] resultado = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            resultado[i] = (char)(input[i] - 127);
        }
        return new string(resultado);
    }
}
