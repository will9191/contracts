namespace server.Models.Responses
{
    public class ContractDetailsResponseDto
    {
        public int ContractNumber { get; set; }
        public string Product { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public double Value { get; set; }
    }
}
