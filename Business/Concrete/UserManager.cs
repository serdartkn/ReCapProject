using Business.Abstract;
using Business.Constants;
using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length > 2)
            {
                _userDal.Add(user);
                return new SuccesResult(Messages.UserAdded);
            }
            
            return new ErrorResult(Messages.UserAddInvalid);
        }

        public IResult Delete(User user)
        {
            if (user.FirstName.Length > 2)
            {
                _userDal.Delete(user);
                return new SuccesResult(Messages.UserDeleted);

            }
            return new ErrorResult(Messages.UserAddInvalid);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id), Messages.UserListed);
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length > 2)
            {
                _userDal.Update(user);
                return new SuccesResult(Messages.UserUpdated);
            }
            return new ErrorResult(Messages.UserAddInvalid);
        }
    }
}
