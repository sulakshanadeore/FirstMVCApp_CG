using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class EmployeeController : Controller
    {

        static List<EmpModel> empList = new List<EmpModel>() { 
        new EmpModel{Empid=1,EmpName="A",Salary=10000 },
        new EmpModel{ Empid=2,EmpName="B",Salary=20000},
        new EmpModel{ Empid=3,EmpName="C",Salary = 10000 },
        new EmpModel{ Empid=4,EmpName="D",Salary=20000 }

        };

        public ActionResult CreateRecord()
        { 
        
        return View();
        }
        [HttpPost]
        public ActionResult CreateRecord(EmpModel model)
        {
            empList.Add(model);
            return RedirectToAction("Index");

        }



        public ActionResult ShowEmpList()
        { 
        ViewBag.empdata=empList;
            return View();
        
        }



        // GET: Employee
        public ActionResult Index()
        {
            return View(empList);
        }
        
      public ActionResult EditEmployee(int id)
        {
            EmpModel empfound=empList.Find(e=>e.Empid==id);
            if (empfound != null) {
               return View(empfound);
           }
            else
            {
                return Content("No employee found");
            }
        }
        [HttpPost]
        public ActionResult EditEmployee(EmpModel empData)
        {
            EmpModel empfound = empList.Find(e => e.Empid == empData.Empid);
            empfound.EmpName=empData.EmpName;
            empfound.Salary=empData.Salary;
            return RedirectToAction("Index");
        }
       public ActionResult OpenBrowser()
        {
            return RedirectPermanent("http://www.google.com");
        }

        public ActionResult FindEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindEmployee(int id)
        {
            if (id > 0 && id < 5)
            {
                EmpModel emp=empList.Find(e=>e.Empid==id);
                return Content($"Name of employeeid={id} is {emp.EmpName} ");
            }
            else
            {
                return Content("Please enter a valid employeeid....");
            }
        }
    }
}