using System.Collections.Generic;
using BLL.DTO.DTOResults;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ISpecificationService
    {
        List<SpecificationResult> GetSpecifications();
    }
}