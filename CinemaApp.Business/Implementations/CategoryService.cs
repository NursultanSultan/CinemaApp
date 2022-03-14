using AutoMapper;
using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Utilities.File;
using CinemaApp.Core;
using CinemaApp.Entity.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Business.Implementations
{
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork _unitOfWork { get; }
        private IMapper _mapper { get; }
        private IWebHostEnvironment _env { get; }

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper , IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(CategoryCreateDto createDto)
        {
            Category category = new Category
            {
                CategoryName = createDto.CategoryName

            };

            string root = Path.Combine(_env.WebRootPath, "assets", "image");
            string FileName = await createDto.CategoryPhoto.SaveFileAsync(root);
            category.CategoryImageURL = FileName;

            /*File upload end*/

            await _unitOfWork.categoryRepository.CreateAsync(category);
            await _unitOfWork.SavechangeAsync();
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
        {
            var dbCategories = await _unitOfWork.categoryRepository
                                        .GetAllAsync(c => c.IsDeleted == false);

            //List<CategoryReadDto> readVM = _mapper.Map<List<CategoryReadDto>>(dbCategories);
            List<CategoryReadDto> categoryDtos = new List<CategoryReadDto>();

            foreach (var category in dbCategories)
            {
                CategoryReadDto readDto = new CategoryReadDto
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CategoryImageURL = category.CategoryImageURL
                };

                categoryDtos.Add(readDto);
            }

            return categoryDtos;
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, CategoryUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
