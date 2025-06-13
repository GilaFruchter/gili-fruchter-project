using Newtonsoft.Json;

public class PromptRequestDto
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
    [JsonProperty("prompt1")] 
    public string Prompt1 { get; set; } = null!;
}
