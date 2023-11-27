abstract class PrintStrategy
{
    public abstract void Print(string text);
}
class BlackAndWhitePrintStrategy : PrintStrategy
{

    public override void Print(string text)
    {
        Console.WriteLine("Printing in black and white:" + text);
    }
}
class ColorPrintStrategy : PrintStrategy
{
    public override void Print(string text)
    {
        Console.WriteLine("Printing in color:" + text);
    }
}
class PhotoPrintStrategy : PrintStrategy
{
    public override void Print(String text)
    {
        Console.WriteLine("Printing a photo"+ text);
    }
}
class Printer
{
    private PrintStrategy printStrategy;
    private string model;
    public Printer(PrintStrategy printStrategy, string model)
    {
        this.printStrategy = printStrategy;
        this.model = model;
       
    }
    public void Print(string text)
    {
        Console.WriteLine("Using printer model: " + model);
        printStrategy.Print(text);
    }

}
class Program
{
    static void Main(string[] args)
    {
        PrintStrategy blackAndWhite = new BlackAndWhitePrintStrategy();
        PrintStrategy colorPrint = new ColorPrintStrategy();
        PrintStrategy photo = new PhotoPrintStrategy();

        Printer printerA = new Printer(blackAndWhite, "Printer A");
        
        Printer printerB = new Printer(colorPrint, "Printer B");
    
        Printer printerC = new Printer(photo, "Printer C");
        
        printerA.Print(" [Hello, world!]");
        printerB.Print(" [Hello, world!]");
        printerC.Print(" [Hello, world!]");
    }
}