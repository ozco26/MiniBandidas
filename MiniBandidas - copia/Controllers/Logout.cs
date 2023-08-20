﻿using MiniBandidas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MiniBandidas.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult LogOff()
        {
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Login");
        }
    }
}
