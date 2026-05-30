namespace RecipeHub.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new();
    public List<string> Instructions { get; set; } = new();
    public int PrepTime { get; set; }
    public int CookTime { get; set; }
    public string Category { get; set; } = string.Empty;
    public int Servings { get; set; }
    public string Difficulty { get; set; } = string.Empty;
    public double Calories { get; set; }
    public bool IsFavorite { get; set; }
}