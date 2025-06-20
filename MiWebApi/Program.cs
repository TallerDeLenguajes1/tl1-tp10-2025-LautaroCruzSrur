using classDeudor;
using System;
using System.Text.Json;

bool Bandera = true;
List<Deudor> listDeudor = new List<Deudor>();
List<string> infoDeudor = new List<string>();
do
{

    Console.WriteLine("Ingrese su numero de Cuil");
    string cuil = Console.ReadLine() ?? "";
    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync($"https://api.bcra.gob.ar/centraldedeudores/v1.0/Deudas/{cuil}");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    Deudor deudor = JsonSerializer.Deserialize<Deudor>(responseBody);
    Console.WriteLine("\n-------------------------");
    Console.WriteLine("\nDatos del Deudor");
    Console.WriteLine($"\nNombre : {deudor.Results.Denominacion}\n Cuil: {deudor.Results.Identificacion}");
    foreach (var periodos in deudor.Results.Periodos)
    {
        DateTime fecha = DateTime.ParseExact(periodos.Periodo, "yyyyMM", null);
        string formato = fecha.ToString("yy-MM");
        Console.WriteLine($"\n Ultima Actualizacion de la Deuda {formato}");
        foreach (var bancos in periodos.Entidades)
        {

            Console.WriteLine($"\n Entidad : {bancos.EntidadBancaria} \n Situacion :{bancos.Situacion}   Monto : ${bancos.Monto}mil  \n Etapa judicial : {(bancos.ProcesoJud ? "En juicio" : "Sin juicio")}");

            infoDeudor.Add($" Entidad : {bancos.EntidadBancaria}- Situacion :{bancos.Situacion}   Monto : ${bancos.Monto}mil - Etapa judicial : {(bancos.ProcesoJud ? "En juicio" : "Sin juicio")}");
        }
    }
    Console.WriteLine("\n-------------------------");
    listDeudor.Add(deudor);
    Console.WriteLine("Desea Parar (y/n)");
    string pararPrograma = Console.ReadLine() ?? "";
    if (pararPrograma == "y" || pararPrograma != "n")
    {
        Bandera = false;
    }

} while (Bandera);

DateTime FechaHoy = DateTime.Today;
string fechacsv = FechaHoy.ToString("yyyyMMdd__HHmmss");
string jsonStringCsv = JsonSerializer.Serialize<List<string>>(infoDeudor);
string jsonString = JsonSerializer.Serialize<List<Deudor>>(listDeudor);
File.WriteAllText($"deudores{fechacsv}.txt", jsonStringCsv);
File.WriteAllText("deudores.json", jsonString);


