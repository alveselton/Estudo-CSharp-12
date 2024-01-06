using System.Diagnostics.CodeAnalysis;

namespace EstudoGeral;

internal class RequiredMembers
{
    static void Main(string[] args)
    {
        // *******************
        //Gera erro por que precisa do Required        
        // *******************

        /*PessoaFisica maria = new PessoaFisica();

        PessoaFisica manoel = new PessoaFisica()
        {
            Nome = "Manoel"
        };*/

        PessoaFisica ana = new PessoaFisica("Ana", 22);

        Triangulo triangulo = new Triangulo();
        triangulo.Base = 10;
        triangulo.Altura = 5;
        triangulo.GetArea();

        Console.ReadKey();
    }
}

public class PessoaFisica
{
    public required string? Nome { get; set; }
    
    private string? _sobrenome;
    public string? Sobrenome
    {
        get => _sobrenome;
        set => _sobrenome = value ?? throw new ArgumentNullException(nameof(value),
            $"{nameof(Sobrenome)} Nao pode ser null");
    }

    public int Idade { get; set; }

    public PessoaFisica()
    { }

    [SetsRequiredMembers]
    public PessoaFisica(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public string GetCpf()
    {
        var identidade = new PessoaIdentidade();
        return identidade.GetCPF;
    }
}

//Escopo de visibilidade somente no arquivo que foi declarado
file class PessoaIdentidade
{
    public string GetCPF => "12345678900";
}

public struct Triangulo
{
    public Triangulo()
    {
    }

    public int Base { get; set; }
    public int Altura { get; set; }
    public string? Titulo { get; set; }

    public void GetArea()
    {
        Console.WriteLine("Área: " + (Base * Altura) / 2);
    }
}