using classDeudor;
using System;
using System.Text.Json;

bool Bandera = true;
do
{

    Console.WriteLine("Ingrese su numero de Cuil");
    string cuil = Console.ReadLine() ?? "";
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync($"https://api.bcra.gob.ar/centraldedeudores/v1.0/Deudas/{cuil}");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    Deudor deudor = JsonSerializer.Deserialize<Deudor>(responseBody);
    Console.WriteLine("Desea Parar (y/n)");
    string pararPrograma = Console.ReadLine() ?? "";
    if (pararPrograma == "y" || pararPrograma != "n")
    {
    Bandera = false;
    }
    
} while (Bandera);

//List<Deudor> listDeudor = ;


//string jsonString = JsonSerializer.Serialize<List<Deudor>>(listDeudor);

//File.WriteAllText("deudores.json", jsonString);