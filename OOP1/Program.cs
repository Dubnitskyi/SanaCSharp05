class Airplane
{
    private string StartCity;
    private string FinishCity;
    private Date StartDate;
    private Date FinishDate;
    public Airplane()
    {
        StartDate = new Date();
        FinishDate = new Date();
    }
    public Airplane(string startCity, string finishCity)
    {
        StartCity = startCity;
        FinishCity = finishCity;
    }
    public Airplane(string startCity, string finishCity, int startYear, int startMonth, int startDay, int startHours, int startMinutes, int finishYear, int finishMonth, int finishDay, int finishHours, int finishMinutes)
    {
        StartCity = startCity;
        FinishCity = finishCity;
        StartDate = new Date(startYear, startMonth, startDay, startHours, startMinutes);
        FinishDate = new Date(finishYear, finishMonth, finishDay, finishHours, finishMinutes);
    }
    public Airplane(Airplane Copy)
    {
        StartCity = Copy.StartCity;
        FinishCity = Copy.FinishCity;
        StartDate = new Date(Copy.StartDate);
        FinishDate = new Date(Copy.FinishDate);
    }

    public string startCity
    {
        set { StartCity = value; }
        get { return StartCity; }

    }
    public string finishCity
    {
        set { FinishCity = value; }
        get { return FinishCity; }
    }
    public int startYear
    {
        get { return StartDate.year; }
        set { StartDate.year = value; }
    }
    public int startMonth
    {
        get { return StartDate.month; }
        set { StartDate.month = value; }
    }
    public int startDay
    {
        get { return StartDate.day; }
        set { StartDate.day = value; }
    }
    public int startHours
    {
        get { return StartDate.hours; }
        set { StartDate.hours = value; }
    }
    public int startMinutes
    {
        get { return StartDate.minutes; }
        set { StartDate.minutes = value; }
    }
    public int finishYear
    {
        get { return FinishDate.year; }
        set { FinishDate.year = value; }
    }
    public int finishMonth
    {
        get { return FinishDate.month; }
        set { FinishDate.month = value; }
    }
    public int finishDay
    {
        get { return FinishDate.day; }
        set { FinishDate.day = value; }
    }
    public int finishHours
    {
        get { return FinishDate.hours; }
        set { FinishDate.hours = value; }
    }
    public int finishMinutes
    {
        get { return FinishDate.minutes; }
        set { FinishDate.minutes = value; }
    }

    public int GetTotalTime()
    {
        int flightTime = 0;
        flightTime += (FinishDate.year - StartDate.year) * 525600;
        flightTime += (FinishDate.month - StartDate.month) * 44640;
        flightTime += (FinishDate.day - StartDate.day) * 1440;
        flightTime += (FinishDate.hours - StartDate.hours) * 60;
        flightTime += (FinishDate.minutes - StartDate.minutes);
        return flightTime;
    }
    public bool IsArrivingToday()
    {
        bool ok = false;
        if (StartDate.year == FinishDate.year && StartDate.month == FinishDate.month && StartDate.day == FinishDate.day)
            ok = true;
        else
            ok = false;
        return ok;
    }

}
class Date
{
    private int Year;
    private int Month;
    private int Day;
    private int Hours;
    private int Minutes;
    public Date()
    {

    }
    public Date(int year, int month, int day, int hours, int minutes)
    {
        Year = year;
        Month = month;
        Day = day;
        Hours = hours;
        Minutes = minutes;
    }
    public Date(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }
    public Date(int StartDate)
    {

    }
    public Date(Date Copy)
    {

    }

    public int year
    {
        get { return Year; }
        set { Year = value; }
    }
    public int month
    {
        get { return Month; }
        set { Month = value; }
    }
    public int day
    {
        get { return Day; }
        set { Day = value; }
    }
    public int hours
    {
        get { return Hours; }
        set { Hours = value; }
    }
    public int minutes
    {
        get { return Minutes; }
        set { Minutes = value; }
    }



}
class Program
{
    static int CheckInt()
    {
        bool f;
        int x;
        do
        {
            f = int.TryParse(Console.ReadLine(), out x);
            Console.ForegroundColor = ConsoleColor.Red;
            if (f == false)
            {
                Console.WriteLine(" Помилка введення значення. Будь-ласка, повторіть введення ще раз!");
                Console.ResetColor();
                Console.Write("Введіть значеня ще раз: ");
            }
            Console.ResetColor();
        } while (!f);
        return x;
    }
    static Airplane[] ReadAirplaneArray()
    {

        Console.Write("Введiть кiлькiсть рейсiв: ");
        int numberOfReis = CheckInt();
        Airplane[] AirplaneArray = new Airplane[numberOfReis];
        Airplane plane = new Airplane();
        for (int i = 0; i < numberOfReis; i++)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\t Рейс №{i + 1}");
            Console.ResetColor();
            Console.Write("Місто відправлення: ");
            plane.startCity = Console.ReadLine();
            Console.Write("Місто прибуття: ");
            plane.finishCity = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t Дата відправлення ");
            Console.ResetColor();
            Console.Write("Рік: ");
            plane.startYear = CheckInt();
            Console.Write("Місяць: ");
            plane.startMonth = CheckInt();
            Console.Write("День: ");
            plane.startDay = CheckInt();
            Console.Write("Години: ");
            plane.startHours = CheckInt();
            Console.Write("Хвилини: ");
            plane.startMinutes = CheckInt();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t Дата прибуття ");
            Console.ResetColor();
            Console.Write("Рік: ");
            plane.finishYear = CheckInt();
            Console.Write("Місяць: ");
            plane.finishMonth = CheckInt();
            Console.Write("День: ");
            plane.finishDay = CheckInt();
            Console.Write("Години: ");
            plane.finishHours = CheckInt();
            Console.Write("Хвилини: ");
            plane.finishMinutes = CheckInt();
            AirplaneArray[i] = new Airplane(plane.startCity, plane.finishCity, plane.startYear, plane.startMonth, plane.startDay, plane.startHours, plane.startMinutes, plane.finishYear, plane.finishMonth, plane.finishDay, plane.finishHours, plane.finishMinutes);
        }

        return AirplaneArray;


    }
    static void PrintAirplane(Airplane[] plane)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write("\nВведіть номер рейсу: ");
        int i = CheckInt();
        Console.ResetColor();
        Console.WriteLine($"\nМісто відправдення: {plane[i - 1].startCity}");
        Console.WriteLine($"Місто прибуття: {plane[i - 1].finishCity}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Дата відправлення: ");
        Console.ResetColor();
        if (plane[i - 1].startDay < 10) Console.Write($"0{plane[i - 1].startDay}.");
        else Console.Write($"{plane[i - 1].startDay}.");
        if (plane[i - 1].startMonth < 10) Console.Write($"0{plane[i - 1].startMonth}.{plane[i - 1].startYear}");
        else Console.Write($"{plane[i - 1].startMonth}.{plane[i - 1].startYear}");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nЧас відправлення: ");
        Console.ResetColor();
        if (plane[i - 1].startHours < 10) Console.Write($"0{plane[i - 1].startHours}:");
        else Console.Write($"{plane[i - 1].startHours}:");
        if (plane[i - 1].startMinutes < 10) Console.Write($"0{plane[i - 1].startMinutes}\n");
        else Console.Write($"{plane[i - 1].startMinutes}\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\nДата прибуття: ");
        Console.ResetColor();
        if (plane[i - 1].finishDay < 10) Console.Write($"0{plane[i - 1].finishDay}.");
        else Console.Write($"{plane[i - 1].finishDay}.");
        if (plane[i - 1].finishMonth < 10) Console.Write($"0{plane[i - 1].finishMonth}.{plane[i - 1].finishYear}");
        else Console.Write($"{plane[i - 1].finishMonth}.{plane[i - 1].finishYear}");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nЧас прибуття: ");
        Console.ResetColor();
        if (plane[i - 1].finishHours < 10) Console.Write($"0{plane[i - 1].finishHours}:");
        else Console.Write($"{plane[i - 1].finishHours}:");
        if (plane[i - 1].finishMinutes < 10) Console.Write($"0{plane[i - 1].finishMinutes}\n");
        else Console.Write($"{plane[i - 1].finishMinutes}\n");
    }
    static void PrintAirplanes(Airplane[] plane)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("|   № \t|   Місто відправлення \t|   Місто прибуття  \t|   Дата відправлення \t|    Час відправлення\t|     Дата прибуття \t|   Час прибуття  |");
        Console.ResetColor();
        for (int i = 0; i < plane.Length; i++)
        {
            Console.Write($"\n{i + 1,5}  {plane[i].startCity,15}  {plane[i].finishCity,20} ");
            if (plane[i].startDay < 10) Console.Write($"\t\t\t0{plane[i].startDay}.");
            else Console.Write($"\t\t\t{plane[i].startDay}.");
            if (plane[i].startMonth < 10) Console.Write($"0{plane[i].startMonth}.{plane[i].startYear}");
            else Console.Write($"{plane[i].startMonth}.{plane[i].startYear}");
            if (plane[i].startHours < 10) Console.Write($"\t\t  0{plane[i].startHours}:");
            else Console.Write($"\t\t  {plane[i].startHours}:");
            if (plane[i].startMinutes < 10) Console.Write($"0{plane[i].startMinutes}");
            else Console.Write($"{plane[i].startMinutes}");

            if (plane[i].finishDay < 10) Console.Write($"\t\t\t0{plane[i].finishDay}.");
            else Console.Write($"\t\t\t{plane[i].finishDay}.");
            if (plane[i].finishMonth < 10) Console.Write($"0{plane[i].finishMonth}.{plane[i].finishYear}");
            else Console.Write($"{plane[i].finishMonth}.{plane[i].finishYear}");
            if (plane[i].finishHours < 10) Console.Write($"\t\t  0{plane[i].finishHours}:");
            else Console.Write($"\t\t  {plane[i].finishHours}:");
            if (plane[i].finishMinutes < 10) Console.Write($"0{plane[i].finishMinutes}");
            else Console.Write($"{plane[i].finishMinutes}\n");
        }
    }
    static void GetAirplaneInfo(Airplane[] plane, out int maxTime, out int minTime)
    {
        minTime = int.MaxValue;
        maxTime = int.MinValue;
        for (int i = 0; i < plane.Length; i++)
        {
            if (plane[i].GetTotalTime() > maxTime)
                maxTime = plane[i].GetTotalTime();
            if (plane[i].GetTotalTime() < minTime)
                minTime = plane[i].GetTotalTime();
        }
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.InputEncoding = System.Text.Encoding.Unicode;
        System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
        System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";
        Airplane[] plane = new Airplane[1000];
        int num;
        do
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n---------- Головне меню ----------\n");
            Console.ResetColor();
            Console.WriteLine("1.Ввести дані про рейс.\n2.Вивести дані про рейс.\n3.Вивести всі дані.\n4.Найбільший та найменший час подорожі.\n5.Сортування за датою відправлення.\n6.Сортування за часом подорожі.\n7.Час подорожі у хвилинах\n8.Рейси, у яких співпадають дати відправлення та прибуття.\n0.Вихід");
            Console.Write("Введіть пункт меню: ");
            num = CheckInt();
            switch (num)
            {
                case 1: Console.Clear(); plane = ReadAirplaneArray(); break;
                case 2: Console.Clear(); PrintAirplane(plane); break;
                case 3: Console.Clear(); PrintAirplanes(plane); break;
                case 4:
                    Console.Clear(); GetAirplaneInfo(plane, out int maxTime, out int minTime);
                    Console.WriteLine($"\nНайбільший час подорожі: {maxTime}хв.\nНайменший час подорожі: {minTime}хв.");
                    break;
                case 5:
                    Console.Clear();
                    for (int i = 0; i < plane.Length; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write($"\nРейс №{i + 1}:");
                        Console.ResetColor();
                        Console.Write($" {plane[i].startCity}-{plane[i].finishCity} у польоті {plane[i].GetTotalTime()} хв.\n");
                    }
                    break;
                case 6:
                    Console.Clear();
                    for (int i = 0; i < plane.Length; i++)
                    {
                        if (plane[i].IsArrivingToday() == true)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write($"\nРейс №{i + 1}:");
                            Console.ResetColor();
                            Console.Write($" {plane[i].startCity}-{plane[i].finishCity} приліт і відправлення ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            if (plane[i].startDay < 10) Console.Write($"0{plane[i].startDay}.");
                            else Console.Write($"{plane[i].startDay}.");
                            if (plane[i].startMonth < 10) Console.Write($"0{plane[i].startMonth}.{plane[i].startYear}\n");
                            else Console.Write($"{plane[i].startMonth}.{plane[i].startYear}\n");
                            Console.ResetColor();
                        }
                    }
                    break;
            }
        } while (num != 0);
    }
}