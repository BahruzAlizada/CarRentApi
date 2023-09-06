using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    internal interface ICarService
    {
        void Add(CarDTO cardto);
        void Update(CarDTO cardto);
        void Delete(CarDTO cardto);
        void Activity(int id);
    }
}
