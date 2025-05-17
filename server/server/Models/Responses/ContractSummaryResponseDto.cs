namespace server.Models.Responses
{
    public class ContractSummaryResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public List<ContractDetailsResponseDto> Contracts { get; set; } = new List<ContractDetailsResponseDto>();
        public double TotalValue { get; set; }
        public int MaxDelayDays { get; set; }
    }
}
