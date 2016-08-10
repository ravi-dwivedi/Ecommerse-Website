namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Notice Manager
        /// </summary>
        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.EcommerceManagerBDC")]
        EcommerceManager = 1,

    }
}
