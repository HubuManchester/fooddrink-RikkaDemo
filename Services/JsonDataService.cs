using Microsoft.Maui;
using RecipeHub.Models;

namespace RecipeHub.Services;

public class JsonDataService : IDataService
{
    private readonly string _dataFilePath;

    public JsonDataService()
    {
        _dataFilePath = Path.Combine(FileSystem.AppDataDirectory, "recipes.json");
        InitializeData();
    }

    private void InitializeData()
    {
        var needsReset = false;

        if (!File.Exists(_dataFilePath))
        {
            var defaultRecipes = GetDefaultRecipes();
            SaveRecipes(defaultRecipes);
        }
        else
        {
            // Check if data contains Chinese characters and needs reset
            var existingRecipes = LoadRecipes();
            foreach (var recipe in existingRecipes)
            {
                if (IsChineseText(recipe.Title) || IsChineseText(recipe.Description))
                {
                    needsReset = true;
                    break;
                }
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (IsChineseText(ingredient))
                    {
                        needsReset = true;
                        break;
                    }
                }
                if (needsReset) break;
                foreach (var instruction in recipe.Instructions)
                {
                    if (IsChineseText(instruction))
                    {
                        needsReset = true;
                        break;
                    }
                }
                if (needsReset) break;
            }

            if (needsReset)
            {
                File.Delete(_dataFilePath);
                var defaultRecipes = GetDefaultRecipes();
                SaveRecipes(defaultRecipes);
            }
        }
    }

    private bool IsChineseText(string text)
    {
        foreach (char c in text)
        {
            if (c >= 0x4e00 && c <= 0x9fff)
            {
                return true;
            }
        }
        return false;
    }

    private List<Recipe> GetDefaultRecipes()
    {
        return new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Classic Tomato Scrambled Eggs",
                Description = "Simple and delicious home-style dish",
                ImagePath = "food_1.png",
                Ingredients = new List<string> { "Eggs 4", "Tomatoes 2", "Salt to taste", "Sugar 1 tbsp", "Green onions to taste", "Cooking oil to taste" },
                Instructions = new List<string> { "Wash and chop tomatoes, beat eggs", "Heat oil, add eggs and cook until set", "Add more oil, stir-fry tomatoes until juicy", "Add cooked eggs, season with salt and sugar", "Stir well, garnish with green onions and serve" },
                PrepTime = 10,
                CookTime = 15,
                Category = "Dinner",
                Servings = 2,
                Difficulty = "Easy",
                Calories = 250,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 2,
                Title = "Pan-Seared Salmon",
                Description = "Healthy and delicious, rich in Omega-3",
                ImagePath = "food_2.png",
                Ingredients = new List<string> { "Salmon 200g", "Lemon half", "Salt to taste", "Black pepper to taste", "Olive oil 1 tbsp", "Rosemary 1 sprig" },
                Instructions = new List<string> { "Pat salmon dry with paper towels", "Season with salt and pepper, marinate 10 minutes", "Heat pan, add olive oil", "Pan-sear salmon 3 minutes per side over medium heat", "Squeeze lemon juice, garnish with rosemary" },
                PrepTime = 15,
                CookTime = 6,
                Category = "Dinner",
                Servings = 1,
                Difficulty = "Medium",
                Calories = 350,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 3,
                Title = "Banana Oatmeal",
                Description = "Nutritious and healthy breakfast",
                ImagePath = "food_3.png",
                Ingredients = new List<string> { "Oats 50g", "Milk 250ml", "Banana 1", "Honey 1 tbsp", "Cinnamon to taste" },
                Instructions = new List<string> { "Soak oats in cold water for 10 minutes", "Combine oats and milk in pot, simmer 5 minutes", "Slice banana", "Transfer oatmeal to bowl", "Top with banana slices, drizzle honey, sprinkle cinnamon" },
                PrepTime = 5,
                CookTime = 5,
                Category = "Breakfast",
                Servings = 1,
                Difficulty = "Easy",
                Calories = 300,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 4,
                Title = "Chocolate Cake",
                Description = "Rich and sweet dessert",
                ImagePath = "food_4.png",
                Ingredients = new List<string> { "Cake flour 100g", "Cocoa powder 30g", "Eggs 2", "Milk 50ml", "Butter 60g", "Sugar 80g", "Baking powder 3g" },
                Instructions = new List<string> { "Cream softened butter with sugar", "Add eggs one at a time, mix well", "Sift flour, cocoa powder, and baking powder", "Add milk, fold gently", "Pour into mold, bake at 180°C for 25 minutes" },
                PrepTime = 20,
                CookTime = 25,
                Category = "Dessert",
                Servings = 6,
                Difficulty = "Medium",
                Calories = 280,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 5,
                Title = "Mango Smoothie",
                Description = "Refreshing summer drink",
                ImagePath = "food_5.png",
                Ingredients = new List<string> { "Mangoes 2", "Yogurt 150ml", "Milk 100ml", "Ice cubes to taste", "Honey 1 tbsp" },
                Instructions = new List<string> { "Peel and pit mangoes, get fruit flesh", "Add mango, yogurt, milk, and honey to blender", "Add ice cubes", "Blend until smooth", "Pour into glass and enjoy" },
                PrepTime = 5,
                CookTime = 0,
                Category = "Drink",
                Servings = 1,
                Difficulty = "Easy",
                Calories = 200,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 6,
                Title = "Kung Pao Chicken",
                Description = "Classic Sichuan dish, spicy and fragrant",
                ImagePath = "food_6.png",
                Ingredients = new List<string> { "Chicken breast 300g", "Peanuts 50g", "Dried chilies 8", "Sichuan peppercorns 1 tbsp", "Green onion 1", "Ginger 2 slices", "Garlic 3 cloves", "Soy sauce 2 tbsp", "Cooking wine 1 tbsp", "Sugar 1 tbsp" },
                Instructions = new List<string> { "Cut chicken into cubes, marinate with wine and soy sauce 15 minutes", "Fry peanuts until golden", "Heat oil, add peppercorns and chilies", "Add chicken, stir-fry until cooked", "Add aromatics and seasonings, stir-fry", "Add peanuts, mix well and serve" },
                PrepTime = 20,
                CookTime = 10,
                Category = "Lunch",
                Servings = 2,
                Difficulty = "Medium",
                Calories = 400,
                IsFavorite = false
            }
        };
    }

    private void SaveRecipes(List<Recipe> recipes)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(recipes);
        File.WriteAllText(_dataFilePath, json);
    }

    private List<Recipe> LoadRecipes()
    {
        var json = File.ReadAllText(_dataFilePath);
        return System.Text.Json.JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        await Task.CompletedTask;
        return LoadRecipes();
    }

    public async Task<Recipe?> GetRecipeByIdAsync(int id)
    {
        await Task.CompletedTask;
        var recipes = LoadRecipes();
        return recipes.FirstOrDefault(r => r.Id == id);
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        try
        {
            await Task.CompletedTask;
            var recipes = LoadRecipes();
            recipe.Id = recipes.Any() ? recipes.Max(r => r.Id) + 1 : 1;
            recipes.Add(recipe);
            SaveRecipes(recipes);
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", $"Failed to add recipe: {ex.Message}", "OK");
            throw;
        }
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        await Task.CompletedTask;
        var recipes = LoadRecipes();
        var index = recipes.FindIndex(r => r.Id == recipe.Id);
        if (index != -1)
        {
            recipes[index] = recipe;
            SaveRecipes(recipes);
        }
    }

    public async Task DeleteRecipeAsync(int id)
    {
        try
        {
            await Task.CompletedTask;
            var recipes = LoadRecipes();
            var recipe = recipes.FirstOrDefault(r => r.Id == id);
            if (recipe != null)
            {
                recipes.Remove(recipe);
                SaveRecipes(recipes);
            }
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("Error", $"Failed to delete recipe: {ex.Message}", "OK");
            throw;
        }
    }
}