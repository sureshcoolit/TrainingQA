using System;
using CSharpFundas;

Console.WriteLine("I am in the second program");
// If I don’t write main method, then by default at runtime the system writes the main method globally and that class will execute first
// Global scope of main will be called first, that's y this class executed first

Variables v = new Variables();
v.getData();
