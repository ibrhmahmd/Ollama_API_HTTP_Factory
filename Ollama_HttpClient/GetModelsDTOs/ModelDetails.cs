using System.Text.Json.Serialization;

public class ModelDetails
{

    [JsonPropertyName("format")]
    public string Format { get; set; }


    [JsonPropertyName("family")]
    public string Family { get; set; }


    [JsonPropertyName("families")]
    public List<string>? Families { get; set; }


    [JsonPropertyName("parameter_size")]
    public string Parameter_size { get; set; }


    [JsonPropertyName("quantization_level")]
    public string QuantizationLevel { get; set; }
}