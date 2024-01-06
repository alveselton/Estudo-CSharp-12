namespace EstudoGeral;

internal class NewlinesInStringInterpolations
{
    static void Main(string[] args)
    {
        var nome = "CSharp 11";
        var saudacao = $"Bem-vindo {nome.ToLower()}";
        var erro = $"Bem-vindo {nome.ToLower()}";

        Console.ReadKey();
    }   
}
