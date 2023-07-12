using System.Text;
using TestForCourses.Data.Models;

namespace TestForCourses.ViewModels
{
    public class CatalogsViewModel
    {
        public string? CurrentUrl { get; set; }
        public string? CurrentCatalogsName { get; set; }

        public string? ParentCatalogName { get; set; }
        public List<Catalog>? ChildCatalogs { get; set; }

        public int CurrentId { get; set; }
    }
}
