namespace RecipeHub.Services;

public interface IHardwareService
{
    Task StartAccelerometerAsync(Action shakeAction);
    Task StopAccelerometerAsync();
    Task<string?> TakePhotoAsync();
    Task SpeakAsync(string text);
    Task StopSpeakingAsync();
    Task InitializeAsync();
}