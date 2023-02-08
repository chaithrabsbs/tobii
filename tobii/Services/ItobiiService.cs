using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using tobii.Controllers;

namespace tobii.Services
{
    public interface ItobiiService
    {
         ActionResult Index();
         ActionResult Create();
         ActionResult Create(ProductList list);
         ActionResult Edit(int id);
         ActionResult Edit(ProductList list);
         ActionResult Delete(int id);
         ActionResult Delete(ProductList product);
    }
}
