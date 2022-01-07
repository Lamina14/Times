using MasterTimesContext.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MasterTimesContext.Services;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace Times.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LoginController(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            this._configuration = configuration;
            this._hostEnvironment = hostEnvironment;
        }

        //Get : Login
        //public IActionResult Index()
        //{
            [HttpPost]
            public async Task<IActionResult> Logar(string Nome, string Senha)
            {
                Util Util = new Util(_configuration);
                DataTable dtbl = new DataTable();
            //dtbl = Util.ReturnDataTableSqlServer($"SELECT * FROM USUARIOS WHERE Nome = '{Nome}' AND Senha = '{Senha}'");
            dtbl.CommandText = $"SELECT * FROM USUARIOS WHERE Nome = '{Nome}' AND Senha = '{Senha}'";
                return View(dtbl);
                //return View();
            }
        //}
    }


    
}

/*
       
        [HttpPost]
        public async Task<IActionResult> Logar(string Nome, string Senha)
        {
            SqlConnection sqlConnection = new SqlConnection("data source=DESKTOP-NFMF4B4;initial catalog=ADOTIMES;user id=sa;password=123456789;integrated security=false;packet size=4096;Connection Lifetime=0;MultipleActiveResultSets=true;Connect Timeout=60;");
            await sqlConnection.OpenAsync();

            DataTable sqlCommand = new DataTable();
            sqlCommand.CommandText = $"SELECT * FROM USUARIOS WHERE Nome = '{Nome}' AND Senha = '{Senha}'";
            // sqlCommand.CommandText = $"SELECT * FROM USUARIOS WHERE Nome = '{Nome}' AND Senha = '{Senha}'";

            if (sqlCommand == null)
            {
                return Json(new { Msg = "Usuário não encontrado! Verifique suas Credenciais!" });
            }

            return Json(new { Msg = "Usuário Logado com Sucesso!" });
        }
    }
}

        */

/*
private readonly IConfiguration _configuration;
private readonly IWebHostEnvironment _hostEnvironment;

public PaginaLoginController(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
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
        return Json(new { Msg = "Usuário não encontrado! Verifique suas Credenciais!" });
    }
    return Json(new { Msg = "Usuário Logado com Sucesso!" });
}
*/


