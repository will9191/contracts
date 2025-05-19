using desktop.Models;
using desktop.Services.ContractFile;

namespace desktop.Views;

public partial class ContractFilesView : ContentPage
{
    private readonly IContractFileService _contractFileService;
    private int _currentPage = 1;
    private const int PageSize = 10;
    public ContractFilesView(IContractFileService contractFileService)
    {
        _contractFileService = contractFileService;
        InitializeComponent();
        LoadFiles();
    }

    private async void LoadFiles()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            FilesList.IsVisible = false;
            PageLabel.Text = $"Página {_currentPage}";

            var paginateRequest = new PaginateRequest
            {
                PageNumber = _currentPage,
                PageSize = PageSize
            };

            var response = await _contractFileService.GetImportedFilesAsync(paginateRequest);

            FilesList.ItemsSource = response;
            FilesList.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao carregar os arquivos: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnPreviousPageClicked(object sender, EventArgs e)
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            LoadFiles();
        }
    }

    private void OnNextPageClicked(object sender, EventArgs e)
    {
        _currentPage++;
        LoadFiles();
    }
}