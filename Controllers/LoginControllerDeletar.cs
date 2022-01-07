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
    public class LoginControllerDeletar : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LoginControllerDeletar(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this._configuration = configuration;
            this._hostEnvironment = hostEnvironment;
        }

      

       [HttpPost]
        public IActionResult Logar(string Login, string Senha)
        {
            Util Util = new Util(_configuration);
            DataTable dtbl = new DataTable();
            dtbl = Util.ReturnDataTableSqlServer("SELECT * FROM USUARIOS");
            if (dtbl == null)
            {
                return Json(new {Msg = "Usuário não encontrado! Verifique suas Credenciais!" });
            }
            return Json(new { Msg ="Usuário Logado com Sucesso!"});
        }
    }
}
