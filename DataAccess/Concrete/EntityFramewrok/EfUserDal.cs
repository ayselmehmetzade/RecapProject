﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramewrok
{
    public class EfUserDal : EfEntityRepositoryBase<User, RecapContext>, IUserDal
    {

    }
}
