using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldOne.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldOne.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly HelloWorldDbContext _context;
        public HomeController(HelloWorldDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            //Employee employee = new Employee();
            //employee.ID = 1;
            //employee.Name = "王晓飞";
            //return View(employee);
            var model = new HomePageViewModel();
            
                SQLEmployeeData sqlData = new SQLEmployeeData(_context);
                model.Employees = sqlData.GetAll();
            
            return View(model);
        }
        public IActionResult Detail(int pid,string name)
        {
            Employee employee = new Employee();
            SQLEmployeeData sqlData = new SQLEmployeeData(_context);
           employee = sqlData.Get(pid);
            
            return View(employee);
        }

       
    }
    public class SQLEmployeeData
    {
        private HelloWorldDbContext _context { get; set; }

        public SQLEmployeeData(HelloWorldDbContext context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }
        public Employee Get(int ID)
        {
            return _context.Employees.FirstOrDefault(o=>o.ID==ID);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

    }
    public class HomePageViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
