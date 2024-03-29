﻿using System;
using Microsoft.EntityFrameworkCore;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly SchedulePlatformContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(SchedulePlatformContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public T? GetById(Guid id)
        {
            return _dbSet.FirstOrDefault((T m) => m.Id == id);
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

    }
}

