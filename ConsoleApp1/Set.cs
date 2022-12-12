namespace ConsoleApp1;

internal class Set
{
    private SortedSet<int> _original = new();

    private List<SortedSet<int>> _sets = new();

    public Set(List<int> set)
    {
        foreach (int item in set)
        {
            _original.Add(item);
        }
    }

    public List<int> Union(int f, int s)
    {
        SortedSet<int> union = new(_sets[f]);
        foreach (int set in _sets[s])
        {
            union.Add(set);
        }
        return union.ToList();
    }

    public List<int> Difference(int f, int s)
    {
        SortedSet<int> diff = new(_sets[f]);
        foreach (int set in _sets[s])
        {
            diff.Remove(set);
        }
        return diff.ToList();
    }

    public List<int> Intersection(int f, int s)
    {
        SortedSet<int> inter = new(_sets[f]);
        return inter.Intersect(_sets[s]).ToList();
    }

    public void SeeOriginal()
    {
        PrintSet(_original.ToList());
    }

    public void PrintSet(List<int> set)
    {
        Console.Write("\n");
        int s = 0;
        foreach (var item in set)
        {
            Console.Write($"{item}\t");
            s++;
            if (s % 5 == 0)
                Console.Write("\n");
        }
        Console.Write("\n");
    }

    public void SeeSets()
    {
        for (int i = 0; i < _sets.Count; i++)
        {
            Console.WriteLine($"set #{i}");
            PrintSet(_sets[i].ToList());
        }
        Console.Write("\n");
    }

    public void GetSetFromOriginal(string set)
    {
        SortedSet<int> numbers = new(set.Split(',').Select(int.Parse));
        if (!numbers.All(n => _original.Contains(n)))
        {
            throw new Exception("Нельзя виделить сет");
        }

        _sets.Add(numbers);
    }

    public void Remove(int index) 
    {
        _sets.RemoveAt(index);
    }
}