using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.DTOModels
{
    public class CreateCommentModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы забыли оставить свой отзыв")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Указатель на id велосипеда")]
        public int BikeId { get; set; }
    }
}