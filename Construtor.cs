namespace EstudoGeral;

internal class Construtor
{
    static void Main(string[] args)
    {
        var aluno1 = new Aluno("Maria", "Silveira", 9);
        var aluno2 = new AlunoNew("Maria", "Silveira", 9, 20);

        var aluno3 = new AlunoNew();

        Console.WriteLine($"{aluno1.NomeCompleto} Nota: {aluno1.Nota} \n\n");
        Console.WriteLine($"{aluno2.NomeCompleto} Nota: {aluno2.Nota} \n\n");
        Console.ReadKey();
    }
}

//C# < 12
public class Aluno
{
    public string Nome { get; set; }
    public string Sobrenome { get; set;}
    public int Nota { get; set;}

    public string NomeCompleto => $"{Nome} {Sobrenome}";

    public Aluno(string nome, string sobrenome, int nota)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Nota = nota;
    }
}

//C# 12
public class AlunoNew(string nome, string sobrenome, int nota, int idade)
{
    public AlunoNew() : this("Marta", "Bueno", 8, 10) { }
    
    //Era restrito aos Records
    public AlunoNew(int nota) : this("Carlos", "Santos", 8, 15) { }
    public string Nome { get; init; } = nome;
    public string Sobrenome { get; set; } = sobrenome.ToLower();
    public int Nota { get; set; } = nota;

    public string NomeCompleto => $"{Nome} {Sobrenome} {idade}";

}

public record Pessoa(string Nome, string Sobrenome, int Idade)
{
    public Pessoa() : this("Maria", "Silva", 31) { }
}