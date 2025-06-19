using classUsuario;
using System;
using System.Text.Json;



HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode();
string? responseBody = await response.Content.ReadAsStringAsync();
List<Usuario>? listUsuario = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

for (int i = 0; i < Math.Min(5, listUsuario.Count); i++)
{
    var usuario = listUsuario[i];
    Console.WriteLine($"Nombre: {usuario.Name}");
    Console.WriteLine($"Email: {usuario.Email}");
    Console.WriteLine($"Domicilio: {usuario.Address.Street}, {usuario.Address.Suite}, {usuario.Address.City}");
    Console.WriteLine("--------------------------------------------------");
}



string jsonString = JsonSerializer.Serialize<List<Usuario>>(listUsuario);

File.WriteAllText("usuarios.json", jsonString);