using System.Collections.Generic;

namespace DAL.Interfaces.Entities
{
    public class DataAccessCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<DataAccessProduct> Products { get; set; }
    }
}
