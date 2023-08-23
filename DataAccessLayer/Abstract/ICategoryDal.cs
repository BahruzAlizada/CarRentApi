﻿using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<CategoryDTO> GetAllJustCategory();
        CategoryDTO GetByIdJustCategory(int id);
       void Activity(int id);
    }
}
