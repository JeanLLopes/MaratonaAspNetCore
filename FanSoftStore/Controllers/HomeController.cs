﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FanSoftStore.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
