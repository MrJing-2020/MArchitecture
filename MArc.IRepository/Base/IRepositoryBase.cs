﻿using MArc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MArc.IRepository
{
    public interface IRepositoryBase : IDisposable
    {
        T FindObject<T>(Expression<Func<T, bool>> conditions = null) where T : class;
        T FindObject<T>(string sql, params SqlParameter[] parameters) where T : class;
        IEnumerable<T> FindBy<T>(string sql, params SqlParameter[] parameters) where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> conditions = null) where T : class;
        IQueryable<T> FindBy<T>() where T : class;
        IQueryable<T> FindAllByPage<T, TKey>(int pageNumber, int pageSize, out int total, Expression<Func<T, TKey>> orderBy, bool isAsc = true) where T : class;
        IQueryable<T> FindAllByPage<T, TKey>(Expression<Func<T, bool>> where, int pageNumber, int pageSize, out int total, Expression<Func<T, TKey>> orderBy, bool isAsc = true) where T : class;
        IEnumerable<T> FindAllByProc<T>(string procName, params SqlParameter[] parameters) where T : class;

        T Update<T>(T entity) where T : class;
        void Update<T>(params T[] entitis) where T : class;
        T SaveEntity<T>(T entity) where T : BaseModel;

        T Insert<T>(T entity) where T : class;
        void Insert<T>(IEnumerable<T> entities) where T : class;

        void Remove<T>(params int[] ids) where T : BaseModel;
        void Remove<T>(Expression<Func<T, bool>> where) where T : class;
    }
}
