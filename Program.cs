namespace EstudoGeral;

using Transacao = (decimal Valor, System.DateTime Data, TipoTransacao Tipo);


internal class Program
{
    static void Main(string[] args)
    {
        ExpressionLambdas();

        Console.ReadKey();
    }

    private static void ExampleUsing()
    {
        List<Transacao> transacoes = new List<Transacao>()
        {
            (100.00M, DateTime.Now, TipoTransacao.Deposito),
            (50.00M, DateTime.Now.AddDays(-1), TipoTransacao.Saque),
            (200.00M, DateTime.Now.AddDays(-2), TipoTransacao.Transferencia),
            (75.00M, DateTime.Now.AddDays(-3), TipoTransacao.Deposito),
        };

        foreach(var transacao in transacoes)
        {
            Console.WriteLine($"Valor: {transacao.Valor:C}, Data: {transacao.Data}, Tipo: {transacao.Tipo}");
        }
    }

    private static void ExampleExpressionCollection()
    {
        //Versao anterior
        int[] exemplo_numeros_1 = new int[] { 1, 2, 3, 4, 5 };
        int[] exemplo_numeros_2 = { 1, 2, 3, 4, 5 };

        int[] pares_old = new int[] { 2, 4, 6, 8, 10 };
        int[] impares_old = { 1, 3, 5, 7, 9 };
        int[][] array_bi_dimensional = new int[][] {pares_old,  impares_old};

        //C# 12
        int[] numeros = [1, 2, 3, 4, 5];

        foreach (var n in numeros)
            Console.WriteLine(n);

        // Array bi-dimensional
        Console.WriteLine("Array bi-dimensional");
        int[] pares = [2, 4, 6, 8, 10];
        int[] impares = [1, 3, 5, 7, 9];
        int[][] numerosParesImpares = [pares, impares];

        foreach (var n in numerosParesImpares[0])
            Console.WriteLine(n);

        foreach (var n in numerosParesImpares[1])
            Console.WriteLine(n);

    }

    private static void ExampleSpan()
    {
        //C# < 12
        Span<string> regiao_sul_old = new string[] { "Parana", "Santa Catarina", "Rio Grande do Sul" };
        ReadOnlySpan<string> uf_sul_old = new string[] { "PR", "SC", "RS" };
        
        //C# 12
        Span<string> regiao_sul = ["Parana", "Santa Catarina", "Rio Grande do Sul"];
        ReadOnlySpan<string> uf_sul = ["PR", "SC", "RS" ];
    }

    private static void ExampleListCombination()
    {
        //C# < 12
        List<int> lista_numeros_1 = new List<int> { 1, 2, 3 };
        List<int> lista_numeros_2 = new List<int> { 4, 5, 6 };
        
        List<int> lista_combinada_old = new List<int>();

        lista_combinada_old.AddRange(lista_numeros_1);
        lista_combinada_old.AddRange(lista_numeros_1);

        foreach(int numeros in lista_combinada_old)
            Console.WriteLine(numeros);

        Console.WriteLine("Lista Combinada");

        //C# 12
        List<int> lista_1 = [ 1, 2, 3 ];
        List<int> lista_2 = [ 4, 5, 6 ];

        List<int> lista_combinada = [.. lista_1, .. lista_2];

        foreach (int numeros in lista_combinada)
            Console.WriteLine(numeros);

    }

    private static void ExpressionLambdas()
    {
        List<Produto> produtos = new List<Produto>
        { 
            new Produto("Produto A", 10.99M),
            new Produto("Produto B", 15.99M),
            new Produto("Produto C", 5.99M),
            new Produto("Produto D", 20.99M),
            new Produto("Produto E", 1.99M),
        };

        var filtrarProPrecoMinimo = (decimal precoMinimo = 0.0M) =>
        {
            return produtos.FindAll(produto => produto.Preco >= precoMinimo);
        };

        Console.WriteLine("Filtrar Por Preco maior que 10.00M");
        foreach (var produto in filtrarProPrecoMinimo(10.00M))
        {
            Console.WriteLine($"{produto.Nome} - Preço: {produto.Preco:C}");
        }

        Console.WriteLine("Sem Filtro");
        foreach (var produto in filtrarProPrecoMinimo())
        {
            Console.WriteLine($"{produto.Nome} - Preço: {produto.Preco:C}");
        }
    }
}

public enum TipoTransacao
{
    Deposito, Saque, Transferencia
}

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }
}