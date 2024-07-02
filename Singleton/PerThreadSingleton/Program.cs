using PerThreadSingleton;

var t1 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"Thread 1: {PerThreadSingleton.PerThreadSingleton.Instance.Id}");
});

var t2 = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"Thread 2: {PerThreadSingleton.PerThreadSingleton.Instance.Id}");
    Console.WriteLine($"Thread 2: {PerThreadSingleton.PerThreadSingleton.Instance.Id}");
});

Task.WaitAll(t1, t2);