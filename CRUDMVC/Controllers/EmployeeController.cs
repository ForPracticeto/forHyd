using System.Web.Mvc;
using CRUDMVC.Models;
namespace CRUDMVC.Controllers
{

    public class EmployeeController : Controller
    {

        /// <summary>
        // GET: Employee/GetAllEmpDetails
        /// Get all the employee details
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllEmpDetails()
        {
            ViewBag.Title = "Get All Employee";
            DBOps.DBOps EmpRepo = new DBOps.DBOps();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }

        /// <summary>
        /// GET: Employee/AddEmployee
        /// add employee
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEmployee()
        {
            ViewBag.Title = "Add Employee";
            return View();
        }


        /// <summary>
        ///  POST: Employee/AddEmployee
        /// </summary>
        /// <param name="Emp">object of employee</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DBOps.DBOps EmpRepo = new DBOps.DBOps();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// edit the selected employee
        /// GET: Employee/EditEmpDetails/1
        /// </summary>
        /// <param name="id">id of employee</param>
        /// <returns></returns>
        public ActionResult EditEmpDetails(int id)
        {
            ViewBag.Title = "Edit Employee";
            DBOps.DBOps EmpRepo = new DBOps.DBOps();
            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id));

        }


        /// <summary>
        /// 
        /// POST: Employee/EditEmpDetails/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            try
            {
                DBOps.DBOps EmpRepo = new DBOps.DBOps();

                EmpRepo.UpdateEmployee(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        ///  GET: Employee/DeleteEmp/5
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                DBOps.DBOps EmpRepo = new DBOps.DBOps();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }


    }
}
