using desktop.Models;
using desktop.Services.Contract;

namespace desktop.Views;

public partial class ContractsView : ContentPage
{

	private readonly IContractService _contractService;
    private int _currentPage = 1;
    private const int PageSize = 10;

    public ContractsView(IContractService contractService)
    {
        _contractService = contractService;
        InitializeComponent();
        LoadContracts();
    }

    private async void OnUploadFileClicked(object sender, EventArgs e)
{
    try
    {
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Selecione o arquivo para upload"
        });

        if (result != null)
        {
            using var stream = await result.OpenReadAsync();

            await _contractService.UploadContractsByFile(stream, result.FileName);

            await DisplayAlert("Sucesso", "Contratos adicionados", "OK");

            _currentPage = 1;
            LoadContracts();
        }
    }
    catch (Exception ex)
    {
        await DisplayAlert("Erro", $"Falha ao enviar arquivo: {ex.Message}", "OK");
    }
}

    private async void LoadContracts()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            ContractsList.IsVisible = false;
            PageLabel.Text = $"Página {_currentPage}";

            var paginateRequest = new PaginateRequest
            {
                PageNumber = _currentPage,
                PageSize = PageSize
            };

            var response = await _contractService.GetAllPaginated(paginateRequest);

            ContractsList.ItemsSource = response;
            ContractsList.IsVisible = true;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro ao carregar os contratos: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadContracts();
    }

    private void OnPreviousPageClicked(object sender, EventArgs e)
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            LoadContracts();
        }
    }

    private void OnNextPageClicked(object sender, EventArgs e)
    {
        _currentPage++;
        LoadContracts();
    }

    private async void OnSearchByCpfClicked(object sender, EventArgs e)
    {
        string cpfStr = await DisplayPromptAsync("Consulta por CPF", "Digite o CPF para consulta:");
        if (string.IsNullOrWhiteSpace(cpfStr))
            return;

        CPF cpf = new CPF();
        cpf.cpf = cpfStr;


        try
        {
            LoadingIndicator.IsVisible = true;
            ContractsList.IsVisible = false;

            var summary = await _contractService.GetSummaryByCpfAsync(cpf);

            if (summary == null)
            {
                await DisplayAlert("Atenção", "Nenhum contrato encontrado para o CPF informado.", "OK");
                return;
            }

            await Navigation.PushModalAsync(new ContractSummaryView(summary));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao consultar CPF: {ex.Message}", "OK");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }
}