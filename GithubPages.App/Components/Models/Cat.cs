using System.Text.Json.Serialization;

namespace GithubPages.App.Components.Models;

public class Cat
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }

    [JsonPropertyName("tags")]
    public string[]? Tags { get; set; }

    [JsonPropertyName("mimetype")]
    public string? MimeType { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("editedAt")]
    public DateTime EditedAt { get; set; }

}
