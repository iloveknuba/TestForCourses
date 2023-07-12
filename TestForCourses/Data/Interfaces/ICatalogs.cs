using TestForCourses.Data.Models;

namespace TestForCourses.Data.Interfaces
{
    public interface ICatalogs
    {
        public string GetCurrentCatalog(string  catalogsName);
        public List<Catalog> GetChildCatalogs(string catalogsName);
        public string GetParentCatalog(string catalogsName);
        public List<Catalog> GetFullPath(string catalogsName);

        public int GetId(string name);
    }
}
