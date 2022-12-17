namespace Simple.Loan.App.Contracts.Service.Models
{
    public class File
    {
        public string FileRef { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public string FileType { get; set; }
    }
}
