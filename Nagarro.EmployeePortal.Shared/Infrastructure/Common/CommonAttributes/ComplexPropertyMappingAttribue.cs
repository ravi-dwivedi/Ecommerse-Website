using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ComplexPropertyMappingAttribute : Attribute
    {
        public ComplexPropertyMappingAttribute(DTOType DTOType)
        {
            this.DTOType = DTOType;
        }

        public DTOType DTOType;
    }
}
