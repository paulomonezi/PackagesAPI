using PackagesAPI.Entities;

namespace PackagesAPI.Persistence
{
    public class DataContext
    {
        public DataContext()
        {
            Packages = new List<Package>();
        }
        public List<Package> Packages { get; set; }

    }
}
