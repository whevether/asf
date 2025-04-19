using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository;

public class Repositories<T> : IRepositories<T> where T : class
{
  private readonly RepositoryContext _context;

  public Repositories(RepositoryContext context)
  {
    _context = context;
  }

  /// <summary>
  ///   添加
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> Add(T entity)
  {
    await _context.Set<T>().AddAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  /// <summary>
  ///   批量添加
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> AddRange(List<T> entity)
  {
    await _context.Set<T>().AddRangeAsync(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  /// <summary>
  ///   删除
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> Delete(T entity)
  {
    _context.Set<T>().Remove(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  /// <summary>
  ///   批量修改
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> DeleteRange(List<T> entity)
  {
    _context.Set<T>().RemoveRange(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  /// <summary>
  ///   修改
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> Update(T entity)
  {
    _context.Set<T>().Update(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  /// <summary>
  ///   批量修改
  /// </summary>
  /// <param name="entity"></param>
  /// <returns></returns>
  public async Task<bool> UpdateRange(List<T> entity)
  {
    _context.Set<T>().UpdateRange(entity);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<IEnumerable<T>> GetEntities(Expression<Func<T, bool>> exp)
  {
    return await Task.FromResult(CompileQuery(exp));
  }

  /// <summary>
  /// </summary>
  /// <param name="page"></param>
  /// <param name="pageSize"></param>
  /// <param name="exp"></param>
  /// <param name="sort"></param>
  /// <param name="sortFiled"></param>
  /// <returns></returns>
  public async Task<(IList<T> list, int total)> GetEntitiesForPaging(int page, int pageSize,
    Expression<Func<T, bool>> exp, string sort = "acs", string sortFiled = "Id")
  {
    IList<T> query = CompileQuery(exp).ToList();
    var count = query.Count();
    var p = page == 0 ? 1 : page;
    var c = pageSize == 0 ? count : pageSize;
    var totalPages = (int)Math.Ceiling((decimal)count / c);
    p = Math.Min(p, totalPages);
    var dic = new Dictionary<string, IList<T>>
    {
      ["acs"] = query.OrderBy(f =>
        {
          var propertyInfo = f.GetType().GetTypeInfo().GetProperty(sortFiled);
          return propertyInfo.GetValue(f, null);
        }).Skip((p - 1) * c)
        .Take(c)
        .ToList(),
      ["desc"] = query.OrderByDescending(f =>
        {
          var propertyInfo = f.GetType().GetTypeInfo().GetProperty(sortFiled);
          return propertyInfo.GetValue(f, null);
        }).Skip((p - 1) * c)
        .Take(c)
        .ToList()
    };
    var list = dic[sort];
    return await Task.FromResult<(IList<T> list, int total)>((list, count));
  }

  public async Task<T> GetEntity(Expression<Func<T, bool>> exp)
  {
    return await Task.FromResult(CompileQuerySingle(exp));
  }

  /// <summary>
  ///   查询集合
  /// </summary>
  /// <param name="exp"></param>
  /// <returns></returns>
  private IEnumerable<T> CompileQuery(Expression<Func<T, bool>> exp)
  {
    var func = EF.CompileQuery((RepositoryContext context, Expression<Func<T, bool>> exps) =>
      context.Set<T>().Where(exp));
    return func(_context, exp);
  }

  /// <summary>
  ///   查询单个
  /// </summary>
  /// <param name="exp"></param>
  /// <returns></returns>
  private T CompileQuerySingle(Expression<Func<T, bool>> exp)
  {
    var func = EF.CompileQuery((RepositoryContext context, Expression<Func<T, bool>> exps) =>
      context.Set<T>().FirstOrDefault(exp));
    return func(_context, exp);
  }

  /// <summary>
  ///   获取db context
  /// </summary>
  /// <returns></returns>
  public RepositoryContext GetDbContext()
  {
    return _context;
  }
}