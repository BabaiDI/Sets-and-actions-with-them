using ConsoleApp1;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Введите сет. Пример: 1, 2, 5, 7, 10\n");
        if (Console.ReadLine() is not string com)
            return;

        List<int> ints = com.Split(',').Select(int.Parse).ToList();

        Set set = new(ints);

        while (true)
        {
            Console.WriteLine($"1: Посмотреть оригинальний сет\n" +
                              $"2: Посмотреть свой сет\n" +
                              $"3: Виделить сет\n" +
                              $"4: Вивести обьединение\n" +
                              $"5: Вивести разницу\n" +
                              $"6: Вивести пересичение\n" +
                              $"7: Удалить сет\n" +
                              $"0: Выйти\n");
            Console.Write("Введите команду: ");

            int[]? range;

            switch (Console.ReadLine())
            {
                case ("1"):
                    set.SeeOriginal();
                    break;
                case ("2"):
                    set.SeeSets();
                    break;
                case ("3"):
                    Console.WriteLine("Введите числа. Пример: 1, 0, 5, 3\n");
                    if (Console.ReadLine() is string intRange)
                    {
                        try
                        {
                            set.GetSetFromOriginal(intRange);
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case ("4"):
                    range = getRange();
                    try
                    {
                        List<int> union = set.Union(range[0], range[1]);
                        set.PrintSet(union);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case ("5"):
                    range = getRange();
                    try
                    {
                        List<int> union = set.Difference(range[0], range[1]);
                        set.PrintSet(union);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case ("6"):
                    range = getRange();
                    try
                    {
                        List<int> union = set.Intersection(range[0], range[1]);
                        set.PrintSet(union);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case ("7"):
                    Console.WriteLine("Введите индекс\n");
                    if (Console.ReadLine() is string index)
                    {
                        try
                        {
                            set.Remove(int.Parse(index));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case ("0"):
                    return;
                default:
                    break;
            }
        }

        int[]? getRange()
        {
            Console.WriteLine("Введите индкси. Пример: 1, 0; 2, 3\n");
            if (Console.ReadLine() is string com)
            {
                int[] ints = com.Split(',').Select(int.Parse).ToArray();
                if (ints.Length > 2)
                {
                    Console.WriteLine("Много чисел");
                    return default;
                }
                return ints;
            }
            return default;
        }
    }
}