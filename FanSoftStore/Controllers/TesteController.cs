using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FanSoftStore.UI.Controllers
{
    public class TesteController : Controller
    {
        //http://localhost:52515/Teste/Server
        public string Server()
        {
            return $"Bateu Aqui no Server - {DateTime.Now}";
        }
    }
}
