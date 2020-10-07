using EmployeeManager.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Api.Repositories
{
    public class EmployeeStProcRepository : IEmployeeRepository
    {
        private readonly AppDbContext db = null;

        public EmployeeStProcRepository(AppDbContext db)
        {
            this.db = db;
        }

        public void Insert(Employee emp)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@FirstName", emp.FirstName);
            p[1] = new SqlParameter("@LastName", emp.LastName);
            p[2] = new SqlParameter("@Title", emp.Title);
            p[3] = new SqlParameter("@BirthData", emp.BirthDate);
            p[4] = new SqlParameter("@HireDate", emp.HireDate);
            p[5] = new SqlParameter("@Country", emp.Country);
            p[6] = new SqlParameter("@Notes", emp.Notes);
            p[7] = new SqlParameter("@EmployeeID", SqlDbType.Int);
            p[7].Direction = ParameterDirection.Output;

            int count = db.Database.ExecuteSqlRaw("EXEC Employees_Insert " +
                "@FirstName,@LastName,@Title,@BirthDate," +
                "@HireDate,@Country,@Notes,@EmployeeID OUT", p);
        }

        public List<Employee> SelectAll()
        {
            List<Employee> data = db.Employees.FromSqlRaw("EXEC Employees_SelectAll").ToList();
            return data;
        }

        public Employee SelectByID(int id)
        {
            SqlParameter p = new SqlParameter("@EmployeeID", id);
            Employee emp = db.Employees.FromSqlRaw("EXEC Employees_SelectByID @EmployeeID", p).ToList().SingleOrDefault();
            return emp;
        }

        public void Update(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
