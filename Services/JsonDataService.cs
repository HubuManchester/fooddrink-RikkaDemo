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
        if (!File.Exists(_dataFilePath))
        {
            var defaultRecipes = GetDefaultRecipes();
            SaveRecipes(defaultRecipes);
        }
    }

    private List<Recipe> GetDefaultRecipes()
    {
        return new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "经典番茄炒蛋",
                Description = "简单易学的家常菜，色香味俱全",
                ImagePath = "food_1.png",
                Ingredients = new List<string> { "鸡蛋 4个", "番茄 2个", "盐 适量", "糖 1勺", "葱花 适量", "食用油 适量" },
                Instructions = new List<string> { "将番茄洗净切块，鸡蛋打散备用", "热锅倒油，倒入蛋液炒成块盛起", "锅中再倒少许油，放入番茄炒出汁水", "加入炒好的鸡蛋，调入盐和糖", "翻炒均匀，撒上葱花即可出锅" },
                PrepTime = 10,
                CookTime = 15,
                Category = "晚餐",
                Servings = 2,
                Difficulty = "简单",
                Calories = 250,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 2,
                Title = "香煎三文鱼",
                Description = "富含Omega-3的健康美味",
                ImagePath = "food_2.png",
                Ingredients = new List<string> { "三文鱼 200g", "柠檬 半个", "盐 适量", "黑胡椒 适量", "橄榄油 1勺", "迷迭香 1支" },
                Instructions = new List<string> { "三文鱼用厨房纸吸干水分", "两面撒盐和黑胡椒腌制10分钟", "平底锅加热，倒入橄榄油", "放入三文鱼，中小火每面煎3分钟", "最后挤上柠檬汁，放上迷迭香装饰" },
                PrepTime = 15,
                CookTime = 6,
                Category = "晚餐",
                Servings = 1,
                Difficulty = "中等",
                Calories = 350,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 3,
                Title = "香蕉燕麦粥",
                Description = "营养丰富的健康早餐",
                ImagePath = "food_3.png",
                Ingredients = new List<string> { "燕麦片 50g", "牛奶 250ml", "香蕉 1根", "蜂蜜 1勺", "肉桂粉 适量" },
                Instructions = new List<string> { "燕麦片用冷水泡10分钟", "将牛奶和燕麦片倒入小锅，小火煮5分钟", "香蕉切片", "将煮好的燕麦粥盛入碗中", "摆上香蕉片，淋上蜂蜜，撒上肉桂粉" },
                PrepTime = 5,
                CookTime = 5,
                Category = "早餐",
                Servings = 1,
                Difficulty = "简单",
                Calories = 300,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 4,
                Title = "巧克力蛋糕",
                Description = "浓郁香甜的甜点",
                ImagePath = "food_4.png",
                Ingredients = new List<string> { "低筋面粉 100g", "可可粉 30g", "鸡蛋 2个", "牛奶 50ml", "黄油 60g", "糖 80g", "泡打粉 3g" },
                Instructions = new List<string> { "黄油室温软化，加入糖打发", "分次加入蛋液，搅拌均匀", "筛入面粉、可可粉和泡打粉", "加入牛奶，轻柔拌匀", "倒入模具，烤箱180度烤25分钟" },
                PrepTime = 20,
                CookTime = 25,
                Category = "甜点",
                Servings = 6,
                Difficulty = "中等",
                Calories = 280,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 5,
                Title = "芒果冰沙",
                Description = "清爽解暑的夏日饮品",
                ImagePath = "food_5.png",
                Ingredients = new List<string> { "芒果 2个", "酸奶 150ml", "牛奶 100ml", "冰块 适量", "蜂蜜 1勺" },
                Instructions = new List<string> { "芒果去皮去核，取果肉", "将芒果肉、酸奶、牛奶和蜂蜜放入搅拌机", "加入适量冰块", "搅打至顺滑", "倒入杯中即可享用" },
                PrepTime = 5,
                CookTime = 0,
                Category = "饮品",
                Servings = 1,
                Difficulty = "简单",
                Calories = 200,
                IsFavorite = false
            },
            new Recipe
            {
                Id = 6,
                Title = "宫保鸡丁",
                Description = "经典川菜，麻辣鲜香",
                ImagePath = "food_6.png",
                Ingredients = new List<string> { "鸡胸肉 300g", "花生米 50g", "干辣椒 8个", "花椒 1勺", "葱 1根", "姜 2片", "蒜 3瓣", "生抽 2勺", "料酒 1勺", "糖 1勺" },
                Instructions = new List<string> { "鸡胸肉切丁，用料酒、生抽腌制15分钟", "花生米炸至金黄盛起", "热锅冷油，下花椒和干辣椒爆香", "放入鸡丁炒至变色", "加入葱姜蒜和调味料翻炒", "最后加入花生米炒匀即可" },
                PrepTime = 20,
                CookTime = 10,
                Category = "午餐",
                Servings = 2,
                Difficulty = "中等",
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
        await Task.CompletedTask;
        var recipes = LoadRecipes();
        recipe.Id = recipes.Any() ? recipes.Max(r => r.Id) + 1 : 1;
        recipes.Add(recipe);
        SaveRecipes(recipes);
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
        await Task.CompletedTask;
        var recipes = LoadRecipes();
        var recipe = recipes.FirstOrDefault(r => r.Id == id);
        if (recipe != null)
        {
            recipes.Remove(recipe);
            SaveRecipes(recipes);
        }
    }
}