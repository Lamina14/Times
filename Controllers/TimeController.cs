using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MasterTimesContext.Models;
using MasterTimesContext.Services;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace MasterTimesContext.Controllers
{
    public class TimeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TimeController(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this._configuration = configuration;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Times
        public IActionResult Index()
        {
            Util Util = new Util(_configuration);
            DataTable dtbl = new DataTable();
            dtbl = Util.ReturnDataTableSqlServer("SELECT * FROM Times");
            return View(dtbl);
        }

        // GET: Times/AddOrEdit/
        public IActionResult AddOrEdit(int? id)
        {
            TimeViewModel TimeViewModel = new TimeViewModel();
            if (id > 0)
            {
                TimeViewModel = FetchBookByID(id);
            }
            return View(TimeViewModel);
        }

        // POST: Time/AddOrEdit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id,[Bind("TimeId,Time,Estado,Cores,Tecnico,Image")] TimeViewModel TimeViewModel)
        {
            if (ModelState.IsValid)
            {
                 

                Util Util = new Util(_configuration);
                if (id > 0)
                {
                    Util.ExecuteSqlSqlServer("UPDATE [dbo].[Times] SET [Time] = '" + TimeViewModel.Time + "' ,[Estado] = '" + TimeViewModel.Estado + "',[Cores] = '" + TimeViewModel.Cores + "',[Tecnico] = '" + TimeViewModel.Tecnico + "'[Imagem] = '" + TimeViewModel.Image + "' WHERE TimeId = 0" + id);
                }
                else
                {
                    Util.ExecuteSqlSqlServer("INSERT INTO [dbo].[Times] ([Time] ,[Estado] ,[Cores],[Tecnico],[Image])  VALUES ('" + TimeViewModel.Time + "', '" + TimeViewModel.Estado + "', '" + TimeViewModel.Cores + "','"+ TimeViewModel.Tecnico+ "','" + TimeViewModel.Image + "')");
                }

                //Save image to wwwroot/image
                string wwwroot = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(TimeViewModel.ImageFile.FileName);
                string extension = Path.GetExtension(TimeViewModel.ImageFile.FileName);
                TimeViewModel.Image = fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                string path = Path.Combine(wwwroot + "/Image/", fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await TimeViewModel.ImageFile.CopyToAsync(fileStream);
                }

                //Insert Record
               // _configuration.Add(TimeViewModel);
                //await _configuration.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(TimeViewModel);
        }

        // GET: Time/Delete/
        public IActionResult Delete(int? id)
        {
            TimeViewModel TimeViewModel = FetchBookByID(id);
            return View(TimeViewModel);
        }

        // POST: Time/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       

        [NonAction]
        public TimeViewModel FetchBookByID(int? id)
        {
            Util Util = new Util(_configuration);
            TimeViewModel TimeViewModel = new TimeViewModel();
            DataTable dtbl = new DataTable();
            dtbl = Util.ReturnDataTableSqlServer("SELECT * FROM Times WHERE TimeId = 0" + id);
            if (dtbl.Rows.Count == 1)
            {
                TimeViewModel.Timeid = Convert.ToInt32(dtbl.Rows[0]["Timeid"].ToString());
                TimeViewModel.Time = dtbl.Rows[0]["Time"].ToString();
                TimeViewModel.Estado = dtbl.Rows[0]["Estado"].ToString();
                TimeViewModel.Cores = dtbl.Rows[0]["Cores"].ToString();
                TimeViewModel.Tecnico = dtbl.Rows[0]["Tecnico"].ToString();
                TimeViewModel.Image = dtbl.Rows[0]["Image"].ToString();
                
            }
            return TimeViewModel;
        }

    }
}
