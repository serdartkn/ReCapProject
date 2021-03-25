using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Aspect.Autofact.Validation.ValicationAspect;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccesResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandAddInvalid);
            }

            _brandDal.Delete(brand);
            return new SuccesResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int Id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == Id), Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                _brandDal.Update(brand);
                return new ErrorResult(Messages.BrandAddInvalid);
            }

            _brandDal.Update(brand);
            return new SuccesResult(Messages.BrandUpdated);
        }
    }
}
