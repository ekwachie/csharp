﻿using System.Linq.Expressions;

namespace csharp.DataAccess;

// creating a generic repository pattern wher T - Model class
public interface IRepository<T> where T : class 
{
    // Let T - Category( Can be any Class Model)  
    // selecting all from db table
    IEnumerable<T> GetAll();
    // Select one data using link operations
    T Get(Expression<Func<T, bool>> filter);
    // insert into db table
    void Insert(T entity);
    // update into db table
    void Update(T entity);
    void Save();
    // delete a record from db table
    void Delete(T entity);
    // delete multi records from db table in a single call
    void DeleteRange(IEnumerable<T> entity);
}
