using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BLL.DTO.DTOModels;
using BLL.DTO.DTOResults;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace BLL.Services
{
    public class BikeService : IBikeService
    {
        private readonly DBContext _context;
        private readonly IHostingEnvironment _environment;

        public BikeService(DBContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public BikesResult GetBikeById(int id)
        {
            var bike = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).FirstOrDefault(x => x.Id == id);
            if (bike != null)
            {
                            var file = "";
                            if (bike.Attachment != null)
                            {
                                file = bike.Attachment.Url;
                            }
                                
                            return (new BikesResult() 
                            {
                                Id = bike.Id, 
                                Name = bike.Name, 
                                Weight = bike.Weight, 
                                MaxSpeed = bike.MaxSpeed, 
                                CarCapacity = bike.CarCapacity, 
                                Radius = bike.Radius, 
                                Height = bike.Height,
                                Text = bike.Description, 
                                Attachment = file, 
                                Specification = bike.Specification?.Name
                            });
            }

            return null;

        }

        public bool CreateBike(CreateBikeModel model)
        {
            var file = SaveFile(model.File);
            if (file == null)
            {
                throw new Exception("Не смогли сохранить фаш файл!");
            }
            var specification = _context.Specifications.FirstOrDefault(x => x.Id == model.SpecificationId);
            if (specification == null)
            {
                throw new Exception("Спецификация отсутствует");
            }
            var bike = new Bike()
            {
                Name = model.Name,
                Weight = model.Weight,
                MaxSpeed = model.MaxSpeed,
                CarCapacity = model.CarCapacity,
                Radius = model.Radius,
                Height = model.Height,
                Description = model.Text,
                Attachment = new Attachment()
                {
                    Url = file
                },
                Specification = specification
            };
            _context.Bikes.Add(bike);
            _context.SaveChanges();
            return true;
        }

        public List<BikesResult> GetBikes()
        {
            var result = new List<BikesResult>();

            foreach (var bike in _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment))
            {
                var file = "";
                if (bike.Attachment != null)
                {
                    file = bike.Attachment.Url;
                }
                result.Add(new BikesResult()
                {
                    Id = bike.Id,
                        Name = bike.Name,
                        Weight = bike.Weight,
                        MaxSpeed = bike.MaxSpeed,
                        CarCapacity = bike.CarCapacity,
                        Radius = bike.Radius,
                        Height = bike.Height,
                        Text = bike.Description,
                        Attachment = file,
                        Specification = bike.Specification?.Name
                });
            }

            return result;
        }

        private string SaveFile(IFormFile file)
        {
            try
            {
                var fileName = Guid.NewGuid().ToString() + "." + file.FileName.Split('.').Last();
                var pathToServer = _environment.ContentRootPath;
                var pathToFolder = Path.Combine(pathToServer, "images");
                var pathToImages = Path.Combine(pathToFolder, fileName);

                using (var fileStream = new FileStream(pathToImages, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return fileName;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public List<BikesResult> GetBikesByFilter(string name, int? weight, int? speed, double? capacity, double? radius, double? height)
        {
            var result = new List<BikesResult>();
            var bikes = this._context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).ToList();

            if (!string.IsNullOrEmpty(name))
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.Name == name).ToList();
            }
            
            if (weight != null)
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.Weight <= weight).ToList();
            }
            
            if (speed != null)
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.MaxSpeed <= speed).ToList();
            }
            
            if (capacity != null)
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.CarCapacity <= capacity).ToList();
            }
            
            if (radius != null)
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.Radius <= radius).ToList();
            }
            
            if (height != null)
            {
                bikes = _context.Bikes.Include(x => x.Specification).Include(x => x.Attachment).Where(x => x.Height <= height).ToList();
            }
            
            foreach (var bike in bikes)
            {
                var file = "";
                if (bike.Attachment != null)
                {
                    file = bike.Attachment.Url;
                }
                
                result.Add(new BikesResult() 
                {
                    Id = bike.Id, 
                    Name = bike.Name, 
                    Weight = bike.Weight, 
                    MaxSpeed = bike.MaxSpeed, 
                    CarCapacity = bike.CarCapacity, 
                    Radius = bike.Radius, 
                    Height = bike.Height,
                    Text = bike.Description, 
                    Attachment = file, 
                    Specification = bike.Specification?.Name
                });
            }

            return result;
        }
    }
}

