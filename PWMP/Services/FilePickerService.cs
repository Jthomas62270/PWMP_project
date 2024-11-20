using System;

namespace PWMP.Services;

public class FilePickerService
{
    public async Task<FileResult> PickCsvAsync()
    { 

        var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> 
        {
            { DevicePlatform.iOS, new[] { ".csv" } }, 
            { DevicePlatform.Android, new[] { ".csv" } },
            { DevicePlatform.WinUI, new[] { ".csv"} }, 
            { DevicePlatform.MacCatalyst, new[] {"public.comma-separated-values-text"}},
            { DevicePlatform.macOS, new[] { "public.comma-separated-values-text"}}, 
        }); 

        try 
        { 
            var result = await FilePicker.Default.PickAsync(new PickOptions
            { 
                FileTypes = customFileType,
                PickerTitle = "Select a csv file"
            }); 

            Console.WriteLine($"result = {result}"); 

            return result; 
        }
        catch (PermissionException permEx)
        { 
            Console.WriteLine($"Permission Error: {permEx.Message}"); 
            await Application.Current.MainPage.DisplayAlert("Permission Error", "You do not have permission to pick files. ", "OK"); 
        }
        catch (Exception ex)
        { 
            Console.WriteLine($"Error: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("Error", "An error occurred while picking the file. Please try again", "OK"); 
        }

        return null; 
    }

}
