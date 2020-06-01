using System.Collections.Generic;
using BLL.DTO.DTOModels;
using BLL.DTO.DTOResults;

namespace BLL.Interfaces
{
    public interface ICommentsServices
    {
        bool CreateComment(CreateCommentModel model);
        List<CommentsResult> GetComments();

        List<CommentsResult> GetCommentsByBikeId(int bikeId);
    }
}