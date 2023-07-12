using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestForCourses.Data.Interfaces;
using TestForCourses.Data.Models;
using TestForCourses.ViewModels;

namespace TestForCourses.Controllers.Catalogs
{
    public class CatalogsController : Controller
    {

        private readonly ICatalogs _catalogs;

        public CatalogsController(ICatalogs catalog)
        {
            _catalogs = catalog;
        }

        [Route("Catalogs/CatalogsList")]
        [Route("Catalogs/CatalogsList/{name}")]
        public IActionResult CatalogsList(string name)
        {
           
                CatalogsViewModel catalogsViewModel = new CatalogsViewModel();
          

            catalogsViewModel.CurrentCatalogsName = _catalogs.GetCurrentCatalog(name);
           
                catalogsViewModel.ChildCatalogs = _catalogs.GetChildCatalogs(name);
                catalogsViewModel.ParentCatalogName = _catalogs.GetParentCatalog(name);

                catalogsViewModel.CurrentId = _catalogs.GetId(catalogsViewModel.CurrentCatalogsName);
                return View(catalogsViewModel);
            
           
        }


    }
}
