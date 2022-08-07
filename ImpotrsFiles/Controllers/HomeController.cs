
using ClosedXML.Excel;
using ImpotrsFiles.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImpotrsFiles.Controllers
{
    public class HomeController : Controller
    {
        ContextClass db = new ContextClass();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.data = db.Users.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult Upload(FormCollection formCollection)
        {
            var UserList = new List<User>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    using (var packages = new ExcelPackage(file.InputStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        var currentSheet = packages.Workbook.Worksheets;
                        var Worksheets = currentSheet.First();
                        var onofCol = Worksheets.Dimension.End.Column;
                        var onofRow = Worksheets.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= onofRow; rowIterator++)
                        {
                            var User = new User();
                            User.User_Id = Convert.ToInt32(Worksheets.Cells[rowIterator, 1].Value);
                            User.User_name = Worksheets.Cells[rowIterator, 2].Value.ToString();
                            User.User_Age = Convert.ToInt32(Worksheets.Cells[rowIterator, 3].Value);
                            UserList.Add(User);


                        }




                    }

                }
            }
            using (ContextClass context = new ContextClass())
            {


                foreach (var item in UserList)
                {
                    context.Users.Add(item);


                }
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Export()
        {

            ContextClass db = new ContextClass();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[3] {new DataColumn("User_Id"),
            new DataColumn("User_name"),
            new DataColumn("User_Age")});
            var customer = from user in db.Users.ToList() select user;
            foreach (var item in customer)
            {
                dt.Rows.Add(item.User_Id, item.User_name, item.User_Age);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream() ) {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");

                
                
                }
            }
        }

    }
     }
    
