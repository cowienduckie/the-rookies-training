﻿using BookLibrary.WebApi.Dtos.Category;
using BookLibrary.WebApi.Filters;
using Common.DataType;

namespace BookLibrary.WebApi.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<GetCategoryResponse>> GetAllAsync();

    Task<IPagedList<GetCategoryResponse>> GetPagedListAsync(PagingFilter pagingFilter, SortFilter sortFilter);

    Task<GetCategoryResponse?> GetByIdAsync(int id);

    Task<CreateCategoryResponse?> CreateAsync(CreateCategoryRequest requestModel);

    Task<UpdateCategoryResponse?> UpdateAsync(UpdateCategoryRequest requestModel);

    Task<bool> DeleteAsync(int id);

    bool IsExist(int id);
}