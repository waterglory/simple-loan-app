using Simple.Loan.App.Contracts.Models.LoanApplication;

namespace Simple.Loan.App.Commons.OrganizationNo
{
    public static class Extensions
    {
        public static string CleanUpOrganizationNo(this string organizationNo)
        {
            organizationNo = organizationNo.Replace("-", string.Empty);
            if (organizationNo.Length > 10)
                organizationNo = organizationNo.Substring(organizationNo.Length - 10);
            return organizationNo;
        }

        public static void CleanUpOrganizationNo(this LoanApplication loanApplication) =>
            loanApplication.Applicant.OrganizationNo = loanApplication.Applicant.OrganizationNo.CleanUpOrganizationNo();
    }
}
