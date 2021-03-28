﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail(Expression<Func<CarDetailDto, bool>> filter = null);
        //List<CarDetailDto> GetCarsByColorIdAndBrandId(int colorId, int brandId);
    }
}
