﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto {
                                 CarId = c.Id, 
                                 Description = c.Description, 
                                 BrandName = b.BrandName, 
                                 ColorName = c1.ColorName, 
                                 DailyPrice = c.DailyPrice ,
                                 ColorId = c.ColorId,
                                 BrandId=b.BrandId,
                                 ModelYear=c.ModelYear
                                 
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }

     
    }
}
