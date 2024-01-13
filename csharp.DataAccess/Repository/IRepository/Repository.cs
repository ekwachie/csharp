﻿using System.Linq.Expressions;
using csharp.DataAccess.app;
using Microsoft.EntityFrameworkCore;

namespace csharp.DataAccess;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly Config db;
    // creating a generic db tables
    internal DbSet<T> dbSet;

    public Repository(Config conn)
    {
        db = conn;
        // eg. dbSet = db.Categories 
        this.dbSet = db.Set<T>();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);

    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}
