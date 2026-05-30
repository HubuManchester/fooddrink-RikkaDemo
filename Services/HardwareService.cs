using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Media;
using System.Collections.ObjectModel;

namespace RecipeHub.Services;

public class HardwareService : IHardwareService
{
    private bool _isAccelerometerRunning;
    private DateTime _lastShakeTime;
    private readonly double _shakeThreshold = 2.5;
    private readonly TimeSpan _shakeDebounce = TimeSpan.FromMilliseconds(500);

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    public async Task StartAccelerometerAsync(Action shakeAction)
    {
        if (_isAccelerometerRunning)
        {
            return;
        }

        _isAccelerometerRunning = true;

        try
        {
            if (Accelerometer.Default.IsMonitoring)
            {
                Accelerometer.Default.ReadingChanged += OnAccelerometerReadingChanged;
            }
            else
            {
                Accelerometer.Default.ReadingChanged += OnAccelerometerReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
        }
        catch (FeatureNotSupportedException)
        {
            await Application.Current!.MainPage!.DisplayAlert("提示", "此设备不支持加速度计", "确定");
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"加速度计启动失败: {ex.Message}", "确定");
        }

        void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
        {
            var now = DateTime.Now;
            if (now - _lastShakeTime < _shakeDebounce)
            {
                return;
            }

            var acceleration = e.Reading;
            var totalAcceleration = Math.Sqrt(
                acceleration.Acceleration.X * acceleration.Acceleration.X +
                acceleration.Acceleration.Y * acceleration.Acceleration.Y +
                acceleration.Acceleration.Z * acceleration.Acceleration.Z
            );

            if (totalAcceleration > _shakeThreshold)
            {
                _lastShakeTime = now;
                MainThread.BeginInvokeOnMainThread(shakeAction);
            }
        }
    }

    public async Task StopAccelerometerAsync()
    {
        if (!_isAccelerometerRunning)
        {
            return;
        }

        _isAccelerometerRunning = false;

        try
        {
            Accelerometer.Default.Stop();
            Accelerometer.Default.ReadingChanged -= OnAccelerometerReadingChanged;
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"加速度计停止失败: {ex.Message}", "确定");
        }
    }

    private void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
    }

    public async Task<string?> TakePhotoAsync()
    {
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await Application.Current!.MainPage!.DisplayAlert("错误", "此设备不支持拍照", "确定");
                return null;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo == null)
            {
                return null;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            return newFile;
        }
        catch (PermissionException)
        {
            await Application.Current!.MainPage!.DisplayAlert("权限错误", "请授予相机权限", "确定");
            return null;
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"拍照失败: {ex.Message}", "确定");
            return null;
        }
    }

    public async Task SpeakAsync(string text)
    {
        try
        {
            await TextToSpeech.Default.SpeakAsync(text, new SpeechOptions());
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"语音播放失败: {ex.Message}", "确定");
        }
    }

    public async Task StopSpeakingAsync()
    {
        try
        {
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"停止语音失败: {ex.Message}", "确定");
        }
    }
}