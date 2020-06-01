using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO.DTOModels;
using BLL.DTO.DTOResults;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CommentsService : ICommentsServices
    {
        private readonly DBContext _context;

        public CommentsService(DBContext context)
        {
            _context = context;
        }

        public bool CreateComment(CreateCommentModel model)
        {
            var bike = _context.Bikes.FirstOrDefault(x => x.Id == model.BikeId);
            if (bike == null)
            {
                throw new Exception("Выбран несуществуюший велосипед");
            }

            var content = new Comment()
            {
                Name = model.Name,
                Text = model.Text,
                Bike = bike
            };
            _context.Comments.Add(content);
            _context.SaveChanges();
            return true;
        }

        public List<CommentsResult> GetComments()
        {
            var result = new List<CommentsResult>();

            foreach (var comment in _context.Comments)
            {
                result.Add(new CommentsResult()
                {
                    Name = comment.Name,
                    Text = comment.Text
                });
            }

            return result;
        }

        public List<CommentsResult> GetCommentsByBikeId(int bikeId)
        {
            var result = new List<CommentsResult>();

            foreach (var comment in _context.Comments.Include(x => x.Bike).Where(x => x.Bike.Id == bikeId))
            {
                result.Add(new CommentsResult()
                {
                    Id = comment.Id,
                    Name = comment.Name,
                    Text = comment.Text
                });
            }

            return result;
        }
    }
}