
abstract class Symbol
{
    protected char code;
    protected string font;

    public Symbol(char code, string font)
    {
        this.code = code;
        this.font = font;
    }
    public abstract void Display(int x, int y, string color, int size);
}
class ConcreteSymbol : Symbol
{
    public ConcreteSymbol(char code, string font) : base(code, font)
    {

    }

    public override void Display(int x, int y, string color, int size)
    {
        Console.WriteLine($"Symbol:{code}, Font:{font},Position:({x},{y}), Color:{color}, Size:{size}");
    }

}
class SymbolFactory
{
    private Dictionary<(char,string),Symbol> symbols = new Dictionary<(char,string),Symbol>();
    public Symbol GetSymbol(char code, string font)
    {
        if (symbols.ContainsKey((code, font)))
        {
            return symbols[(code, font)];
        }
        else
        {
            Symbol symbol1= new ConcreteSymbol(code, font);

            symbols.Add((code, font), symbol1);
            return symbol1;
        }
    }
}
class Client
{
    static void Main(string[] args)
    {
        SymbolFactory factory = new SymbolFactory();
        Symbol a = factory.GetSymbol('A', "Arial");
        Symbol b = factory.GetSymbol('B', "Arial");
        Symbol c = factory.GetSymbol('C', "Arial");
        Symbol d = factory.GetSymbol('D', "Times New Roman");

        a.Display(10, 10, "Red", 12);
        b.Display(20, 20, "Green", 14);
        c.Display(30, 30, "Blue", 16);
        d.Display(40, 40, "Black", 18);

       Console.WriteLine($"Number of objects created: {factory.GetSymbol}");
    }

}