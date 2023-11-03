// See https://aka.ms/new-console-template for more information

using CsvPoc;
using System.Buffers;

Console.WriteLine("Hello, World!");
//await CsvGenerator.Generate("D:\\Soft\\cocojambo.csv", 500, 10_000);

using var fs = File.Open("D:\\Soft\\cocojambo.csv", FileMode.Open);
using var sr = new StreamReader(fs);
var arr = new char[512];
var mem = new Memory<char>(arr);
var chunk = await sr.ReadAsync(mem);
Console.WriteLine(mem.Length);
Console.WriteLine(mem.Span.ToString());
Console.WriteLine();
Console.WriteLine("================");
Console.WriteLine();

await sr.ReadAsync(mem);
Console.WriteLine(mem.Length);
Console.WriteLine(mem.Span.ToString());

Console.WriteLine();
Console.WriteLine("================");
Console.WriteLine();

await sr.ReadAsync(mem);
Console.WriteLine(mem.Length);
Console.WriteLine(mem.Span.ToString());


//var memory = new Memory<char>();
//var r = memory.Span.IndexOf(Environment.NewLine);
//var chunk = sr.ReadAsync(memory);