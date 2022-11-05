﻿using BookLibrary.Data.Entities;
using System.Linq.Expressions;

namespace BookLibrary.Data.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    T? Get(Expression<Func<T, bool>>? predicate = null);
    T Create(T entity);
    T Update(T entity);
    void Delete(T entity);
}