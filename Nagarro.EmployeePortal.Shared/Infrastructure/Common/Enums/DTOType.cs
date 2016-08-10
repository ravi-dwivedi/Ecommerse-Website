namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Notice DTO
        /// </summary>
        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.SubCategoriesDTO")]
        SubCategory = 1,

        /// <summary>
        /// Employee DTO
        /// </summary>
        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.ItemDTO")]
        Item = 2,

        /// <summary>
        /// Employee DTO
        /// </summary>
        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.CategoriesDTO")]
        Category = 3,

       

        
    }
}
