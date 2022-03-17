using AutoMapper;
using CinemaApp.Business.DTOs.CategoryDtos;
using CinemaApp.Business.Exceptions.FileExceptions;
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
            if (!createDto.CategoryPhoto.CheckFileType("image/"))
            {
                throw new FileTypeException("File must be image type");
            }
            if (!createDto.CategoryPhoto.CheckFileSize(300))
            {
                throw new FileTypeException("File must be less than 300kb");
            }

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

        public async Task RemoveAsync(int id)
        {
            var dbCategory = await _unitOfWork.categoryRepository
                                        .GetAsync(c => c.Id == id);

            if (dbCategory == null) throw new NullReferenceException();

            dbCategory.IsDeleted = true;

            await _unitOfWork.SavechangeAsync();

        }

        public CategoryUpdateDto Update(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, CategoryUpdateDto updateDto)
        {
            var dbCategory = await _unitOfWork.categoryRepository
                                        .GetAsync(c => c.Id == id);

            if (dbCategory == null) throw new NullReferenceException();

            if (updateDto.CategoryPhoto != null)
            {
                /*File upload start*/
                if (!updateDto.CategoryPhoto.CheckFileType("image/"))
                {
                    throw new FileTypeException("File must be image type");
                }
                if (!updateDto.CategoryPhoto.CheckFileSize(300))
                {
                    throw new FileTypeException("File must be less than 300kb");
                }


                string root = Path.Combine(_env.WebRootPath, "assets", "image");
                string FileName = dbCategory.CategoryImageURL;
                string resultPath = Path.Combine(root, FileName);

                if (System.IO.File.Exists(resultPath))
                {
                    System.IO.File.Delete(resultPath);
                }

                string UpdatedFileName = await updateDto.CategoryPhoto.SaveFileAsync(root);
                dbCategory.CategoryImageURL = UpdatedFileName;

                /*File upload end*/
            }

            dbCategory.CategoryName = updateDto
                                      .CategoryName != null ? updateDto.CategoryName : dbCategory.CategoryName;


            await _unitOfWork.SavechangeAsync();
        }
    }
}
