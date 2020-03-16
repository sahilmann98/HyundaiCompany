using HyundaiCompany.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HyundaiCompany.MVC.Controllers
{
    public class CarController : Controller
    {
        // GET: Car info from database
        public ActionResult Index()
        {
            IEnumerable<CarModel> carList;
            HttpResponseMessage response = GlobalFile.Client.GetAsync("CarMasters").Result;
            carList = response.Content.ReadAsAsync<IEnumerable<CarModel>>().Result;
            return View(carList);
        }
        [HttpGet]
        public ActionResult SaveAndUpdate(int id = 0)
        {
            // GET: Car info update and save method
            if (id == 0)
                return View(new CarModel());
            else
            {
                HttpResponseMessage response = GlobalFile.Client.GetAsync("CarMasters/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<CarModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult SaveAndUpdate(CarModel wnModel)
        {
            // car model save and updation coding here
            if (wnModel.ID == 0)
            {
                HttpResponseMessage response = GlobalFile.Client.PostAsJsonAsync("CarMasters", wnModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalFile.Client.PutAsJsonAsync("CarMasters/" + wnModel.ID, wnModel).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            // for deleting the values from the databse
            HttpResponseMessage response = GlobalFile.Client.DeleteAsync("CarMasters/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}