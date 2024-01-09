using System;
using System.Collections;

ArrayList a = new ArrayList();
a.Add("hello");
a.Add("Bye");
a.Add("Neelima");
a.Add("Apple");

Console.WriteLine(a[1]);

foreach (String item in a)
{
    Console.WriteLine(item);
}

Console.WriteLine(a.Count);
Console.WriteLine(a.Contains("Neelima"));

Console.WriteLine("After sorting an array");
a.Sort();
foreach (string item in a)
{
    Console.WriteLine(item);
}

int i=10;
Console.WriteLine(i);