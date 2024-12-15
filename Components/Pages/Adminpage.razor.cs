using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Data;

namespace Admin;

public partial class AdminController {
    public NewBingo? data;

    private List<string> currentwords = new List<string>();
    private string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "words.json");

    public void wordhandler() {
        if (data?.newWordslist == null || data.newWordslist.Count == 0) {
            Console.WriteLine("Empty");
        }
        else {
            readData();
        }
    }

    private void readData() {
        try {
            string jsonData = File.ReadAllText(path);
            var current = JsonSerializer.Deserialize<Bingodata>(jsonData);
            if (current?.bingoWords != null){
                currentwords = new List<string>(current.bingoWords);
            }
            foreach (var newword in data?.newWordslist!) {
                if (!currentwords.Contains(newword)) {
                    currentwords.Add(newword);
                }
            }
            writeData();
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    private void writeData() {
        try {
            var bingoData = new Bingodata { bingoWords = currentwords };
            string writingData = JsonSerializer.Serialize(bingoData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, writingData);   
            data?.newWordslist.Clear();
            currentwords.Clear();
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}
