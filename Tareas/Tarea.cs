using System.Text.Json.Serialization;

namespace tarea;

class Tarea
{

    [JsonPropertyName ("userId")]
    public int UserId { get; set; }
    [JsonPropertyName ("id")]
    public int Id { get ; set; }
    [JsonPropertyName ("title")]
    public string? Title { get; set; }
    [JsonPropertyName("completed")]  
    public bool Estado { get; set; }
}