using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DTOPropertyMappingAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappedProperyFullName">Full name of the mapped property type.</param>
        /// <param name="mappingType">Type of the mapping.</param>
        public DTOPropertyMappingAttribute(string mappedProperyFullName, MappingType mappingType)
        {
            // private set value
            this.mappedProperyFullName = mappedProperyFullName;
            this.MappingType = mappingType;
        }

        #endregion

        #region EntityMappingAttribute Members

        /// <summary>
        /// Gets or sets the full name of the mapped entity type.
        /// </summary>
        /// <value>The full name of the mapped entity type.</value>
        public string mappedProperyFullName { get; private set; }

        /// <summary>
        /// Gets or sets the mapping type
        /// </summary>
        public MappingType MappingType { get; private set; }

        #endregion

    }
}
