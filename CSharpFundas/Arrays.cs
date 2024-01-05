
using System;

string[] a = { "Hello", "Bye", "Neelima", "Bathula" };
int[] b = { 1, 2, 3, 4, 5 };

Console.WriteLine(a[1]);

String[] a1 = new string[4];
a1[0] = "hello";
a1[1] = "bye";

Console.WriteLine(a1[0]+" "+a1[1]);


for (int i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
    if (a[i] == "Neelima")
    {
        Console.WriteLine("Match Found");
        break;
    }
}
