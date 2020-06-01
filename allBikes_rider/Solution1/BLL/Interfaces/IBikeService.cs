using System.Collections.Generic;
using BLL.DTO.DTOModels;
using BLL.DTO.DTOResults;
using BLL.Services;

namespace BLL.Interfaces
{
    public interface IBikeService
    {
        bool CreateBike(CreateBikeModel model);
        
        List<BikesResult> GetBikes();
        List<BikesResult> GetBikesByFilter(string name, int? weight, int? speed, double? capacity, double? radius, double? height);

        BikesResult GetBikeById(int id);
    }
}