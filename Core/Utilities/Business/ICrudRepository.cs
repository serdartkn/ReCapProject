using Core.Entities;
using Core.Entities.Abstract;
using Core.Result.Abstract;
using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public interface ICrudRepository<T> where T: class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
