using System.Collections.Generic;
using BLL.DTO.DTOResults;
using BLL.Interfaces;
using DAL;

namespace BLL.Services
{
    public class SpecificationsService : ISpecificationService
    {
        private readonly DBContext _context;

        public SpecificationsService(DBContext context)
        {
            _context = context;
        }

        public List<SpecificationResult> GetSpecifications()
        {
            var result = new List<SpecificationResult>();
            
            foreach (var specification in _context.Specifications)
            {
                result.Add(new SpecificationResult()
                {
                    Id = specification.Id,
                    Name = specification.Name
                });
            }

            return result;
        }
        
    }
}