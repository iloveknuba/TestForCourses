using System.Linq;
using TestForCourses.Data.Interfaces;
using TestForCourses.Data.Models;

namespace TestForCourses.Data.Mocks
{
    public class MockCatalogs : ICatalogs
    {
        private readonly CatalogDBContext _dbContext;

        public MockCatalogs(CatalogDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetCurrentCatalog(string catalogsName)
        {
            int catalogId = GetId(catalogsName);

            var catalog = _dbContext.Catalogs.FirstOrDefault(c => c.Id == catalogId);

            return catalog != null ? catalog.Name : _dbContext.Catalogs.FirstOrDefault(c => c.Id == 1).Name;

        }
        public int GetId(string name)
        {
            var catalog = _dbContext.Catalogs.FirstOrDefault(c => c.Name == name);
            return catalog != null ? catalog.Id : 1;
        }
      
        public List<Catalog> GetChildCatalogs(string name)
        {

            int catalogId = GetId(name);
           
                var childIds = _dbContext.Paths
                    .Where(p => p.AncestorId == catalogId && p.Depth == 1)
                    .Select(p => p.DescendantId)
                    .ToList();
                
                var childCatalogs = _dbContext.Catalogs
                    .Where(c => childIds.Contains(c.Id))
                    .ToList();

                return childCatalogs;
            
        }

        public List<Catalog> GetFullPath(string name)
        {
            int catalogId = GetId(name);

                var pathIds = _dbContext.Paths
                    .Where(p => p.DescendantId == catalogId)
                    .OrderByDescending(p => p.Depth)
                    .Select(p => p.AncestorId)
                    .ToList();

                var pathCatalogs = _dbContext.Catalogs
                    .Where(c => pathIds.Contains(c.Id))
                    .ToList();

                return pathCatalogs;
            

        }

        public string GetParentCatalog(string catalogsName)
        {
            int catalogId = GetId(catalogsName);

            var parentPath = _dbContext.Paths
                    .FirstOrDefault(p => p.DescendantId == catalogId && p.Depth == 1);

                if (parentPath != null)
                {
                    var parentCatalog = _dbContext.Catalogs
                        .FirstOrDefault(c => c.Id == parentPath.AncestorId);

                    return parentCatalog.Name;
                }

                return null;
            
        }
    }
}
