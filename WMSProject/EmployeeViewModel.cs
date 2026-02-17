namespace WMSProject
{
    /// <summary>
    /// Dolgozó adatok megjelenítéshez (szabadnapkezelés)
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Szabadnapok száma
        /// </summary>
        private static int VacationDay = 45;
        /// <summary>
        /// Dolgozó neve
        /// </summary>
        public string Name { get; } = "Nagy Anna";

        /// <summary>
        /// Adószám
        /// </summary>
        public string TaxNumber { get; } = "12345678-1-42";

        /// <summary>
        /// Kivett szabadnapok száma
        /// </summary>
        public int DaysOff { get; } = 6;

        /// <summary>
        /// Hátralévő szabadnapok száma
        /// </summary>
        public int RemainingDays => VacationDay - DaysOff;
    }
}
