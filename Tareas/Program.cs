using System;
using System.Text.Json;
using tarea;


HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
response.EnsureSuccessStatusCode();
string? responseBody = await response.Content.ReadAsStringAsync();
List<Tarea>? listTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
Console.WriteLine("Tareas completadas:\n");
foreach (var Prov in listTarea)
{

    if (Prov.Estado == true)
    {
        Console.WriteLine($"userID{Prov.UserId}, Id:{Prov.Id}, title :{Prov.Title}, estado : {Prov.Estado}");
    }
}
Console.WriteLine("Tareas pendientes: \n");

foreach (var Prov in listTarea)
{

    if (Prov.Estado != true)
    {

        Console.WriteLine($"userID{Prov.UserId}, Id:{Prov.Id}, title :{Prov.Title}, estado : {Prov.Estado}");
    }
}

string jsonString = JsonSerializer.Serialize<List<Tarea>>(listTarea);

File.WriteAllText("tareas.json", jsonString);






