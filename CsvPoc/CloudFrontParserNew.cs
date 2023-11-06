// See https://aka.ms/new-console-template for more information

using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;

public static class FancyStreamReader
{
    private static ReadOnlySpan<byte> NewLine => Encoding.UTF8.GetBytes("\r\n");

    public static async Task ReadStream(PipeReader pipeReader, List<Person> items, int batchApproximateSize = 1_000)
    {
        var position = 0;
        var parsedCount = 0;
        ReadResult lastReadResult = default;
        while (true)
        {
            var result = await pipeReader.ReadAsync();
            var buffer = result.Buffer;
            var sequencePosition = ParseLines(items, ref buffer, ref position, ref parsedCount);

            pipeReader.AdvanceTo(sequencePosition, buffer.End);

            if (result.IsCompleted || parsedCount >= batchApproximateSize)
            {
                break;
            }
        }

        if (lastReadResult.IsCompleted)
        {
            pipeReader.Complete();
        }
    }

    public static async IAsyncEnumerable<List<Person>> ReadStreamAsAsyncEnumerable(PipeReader pipeReader, int batchApproximateSize = 1_000)
    {
        ReadResult lastReadResult = default;
        do
        {
            var position = 0;
            var parsedCount = 0;
            
            var items = new List<Person>();
            while (true)
            {
                var result = await pipeReader.ReadAsync();
                lastReadResult = result;
                var buffer = result.Buffer;
                var sequencePosition = ParseLines(items, ref buffer, ref position, ref parsedCount);

                pipeReader.AdvanceTo(sequencePosition, buffer.End);

                if (result.IsCompleted || parsedCount >= batchApproximateSize)
                {
                    break;
                }
            }

            if (lastReadResult.IsCompleted)
            {
                pipeReader.Complete();
                yield return items;
            }

            if (items.Count >= 1000)
            {
                yield return items;
            } 

        } while (!lastReadResult.IsCompleted);
    }

    private static SequencePosition ParseLines(
        List<Person> itemsArray,
        ref ReadOnlySequence<byte> buffer,
        ref int position,
        ref int parsedCount)
    {
        var reader = new SequenceReader<byte>(buffer);

        while (!reader.End)
        {
            if (!reader.TryReadToAny(out ReadOnlySpan<byte> line, NewLine, true))
            {
                break; // we don't have a delimiter (newline) in the current data
            }

            var parsedLine = new Person();
            //itemsArray[position++] = parsedLine;
            itemsArray.Add(parsedLine);
            parsedCount++;
        }

        return reader.Position;
    }
}

public static class CloudFrontParserNew
{
    private static ReadOnlySpan<byte> NewLine => Encoding.UTF8.GetBytes("\r\n");//  "\r\n"u8;

    public static async Task<int> ParseAsync(string filePath, Person[] items)
    {
        var position = 0;

        if (File.Exists(filePath))
        {
            await using var fileStream = File.OpenRead(filePath);

            var pipeReader = PipeReader.Create(fileStream);

            while (true)
            {
                var result = await pipeReader.ReadAsync();

                var buffer = result.Buffer;

                var sequencePosition = ParseLines(items, ref buffer, ref position);

                pipeReader.AdvanceTo(sequencePosition, buffer.End);

                if (result.IsCompleted)
                {
                    break;
                }
            }

            pipeReader.Complete();
        }

        return position;
    }

    private static SequencePosition ParseLines(Person[] itemsArray, 
        ref ReadOnlySequence<byte> buffer, ref int position)
    {
        var reader = new SequenceReader<byte>(buffer);

        while (!reader.End)
        {
            if (!reader.TryReadToAny(out ReadOnlySpan<byte> line, NewLine, true))
            {
                break; // we don't have a delimiter (newline) in the current data
            }

            var parsedLine = LineParser.ParseLine(line); // we have a line to parse

            //if (parsedLine.HasValue) 
                //itemsArray[position++] = parsedLine.Value;
                itemsArray[position++] = parsedLine;
        }

        return reader.Position;
    }

    private static class LineParser
    {
        private const byte Tab = (byte)'\t', Hash = (byte)'#';

        public static Person? ParseLine(ReadOnlySpan<byte> line)
        {
            var str = Encoding.UTF8.GetString(line);
            var lines = str.Split(";");
            return new Person();
        }
    }
}
