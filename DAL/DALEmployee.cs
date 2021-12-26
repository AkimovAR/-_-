using motoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace motoStore.DAL
{
    class DALEmployee
    {
        MotoContext context;
        public DALEmployee()
        {
            context = new MotoContext();
        }

        public void Add(Employee emp)
        {

            try
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public List<Employee> ShowALL()
        {

            List<Employee> employees = new List<Employee>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    employees = ctx.Employees.ToList<Employee>();
                }
                catch
                {
                    employees = null;
                }
            }
            return employees;
        }
        public Employee Show(int Id)
        {
            Employee employee = new Employee();
            try
            {
                employee = context.Employees.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                employee = null;
            }
            return employee;
        }
        public bool Edit(Employee entity)
        {
            try
            {
                Employee employee = context.Employees.FirstOrDefault(n => n.Id == entity.Id);
                employee.Id = entity.Id;
                employee.Motoshop_code = entity.Motoshop_code;
                employee.Name = entity.Name;
                employee.Password = entity.Password;
                employee.Post = entity.Post;
                employee.Salary = entity.Salary;
                employee.Surname = entity.Surname;
                employee.Account = entity.Account;
                employee.Email = entity.Email;
                employee.Empaddress = entity.Empaddress;
                employee.Emppassport = entity.Emppassport;
                employee.Empphonenumber = entity.Empphonenumber;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remove(int model)
        {
            try
            {
                Employee employee = context.Employees.FirstOrDefault(n => n.Id == model);
                context.Employees.Remove(employee);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
