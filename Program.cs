using System;
using System.IO;
using System.Threading.Tasks;
class Program
{
    static async Task Main(string[] args)
    {
        string sourceFilePath = @"C:\Users\meyori\Desktop\C#\lab8\lab8\source.txt"; 
        string destinationFilePath = @"C:\Users\meyori\Desktop\C#\lab8\lab8\destination.txt"; 
        try
        {
            await CopyFileAsync(sourceFilePath, destinationFilePath);
            Console.WriteLine("Файл успішно скопійовано.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
    public static async Task CopyFileAsync(string sourceFilePath, string destinationFilePath)
    {
        using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
        using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await destinationStream.WriteAsync(buffer, 0, bytesRead);
            }
        }
    }
}