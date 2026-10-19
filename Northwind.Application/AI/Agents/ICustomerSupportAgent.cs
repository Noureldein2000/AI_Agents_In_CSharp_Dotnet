namespace Northwind.Application.AI.Agents
{
    public interface ICustomerSupportAgent
    {
        Task<string> AskAsync(
            string message,
            CancellationToken cancellationToken = default);
        Task<string> ExecuteFlowAsync(string requirement,CancellationToken cancellationToken = default);
    }
}
