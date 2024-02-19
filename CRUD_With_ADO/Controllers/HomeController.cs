using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CRUD_With_ADO.Models;

namespace CRUD_With_ADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        [HttpGet]
        public ActionResult ShowAll()
        {
            Customer cs = new Customer();
            List<Customer> lst = cs.ShowAllCustomer();
            return View(lst);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer cm)
        {
            string message = string.Empty;
            //To read and upload picture
            HttpPostedFileBase myfile = Request.Files["CustPic"];
            if (myfile != null)
            {
                if(myfile.ContentLength > 0)
                {
                    string ext = myfile.FileName.Substring(myfile.FileName.LastIndexOf('.')).ToUpper();
                    if(ext==".JPG"|| ext==".JPEG"||ext==".PNG")
                    {
                        //upload picture
                        cm.PictueFileName=Path.GetRandomFileName()+myfile.FileName;
                        myfile.SaveAs(Server.MapPath("/Content/UserPics/" + cm.PictueFileName));
                        //To set rest of the properties and save record in database
                        cm.RegisteredOnDT = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        message = cm.AddNewCustomer();
                    }
                    else
                    {
                        message = "Invalid file type.Please choose only jpg,jpeg or png file.";
                    }
                }
                else
                {
                    message = "Please choose a valid picture.";
                }
            }
            else
            {
                message = "Please choose a picture.";
            }
            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult EditCust(int cid)
        {
            Customer cm= new Customer();
            cm=cm.GetSpecificCustomer(cid);
            return View(cm);
        }
        [HttpPost]
        public ActionResult EditCust(Customer cm)
        {
            string message = string.Empty;
            //To read and upload picture
            HttpPostedFileBase myfile = Request.Files["CustPic"];
            if (myfile != null)
            {
                if (myfile.ContentLength > 0)
                {
                    string ext = myfile.FileName.Substring(myfile.FileName.LastIndexOf('.')).ToUpper();
                    if (ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                    {
                        //upload picture
                        cm.PictueFileName = Path.GetRandomFileName() + myfile.FileName;
                        myfile.SaveAs(Server.MapPath("/Content/UserPics/" + cm.PictueFileName));
                        message = cm.UpdateCustomer(cm.CustId);
                    }
                    else
                    {
                        message = "Invalid file type.Please choose only jpg,jpeg or png file.";
                    }
                }
                else
                {
                    message = "Please choose a valid picture.";
                }
            }
            else
            {
                message = "Please choose a picture.";
            }
            TempData["msg"] = message;
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public ActionResult DeleteCust(int cid)
        {
            Customer c=new Customer();
            TempData["msg"]=c.DeleteCustomer(cid);
            return RedirectToAction("ShowAll");
        }
    }
}