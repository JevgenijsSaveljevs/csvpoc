// See https://aka.ms/new-console-template for more information

using CsvPoc;
using System.Buffers;
using System.IO.Pipelines;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using static Bogus.DataSets.Name;

Console.WriteLine("Hello, World!");
//await CsvGenerator.Generate("D:\\Soft\\cocojambo.csv", 500, 10_000);

string fileName = "D:\\Soft\\cocojambo.csv";

//using var fs = File.Open(fileName, FileMode.Open);
//using var sr = new StreamReader(fs);
//var arr = new char[512];
//var mem = new Memory<char>(arr);
//var chunk = await sr.ReadAsync(mem);
//Console.WriteLine(mem.Length);
//Console.WriteLine(mem.Span.ToString());
//Console.WriteLine();
//Console.WriteLine("================");
//Console.WriteLine();

//await sr.ReadAsync(mem);
//Console.WriteLine(mem.Length);
//Console.WriteLine(mem.Span.ToString());

//Console.WriteLine();
//Console.WriteLine("================");
//Console.WriteLine();

//await sr.ReadAsync(mem);
//Console.WriteLine(mem.Length);
//Console.WriteLine(mem.Span.ToString());


//var memory = new Memory<char>();
//var r = memory.Span.IndexOf(Environment.NewLine);
//var chunk = sr.ReadAsync(memory);

//var list  = new List<char>();
//var spans = CollectionsMarshal.AsSpan(list);
//Span<char> c = new Span<char>();
//c.ad
//spans.Slice()

//using var fs = File.Open(fileName, FileMode.Open);
//var reader = PipeReader.Create(fs);
//var writer = PipeWriter.Create(
//           Console.OpenStandardOutput(),
//           new StreamPipeWriterOptions(leaveOpen: true));

//ReadResult readResult = await reader.ReadAsync();
//ReadOnlySequence<byte> buffer = readResult.Buffer;
//readResult.Buffer.

//Console.WriteLine(buffer);
////var pipe = new Pipe();
////PipeReader reader = pipe.Reader;
////PipeWriter writer = pipe.Writer;



//using var fs = File.Open(fileName, FileMode.Open);
//using var sr = new StreamReader(fs);
//fs.ReadAsync()

// demoware - this prototype example doesn't cover all edge cases!
var result = new List<Person>();
//var result = await CloudFrontParserNew.ParseAsync(fileName, res);

using var fs = File.Open(fileName, FileMode.Open);
await foreach (var batch in FancyStreamReader.ReadStreamAsAsyncEnumerable(PipeReader.Create(fs)))
{
    Console.WriteLine($"done: {batch.Count}");
}




//await foreach (var p in FunnyPrinter.GetPersions())
//{
//    Console.WriteLine(p);
//}


//public class FunnyPrinter
//{
//    public static async IAsyncEnumerable<Person> GetPersions()
//    {
//        await Task.Delay(10);
//        yield return new Person();
//        yield return new Person();
//        yield return new Person();
//        yield return new Person();
//        yield return new Person();
//        //yield break;
//    }
//}