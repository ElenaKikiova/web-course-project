﻿using CourseProject.ViewModels.Brands;

namespace CourseProject.Services.Abstractions
{
    public interface IBrandsService
    {
        BrandDetailViewModel Get(int id);

        List<BrandDetailViewModel> GetAll();

        void Add(CreateEditBrandViewModel createEditBrandViewModel);

        void Update(CreateEditBrandViewModel createEditBrandViewModel);

        void Delete(int id);
    }
}
