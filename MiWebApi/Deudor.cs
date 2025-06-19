using System.Text.Json.Serialization;
namespace classDeudor;



public class Deudor
{
    [JsonPropertyName("status")]
    public int Status { get; set; }
    [JsonPropertyName("results")]
    public Results Results { get; set; }

}
public class Results
{
    [JsonPropertyName("identificacion")]
    public long Identificacion { get; set; }
    [JsonPropertyName("denominacion")]
    public string Denominacion { get; set; }
    [JsonPropertyName("periodos")]
    public List<Periodos> Periodos{ get; set; }
    
}
public class Periodos
{
    [JsonPropertyName("periodo")]
    public string Periodo { get; set; }
    [JsonPropertyName("entidades")]
    public List<Entidades> Entidades { get; set; }
}

public class Entidades
{
    [JsonPropertyName("entidad")]
    public string EntidadBancaria { get; set; }
    [JsonPropertyName("situacion")]
    public int Situacion { get; set; }
    [JsonPropertyName("fechaSit1")]
    public string FechaSit1 { get; set; }
    [JsonPropertyName("monto")]
    public float Monto { get; set; }
    [JsonPropertyName("procesoJud")]
    public bool ProcesoJud { get; set; }

}

