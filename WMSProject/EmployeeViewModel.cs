using System.Security.Cryptography.X509Certificates;

namespace WMSProject
{
    public class EmployeeViewModel
    {
        public string Name { get; } = "Nagy Anna";
        public string TaxNumber { get; set; } = "01234567-7-19";
        public int DaysOff { get; set; } = 44235644;
    }
}
