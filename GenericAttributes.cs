namespace GenericAttributes;

internal class GenericAttributes
{
    static void Main(string[] args)
    {
        Console.ReadKey();
    }
}

public class Pessoa
{
    public string? Nome { get; set; }

    [MeuAtributo(typeof(string))] // Antes do C#11
    public string MeuMetodo() => default;

    [AtributoGenerico<string>] // Apos o C#11
    public string MeuMetodoDois() => default;
}

public class AtributoGenerico<T> : Attribute
{

}

public class MeuAtributo : Attribute
{
    public MeuAtributo(Type t) => ParamType = t;

    public Type ParamType { get; }
}