using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AWT2Demo.Domain.Repositories;
using AWT2Demo.Domain.Entities;

namespace AWT2Demo.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

    }
}
