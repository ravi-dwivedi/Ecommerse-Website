using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public static class Messages
    {
        public const String SelectAnOption = "  1. Add Category 2. Add SubCategory 3. Add Item" +
                                             "\n  4. Remove Category 5. Remove SubCategory 6. Remove Item" +
                                             "\n  7. Edit Category 8. Edit SubCategory 9. Edit Item" +
                                             "\n  10. Get All Categories";
        public const String invalidInput = "Invalid input. Please try again";
        public const String invalidOption = "Invalid option. Please try again";
    }
}
