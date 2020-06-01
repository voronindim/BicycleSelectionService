using System.Collections.Generic;

namespace DAL.Entities
{
    public class Bike
    {
        public Bike()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double MaxSpeed { get; set; }
        public double CarCapacity { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public string Description { get; set; }
        public Attachment Attachment { get; set; }
        public Specification Specification { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
