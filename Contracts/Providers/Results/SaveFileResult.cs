namespace Simple.Loan.App.Contracts.Providers.Results
{
    public class SaveFileResult
    {
        public bool Conflict { get; set; }
        public string FileRef { get; set; }
    }
}
