using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Data;

namespace Admin;


public partial class AdminController {

    List<string> currentwords = new List<string>();

    private string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "words.json");
    
    public void wordhandler() {

    }

    private void readData() {
        
    }
}