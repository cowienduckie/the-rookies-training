﻿using BookLibrary.WebApi.Attributes;
using BookLibrary.WebApi.Dtos.Category;
using BookLibrary.WebApi.Filters;
using BookLibrary.WebApi.Services.Interfaces;
using Common.Constants;
using Common.DataType;
using Common.Enums;
using Common.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/categories")]
public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("unpaged-list")]
    [Authorize(Role.NormalUser, Role.SuperUser)]
    public async Task<ActionResult<IPagedList<GetCategoryResponse>>> GetAll()
    {
        try
        {
            var result = await _categoryService.GetAllAsync();

            return Ok(result);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpGet]
    [Authorize(Role.NormalUser, Role.SuperUser)]
    public async Task<ActionResult<IPagedList<GetCategoryResponse>>> GetPagedList(
        [FromQuery] PagingFilter pagingFilter,
        [FromQuery] SortFilter sortFilter)
    {
        try
        {
            var result = await _categoryService.GetPagedListAsync(pagingFilter, sortFilter);

            return Ok(result.ToObject());
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpGet("{id}")]
    [Authorize(Role.NormalUser, Role.SuperUser)]
    public async Task<ActionResult<GetCategoryResponse>> GetById(int id)
    {
        try
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPost]
    [Authorize(Role.SuperUser)]
    public async Task<ActionResult<CreateCategoryResponse>> Create([FromBody] CreateCategoryRequest requestModel)
    {
        try
        {
            var result = await _categoryService.CreateAsync(requestModel);

            if (result == null) return StatusCode(CustomStatusCodes.CreateError, ErrorMessages.CreateError);

            return CreatedAtRoute(new {id = result.Id.ToString()}, result);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpPut]
    [Authorize(Role.SuperUser)]
    public async Task<ActionResult<UpdateCategoryResponse>> Update([FromBody] UpdateCategoryRequest requestModel)
    {
        var isExist = _categoryService.IsExist(requestModel.Id);

        if (!isExist) return NotFound();

        try
        {
            var result = await _categoryService.UpdateAsync(requestModel);

            if (result == null) return StatusCode(CustomStatusCodes.UpdateError, ErrorMessages.UpdateError);

            return Ok(result);
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Role.SuperUser)]
    public async Task<IActionResult> Delete(int id)
    {
        var isExist = _categoryService.IsExist(id);

        if (!isExist) return NotFound();

        try
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result) return StatusCode(CustomStatusCodes.DeleteError, ErrorMessages.DeleteError);

            return NoContent();
        }
        catch (Exception exception)
        {
            return HandleException(exception);
        }
    }
}