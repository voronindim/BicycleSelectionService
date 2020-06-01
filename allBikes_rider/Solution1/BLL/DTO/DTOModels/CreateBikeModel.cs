using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BLL.DTO.DTOModels
{
    public class CreateBikeModel
    {
        [Required(ErrorMessage = "Введите название велосипеда")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите вес велосипеда")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Введите максимальную скорость")]
        public int MaxSpeed { get; set; }
        [Required(ErrorMessage = "Введите грузоподъемность")]
        public double CarCapacity { get; set; }
        [Required(ErrorMessage = "Введите радиус колес")]
        public double Radius { get; set; }
        [Required(ErrorMessage = "Введите высоту велосипеда")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Введите опиасние")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Введите выберите правильную спецификацию")]
        public int SpecificationId { get; set; }
        
        [Required(ErrorMessage = "Ошибка получения картинки :(")]
        public IFormFile File { get; set; }
    }
}