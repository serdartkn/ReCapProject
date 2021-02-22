using Business.Abstract;
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
        public void Add(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Add(color);
                Console.WriteLine("Başarıyla Kayıt Edildi.");
            }
            else
            {
                Console.WriteLine("Girilen Bilgileri Kontrol Edin!");
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int Id)
        {
            return _colorDal.Get(c=>c.ColorId == Id);
        }

        public void Update(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Update(color);
                Console.WriteLine("Başarıyla Kayıt Edildi.");
            }
            else
            {
                Console.WriteLine("Girilen Bilgileri Kontrol Edin!");
            }
        }
    }
}
