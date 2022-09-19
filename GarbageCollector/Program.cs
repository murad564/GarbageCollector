namespace GarbageCollector;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student()
    {
        Console.WriteLine("Constructor - Gen:");
        Console.WriteLine(GC.GetGeneration(this));
    }

    ~Student() // Finalizer
    {
        Console.WriteLine($"Finalizer {Id}");
    }
}



class Program
{
    static void DoSomething()
    {
        //Student s1 = new();
        //Student s2 = new();

        for (int i = 0; i < 100; i++)
        {
            new Student() { Id = i };
        }
    }


    static void Main()
    {
        FileStream fs = new FileStream("myFile.txt",FileMode.Create); // 2
        StreamWriter sw = new StreamWriter(fs); // 1
        DoSomething();
        GC.Collect();
        GC.WaitForPendingFinalizers();
}
}