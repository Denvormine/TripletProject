using System.Collections.Concurrent;
using TripletProject;

var watch = System.Diagnostics.Stopwatch.StartNew();

string filepath = args[0];

if (!File.Exists(filepath))
{
    Console.WriteLine("File doesn't exist");
}

ConcurrentDictionary<Triplet, int> tripletDictionary = 
    new ConcurrentDictionary<Triplet, int>();

Parallel.ForEach(File.ReadLines(filepath), line =>
{
    for (int i = 2; i < line.Length;)
    {
        Triplet triplet = new Triplet(line[i - 2], line[i - 1], line[i]);
    
        if (!Char.IsLetter(triplet.Letter3))
        {
            i += 3;
            continue;
        }
    
        if (!Char.IsLetter(triplet.Letter2))
        {
            i += 2;
            continue;
        }
    
        if (!Char.IsLetter(triplet.Letter1))
        {
            i++;
            continue;
        }
        
        tripletDictionary.AddOrUpdate(triplet, 1, (_, i1) => i1 + 1);
        i++;
    }
});

foreach (var keyValuePair in tripletDictionary.OrderByDescending(x => x.Value).Take(10))
{
    Console.WriteLine(keyValuePair.Key + " " + keyValuePair.Value);
}

watch.Stop();

Console.WriteLine(watch.ElapsedMilliseconds);
