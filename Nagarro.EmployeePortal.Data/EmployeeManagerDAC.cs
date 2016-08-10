using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.EntityDataModel;

namespace Nagarro.EmployeePortal.Data
{
    public class EmployeeManagerDAC : DACBase, IEmployeeManagerDAC
    {
        public EmployeeManagerDAC()
            :base(DACType.EmployeeManagerDAC)
        {

        }

        public int AddEmployee(IEmployeeDTO employeeDTO, ISecurityDTO securityDTO)
        {
            int retVal = default(int);

            using(EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    Employee employee = new Employee();
                    employee.EmployeeCode = employeeDTO.EmployeeCode;
                    employee.FirstName = employeeDTO.FirstName;
                    employee.LastName = employeeDTO.LastName;
                    employee.Email = employeeDTO.Email;
                    employee.DOB = employeeDTO.DOB;
                    employee.DateOfJoining = employeeDTO.DateOfJoining;
                    employee.DepartmentId = employeeDTO.DepartmentId;
                    Employee addedEmployee = employeePortalEntities.Employees.Add(employee);

                    Login login = new Login();
                    var departmentEntity = employeePortalEntities.Departments.FirstOrDefault(department => department.DepartmentId == employeeDTO.DepartmentId);
                    login.Role = (departmentEntity.DepartmentName.Equals("Administration")) ? "A" : "U";
                    login.LoginName = securityDTO.LoginName;
                    login.Password = securityDTO.Password;
                    login.EmployeeId = addedEmployee.EmployeeId;
                    employeePortalEntities.Logins.Add(login);

                    employeePortalEntities.SaveChanges();
                    retVal = addedEmployee.EmployeeId;
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }

            return retVal;
        }

        public IList<IEmployeeDTO> GetAllEmployees()
        {
            IList<IEmployeeDTO> employeeDTOList = null;
            using (EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    var employeeEntityList = employeePortalEntities.Employees;
                    if (employeeEntityList != null)
                    {
                        employeeDTOList = new List<IEmployeeDTO>();

                        foreach (var employee in employeeEntityList)
                        {
                            IEmployeeDTO employeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.Employee);
                            EntityConverter.FillDTOFromEntity(employee, employeeDTO);
                            employeeDTOList.Add(employeeDTO);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return employeeDTOList;
        }

        public bool UpdateEmployee(IEmployeeDTO employeeDTO)
        {
            bool retVal = false;
            using (EmployeePortalEntities employeePortalEntities = new EmployeePortalEntities())
            {
                try
                {
                    var employeeEntity = employeePortalEntities.Employees.FirstOrDefault(employee => employee.EmployeeId == employeeDTO.EmployeeId);
                    if (employeeEntity != null)
                    {
                        employeeEntity.FirstName = employeeDTO.FirstName;
                        employeeEntity.LastName = employeeDTO.LastName;
                        employeeEntity.Email = employeeDTO.Email;
                        employeePortalEntities.SaveChanges();
                        retVal = true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message, ex);
                }
            }
            return retVal;
        }

        public IList<IEmployeeDTO> SearchEmployees(IEmployeeDTO emoloyeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
