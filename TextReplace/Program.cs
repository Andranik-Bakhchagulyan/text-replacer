using TextReplace;

internal class Program
{
    private static void Main(string[] args)
    {

        string filePath = "C://Users//andoo//Desktop//New Text Document.txt";
        string string1 = "text"; 
        string string2 = "text1"; 


        try
        {
            Class1.ReplaceFirst(filePath, string1, string2);
            Console.WriteLine("OK.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Message: {ex.Message}");
        }

    }


}