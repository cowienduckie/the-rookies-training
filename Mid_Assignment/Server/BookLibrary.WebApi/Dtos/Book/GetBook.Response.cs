﻿using BookLibrary.WebApi.Dtos.Category;

namespace BookLibrary.WebApi.Dtos.Book;

public class GetBookResponse
{
    public GetBookResponse(Data.Entities.Book book)
    {
        Id = book.Id;
        Name = book.Name;
        Description = book.Description;
        Cover = book.Cover;
        Categories = book.Categories
            .Select(category => new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            })
            .ToList();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Cover { get; set; }
    public List<CategoryModel> Categories { get; set; }
}