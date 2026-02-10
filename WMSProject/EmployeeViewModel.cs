using System.Security.Cryptography.X509Certificates;

namespace WMSProject
{
    /// <summary>
    /// Dolgozó adatok megjelenítéshez (szabadnapkezelés)
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Dolgozó neve
        /// </summary>
        public string Name { get; } = "Nagy Anna";

        /// <summary>
        /// Dolgozó adószáma
        /// </summary>

        public string TaxNumber { get; set; } = "01234567-7-19";

        /// <summary>
        /// Kivett szabadnapok száma
        /// </summary>

        public int DaysOff { get; set; } = 42;
    }
}
