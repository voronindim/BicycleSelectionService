using System.Collections.Generic;

namespace DAL.Entities
{
    public class Specification
    {
        public Specification()
        {
            Bikes = new List<Bike>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Bike> Bikes { get; set; }
    }
}