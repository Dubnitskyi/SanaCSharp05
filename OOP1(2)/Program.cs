using System.Text;

class Currency
{
    protected string Name;
    protected float ExRate;

    public void SetName(string name)
    {
        if (name != "")
            Name = name;
        else
            Name = "Unknown";
    }
    public void SetExRate(float exRate)
    {
        if (exRate > 0)
            ExRate = exRate;
        else
            ExRate = 0;
    }
    public string GetName()
    {
        return Name;
    }
    public float GetExRate()
    {
        return ExRate;
    }

    public Currency()
    {
        Name = "Unknown";
        ExRate = 0;
    }
    public Currency(string name, float exRate)
    {
        SetName(name);
        SetExRate(exRate);
    }
    public Currency(float exRate)
    {
        Name = "Unknown";
        SetExRate(exRate);
    }

    public Currency(Currency newCurrency)
    {
        Name = newCurrency.Name;
        ExRate = newCurrency.ExRate;
    }
}
class Product
{
    protected string Name;
    protected float Price;
    protected Currency Cost;
    protected ushort Quantity;
    protected string Producer;
    protected float Weight;

    protected float expDateInDays;
    protected float expDateInMonths;
    protected float expDateInYears;
    public float ExpDateInDays
    {
        set { expDateInDays = value; expDateInMonths = value / 30; expDateInYears = value / 365; }
        get { return expDateInDays; }
    }
    public float ExpDateInMonths
    {
        set { expDateInDays = value * 30 + value / 2.4f; expDateInMonths = value; expDateInYears = (value * 30 + value / 2.4f) / 365; }
        get { return expDateInMonths; }
    }
    public float ExpDateInYears
    {
        set { expDateInDays = value * 365; expDateInMonths = value * 12; expDateInYears = value; }
        get { return expDateInYears; }
    }

    public void SetName(string name)
    {
        if (name != "")
            Name = name;
        else
            Name = "Unknown";
    }
    public void SetPrice(float price)
    {
        if (price > 0)
            Price = price;
        else
            Price = 0;
    }
    public void SetCost(Currency cost)
    {
        Cost = new Currency(cost);
    }
    public void SetQuantity(ushort quantity)
    {
        if (quantity > 0)
            Quantity = quantity;
        else
            Quantity = 0;
    }
    public void SetProducer(string producer)
    {
        if (producer != "")
            Producer = producer;
        else
            Producer = "Unknown";
    }
    public void SetWeight(float weight)
    {
        if (weight > 0.0)
            Weight = weight;
        else
            Weight = 0;
    }
    public string GetName()
    {
        return Name;
    }
    public float GetPrice()
    {
        return Price;
    }
    public Currency GetCost()
    {
        return Cost;
    }
    public ushort GetQuantity()
    {
        return Quantity;
    }
    public string GetProducer()
    {
        return Producer;
    }
    public float GetWeight()
    {
        return Weight;
    }

    public Product()
    {
        Name = "Unknown";
        Price = 0;
        Cost = new Currency();
        Quantity = 0;
        Producer = "Unknown";
        Weight = 0;
    }
    public Product(string name, float price, Currency cost, ushort quantity, string producer, float weight)
    {
        SetName(name);
        SetPrice(price);
        SetCost(cost);
        SetQuantity(quantity);
        SetProducer(producer);
        SetWeight(weight);
    }
    public Product(ushort quantity, string producer, float weight)
    {
        Name = "Unknown";
        Price = 0;
        Cost = new Currency();
        SetQuantity(quantity);
        SetProducer(producer);
        SetWeight(weight);
    }
    public Product(Product newProduct)
    {
        Name = newProduct.Name;
        Price = newProduct.Price;
        Cost = new Currency(newProduct.Cost);
        Quantity = newProduct.Quantity;
        Producer = newProduct.Producer;
        Weight = newProduct.Weight;
    }

    public float GetPriceInUAH()
    {
        return Price * Cost.GetExRate();
    }
    public float GetTotalPriceInUAH()
    {
        return GetPriceInUAH() * Quantity;
    }
    public float GetTotalWeight()
    {
        return Weight * Quantity;
    }
}
class Program
{
    static float ReadAndCheckFloat(string sentence)
    {
        float n;
        Console.Write($"{sentence}");
        while (!float.TryParse(Console.ReadLine(), out n))
            Console.Write($"Помилка введеня значення. Будь ласка повторіть введення значення ще раз!\n{sentence}");
        return n;
    }
    static ushort ReadAndCheckUshort(string sentence)
    {
        ushort n;
        Console.Write($"{sentence}");
        while (!ushort.TryParse(Console.ReadLine(), out n))
            Console.Write($"Помилка введеня значення. Будь ласка повторіть введення значення ще раз!\n{sentence}");
        return n;
    }
    static ushort Choice(string sentence, ushort a, ushort b)
    {
        ushort n;
        Console.Write($"{sentence}");
        while (!ushort.TryParse(Console.ReadLine(), out n) || n < a || n > b)
            Console.Write($"Помилка введеня значення. Будь ласка повторіть введення значення ще раз!\n{sentence}");
        return n;
    }

    static Product[] ReadProductsArray(Product[] prod)
    {
        Product[] newArr = prod;
        string Name;
        float Price;
        Currency Cost;
        string NameOfCarr;
        float ExRate;
        ushort Quantity;
        string Producer;
        float Weight;
        ushort n, choice;
        n = Choice("Введіть к-сть продуктів.\nВаш вибір: ", 1, 65535);
        for (ushort i = 0; i < n; i++)
        {
            Console.Write("Введіть назву продукту: ");
            Name = Console.ReadLine();
            Price = ReadAndCheckFloat("Введіть ціну за одиницю товару: ");
            Console.Write("Введіть назву валюти: ");
            NameOfCarr = Console.ReadLine();
            ExRate = ReadAndCheckFloat("Введіть курс: ");
            Cost = new Currency(NameOfCarr, ExRate);
            Quantity = ReadAndCheckUshort("Введіть кількість наявних товарів на складі: ");
            Console.Write("Введіть назву компанії-виробника: ");
            Producer = Console.ReadLine();
            Weight = ReadAndCheckFloat("Введіть вагу одного товару (кг.): ");
            choice = Choice("В чому виміряти термін придатності? 1-дні, 2-місяці, 3-роки.\nВаш вибір: ", 1, 3);
            Array.Resize(ref newArr, newArr.Length + 1);
            newArr[newArr.Length - 1] = new Product();
            newArr[newArr.Length - 1] = new Product(Name, Price, Cost, Quantity, Producer, Weight);
            if (choice == 1)
                newArr[newArr.Length - 1].ExpDateInDays = ReadAndCheckFloat("Введіть термін придатності: ");
            if (choice == 2)
                newArr[newArr.Length - 1].ExpDateInMonths = ReadAndCheckFloat("Введіть термін придатності: ");
            if (choice == 3)
                newArr[newArr.Length - 1].ExpDateInYears = ReadAndCheckFloat("Введіть термін придатності: ");
            Console.WriteLine();
        }
        return newArr;
    }
    static void GetProductsInfo(Product[] prod, out Product max, out Product min)
    {
        float maxPrice = float.MinValue;
        float minPrice = float.MaxValue;
        ushort maxI = 0, minI = 0;
        for (ushort i = 0; i < prod.Length; i++)
        {
            if (maxPrice < prod[i].GetPriceInUAH())
            {
                maxI = i;
                maxPrice = prod[i].GetPriceInUAH();
            }
            if (minPrice < prod[i].GetPriceInUAH())
            {
                minI = i;
                minPrice = prod[i].GetPriceInUAH();
            }
        }
        max = prod[maxI];
        min = prod[minI];
    }
    static void PrintProduct(Product prod)
    {
        Console.WriteLine($"{"",-4}{prod.GetName(),-29}{prod.GetPrice(),-8}{prod.GetCost().GetName(),-10}{prod.GetCost().GetExRate(),-12}{prod.GetQuantity(),-20}{prod.GetProducer(),-26}{prod.GetWeight(),-22}{$"Дні – {prod.ExpDateInDays}"}");
        Console.WriteLine($"{"Місяці – ",140}{prod.ExpDateInMonths}");
        Console.WriteLine($"{"Роки – ",138}{prod.ExpDateInYears}");
        Console.WriteLine();
    }
    static void PrintProducts(Product[] prod)
    {
        Console.WriteLine($"{"Назва товару",16}{"Ціна",21}{"Валюта",10}{"Курс",8}{"Кількість товару",24}{"Компанія-виробник",21} {"Вага одного товару",26}{"Термін придатності",22}");
        for (int i = 0; i < prod.Length; i++)
        {
            PrintProduct(prod[i]);
        }
    }
    public static int SortProductsByPrice(Product a, Product b)
    {
        float prA = a.GetPriceInUAH(), prB = b.GetPriceInUAH();
        if (prA > prB)
            return 1;
        if (prA < prB)
            return -1;
        return 0;
    }
    public static int SortProductsByCount(Product a, Product b)
    {
        ushort qA = a.GetQuantity(), qB = b.GetQuantity();
        if (qA > qB)
            return 1;
        if (qA < qB)
            return -1;
        return 0;
    }
    static void Main(string[] args)
    {
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
        System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";
        System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        ushort choiceM, choiceF, num;
        Product[] prod = new Product[0];
        do
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------Меню--------------");
            Console.WriteLine("1 - Введення даних.");
            Console.WriteLine("2 - Інформація про товар.");
            Console.WriteLine("3 - Виведення товарів на екран.");
            Console.WriteLine("4 - Сортування даних.");
            Console.WriteLine("0 - Вихід.");
            choiceM = Choice("Ваш вибір: ", 0, 4);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            switch (choiceM)
            {
                case 1:
                    prod = ReadProductsArray(prod);
                    Console.Clear();
                    break;
                case 2:
                    if (prod.Length > 0)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("-----------Інформація про товар-----------");
                            Console.WriteLine("1 - Ціна одного товару в гривнях.");
                            Console.WriteLine("2 - Загальна вартість усіх товарів даного виду.");
                            Console.WriteLine("3 - Загальна вага усіх товарів даного виду.");
                            Console.WriteLine("4 - Найдешевший та найдорожчий товар.");
                            Console.WriteLine("0 - Вихід до головного меню.");
                            choiceF = Choice("Ваш вибір: ", 0, 4);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            switch (choiceF)
                            {
                                case 1:
                                    num = Choice("Оберіть номер товару.\nВаш вибір: ", 1, (ushort)(prod.Length));
                                    float PriceInUAH = prod[num - 1].GetPriceInUAH();
                                    Console.WriteLine($"Ціна одного товару в гривнях: {PriceInUAH}");
                                    break;
                                case 2:
                                    num = Choice("Оберіть номер товару.\nВаш вибір: ", 1, (ushort)(prod.Length));
                                    float TotalPriceInUAH = prod[num - 1].GetTotalPriceInUAH();
                                    Console.WriteLine($"Загальна вартість усіх товарів даного виду: {TotalPriceInUAH}");
                                    break;
                                case 3:
                                    num = Choice("Оберіть номер товару.\nВаш вибір: ", 1, (ushort)(prod.Length));
                                    float TotalWeight = prod[num - 1].GetTotalWeight();
                                    Console.WriteLine($"Загальна вага усіх товарів даного виду: {TotalWeight}");
                                    break;
                                case 4:
                                    Product max, min;
                                    GetProductsInfo(prod, out max, out min);
                                    Console.WriteLine($"Найдорожчий та найдешевший товар на складі:");
                                    Console.WriteLine($"{"Назва товару",16}{"Ціна",21}{"Валюта",10}{"Курс",8}{"Кількість товару",24}{"Компанія-виробник",21} {"Вага одного товару",26}");
                                    PrintProduct(max);
                                    PrintProduct(min);
                                    break;
                            }
                        } while (choiceF != 0);
                    }
                    else
                        Console.WriteLine("Список товарів пустий! Заповніть його.\n");
                    break;
                case 3:
                    if (prod.Length > 0)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("-------Виведення товарів-------");
                            Console.WriteLine("1 - Вивести на екран один товар.");
                            Console.WriteLine("2 - Вивести на екран всі товари.");
                            Console.WriteLine("0 - Вихід до головного меню.");
                            choiceF = Choice("Ваш вибір: ", 0, 2);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            switch (choiceF)
                            {
                                case 1:
                                    num = Choice("Оберіть номер товару.\nВаш вибір: ", 1, (ushort)(prod.Length));
                                    Console.WriteLine($"{"Назва товару",16}{"Ціна",21}{"Валюта",10}{"Курс",8}{"Кількість товару",24}{"Компанія-виробник",21} {"Вага одного товару",26}{"Термін придатності",22}");
                                    PrintProduct(prod[num - 1]);
                                    break;
                                case 2:
                                    PrintProducts(prod);
                                    break;
                            }

                        } while (choiceF != 0);
                    }
                    else
                        Console.WriteLine("Список товарів пустий! Заповніть його.\n");
                    break;
                case 4:
                    if (prod.Length > 0)
                    {
                        do
                        {
                            Console.WriteLine("-------Сортування-------");
                            Console.WriteLine("1 - Сортування за ціною.");
                            Console.WriteLine("2 - Сортування за кількістю товарів.");
                            Console.WriteLine("0 - Вихід до головного меню.");
                            choiceF = Choice("Ваш вибір: ", 0, 2);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            switch (choiceF)
                            {
                                case 1:
                                    Array.Sort(prod, SortProductsByPrice);
                                    Console.WriteLine("Сортування за ціною відбулося.\n");
                                    break;
                                case 2:
                                    Array.Sort(prod, SortProductsByCount);
                                    Console.WriteLine("Сортування за кількістю відбулося.\n");
                                    break;
                            }
                        } while (choiceF != 0);
                    }
                    else
                        Console.WriteLine("Список товарів пустий! Заповніть його.\n");
                    break;
            }
        } while (choiceM != 0);
    }
}
