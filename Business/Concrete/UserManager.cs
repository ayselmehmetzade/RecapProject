using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userdal.Delete(user);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userdal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
           return new SuccessDataResult<User>(_userdal.Get(u=>u.UserId==id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userdal.Get(u => u.Email == email));
            
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userdal.GetClaims(user));
            
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userdal.Update(user);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
