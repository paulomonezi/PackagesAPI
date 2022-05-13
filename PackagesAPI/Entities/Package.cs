namespace PackagesAPI.Entities
{
    public class Package
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public decimal Weight { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime PostedAt { get; private set; }        
    }

}
