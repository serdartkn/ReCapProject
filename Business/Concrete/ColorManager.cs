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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Add(color);
                return new SuccesResult(Messages.ColorAdded);
            }
            else
            {
                return new ErrorResult(Messages.ColorAddInvalid);
            }
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int Id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(color=>color.Id==Id), Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Update(color);
                return new SuccesResult(Messages.ColorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ColorAddInvalid);
            }
        }
    }
}
