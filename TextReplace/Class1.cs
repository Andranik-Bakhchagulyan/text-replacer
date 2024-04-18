using System.Text;

namespace TextReplace;

public class Class1
{
    public static void ReplaceAll(string filePath, string string1, string string2)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        string tempFilePath = Path.GetTempFileName(); 

        try
        {
            using (var reader = new StreamReader(filePath, Encoding.ASCII))
            using (var writer = new StreamWriter(tempFilePath, false, Encoding.ASCII))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(string1, string2);
                    writer.WriteLine(line);
                }
            }

            File.Copy(tempFilePath, filePath, true);
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }

    public static void ReplaceFirst(string filePath, string string1, string string2)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        string tempFilePath = Path.GetTempFileName();

        try
        {
            using (var reader = new StreamReader(filePath, Encoding.ASCII))
            using (var writer = new StreamWriter(tempFilePath, false, Encoding.ASCII))
            {
                bool replaced = false;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!replaced && line.Contains(string1))
                    {
                        line = line.Replace(string1, string2);
                        replaced = true;
                    }
                    writer.WriteLine(line);
                }
            }

            if (File.Exists(tempFilePath))
            {
                File.Copy(tempFilePath, filePath, true);
            }
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }
}
