using System.Collections.Concurrent;
using System.Text;

namespace CsvPoc
{
    internal class CsvGenerator
    {
        private const string Separator = ";";

        public static async Task Generate(string path, int batchSize, int totalSize)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using var fs = File.Create(path);
            
            for (int i = totalSize; i > 0; i -= batchSize)
            {
                var entries = PersonBogus.Faker.Generate(batchSize);
                var sb = new StringBuilder();
                foreach (var entry in entries)
                {
                    sb.AppendJoin(Separator,
                        entry.Attribute1,
                        entry.Attribute2,
                        entry.Attribute3,
                        entry.Attribute4,
                        entry.Attribute5,
                        entry.Attribute6,
                        entry.Attribute7,
                        entry.Attribute8,
                        entry.Attribute9,
                        entry.Attribute10,
                        entry.Attribute11,
                        entry.Attribute12,
                        entry.Attribute13,
                        entry.Attribute14,
                        entry.Attribute15
                        );
                        sb.AppendLine();
                }
                var bytes = Encoding.ASCII.GetBytes(sb.ToString());

                await fs.WriteAsync(bytes);
            }
           

            
    
            

        }
    }
}
