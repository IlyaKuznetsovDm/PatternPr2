// Абстрактный класс приспособленца
abstract class Symbol
{
    // Внутреннее состояние: код и шрифт символа
    protected char code;
    protected string font;

    // Конструктор
    internal Symbol(char code, string font)
    {
        this.code = code;
        this.font = font;
    }

    // Абстрактный метод для отображения символа
    // Внешнее состояние: положение, цвет и размер символа
    public abstract void Display(int x, int y, string color, int size);
}

// Конкретный класс приспособленца
class ConcreteSymbol : Symbol
{
    // Конструктор
    public ConcreteSymbol(char code, string font) : base(code, font)
    {
    }

    // Реализация метода для отображения символа
    public override void Display(int x, int y, string color, int size)
    {
        // Используем внутреннее и внешнее состояние для отображения символа
        Console.WriteLine($"Symbol: {code}, Font: {font}, Position: ({x}, {y}), Color: {color}, Size: {size}");
    }
}

// Класс фабрики приспособленцев
class SymbolFactory
{
    // Словарь для хранения разделяемых объектов
    private Dictionary<(char, string), Symbol> symbols = new Dictionary<(char, string), Symbol>();

    // Метод для получения приспособленца по коду и шрифту символа
    public Symbol GetSymbol(char code, string font)
    {
        // Если такой объект уже есть в словаре, то возвращаем его
        if (symbols.ContainsKey((code, font)))
        {
            return symbols[(code, font)];
        }
        // Иначе создаем новый объект и добавляем его в словарь
        else
        {
            Symbol symbol = new ConcreteSymbol(code, font);
            symbols.Add((code, font), symbol);
            return symbol;
        }
    }
}

// Класс клиента
class Client
{
    static void Main(string[] args)
    {
        // Создаем фабрику приспособленцев
        SymbolFactory factory = new SymbolFactory();

        // Получаем разделяемые объекты для символов
        Symbol a = factory.GetSymbol('A', "Arial");
        Symbol b = factory.GetSymbol('B', "Arial");
        Symbol c = factory.GetSymbol('C', "Arial");
        Symbol d = factory.GetSymbol('D', "Times New Roman");

        // Отображаем символы с разными внешними состояниями
        a.Display(10, 10, "Red", 12);
        b.Display(20, 20, "Green", 14);
        c.Display(30, 30, "Blue", 16);
        d.Display(40, 40, "Black", 18);

        // Проверяем, что количество созданных объектов равно количеству уникальных кодов и шрифтов
        Console.WriteLine($"Number of objects created: {factory.symbols.Count}");
    }
}