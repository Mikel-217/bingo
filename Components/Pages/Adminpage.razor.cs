using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System.Data;
using System.ComponentModel;
using bingo.Components.Pages;

namespace Admin;

public partial class AdminController {
    public NewBingo? data;
    

    public List<string> currentwords { get; set; } = new List<string>();
    public string? deletedWord { get; set; }

    public int? _indexChangeword { get; set; }
    public string? _changedWord{ get; set; }


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
            currentwords.Clear();
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
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    public void deleteword() {
        Console.WriteLine(deletedWord);
        if (currentwords.Contains(deletedWord!)) {
            currentwords.Remove(deletedWord!);
            writeData();
        } else {
            throw new Exception("Word doesnt exist!");
        }
        deletedWord = "";
    }

    public void changeWord() {
        //Todo
    }
    
}
