using PWMP.Services; 
namespace PWMP;

public partial class MainPage : ContentPage
{
	private readonly FilePickerService _filePickerService;
	public MainPage()
	{
		InitializeComponent();
		_filePickerService = new FilePickerService();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try 
		{ 
			var fileResult = await _filePickerService.PickCsvAsync(); 

			if (fileResult != null) 
			{ 
				Console.WriteLine($"Picked File: {fileResult.FileName}");
			} 
			else 
			{ 
				Console.WriteLine("No File Selected"); 
			}

			FilePath.Text = fileResult.FileName;
		} 
		catch (Exception ex)
		{ 
			Console.WriteLine($"Error: {ex.Message}"); 
			await DisplayAlert("Error", "An Error occured while picking the file within the MainPage.", "OK"); 
		}
	}
}

