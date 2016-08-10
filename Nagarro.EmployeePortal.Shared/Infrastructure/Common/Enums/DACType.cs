namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.EcommerceManagerDAC")]
        EcommerceManagerDAC = 1,

    }
}
