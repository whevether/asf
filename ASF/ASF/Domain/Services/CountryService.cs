using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   国家服务
/// </summary>
public class CountryService
{
  private readonly ICountryRepositories _countryRepositories;
  private readonly IIdGenerator _idGenerator;

  /// <summary>
  ///   国家服务
  /// </summary>
  /// <param name="countryRepositories"></param>
  /// <param name="idGenerator"></param>
  public CountryService(ICountryRepositories countryRepositories, IIdGenerator idGenerator)
  {
    _countryRepositories = countryRepositories;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取国家
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public async Task<Result<Country>> Get(long id)
  {
    var country = await _countryRepositories.GetEntity(f => f.Id == id);
    if (country == null)
      return Result<Country>.ReFailure(ResultCodes.CountryNotExist);
    return Result<Country>.ReSuccess(country);
  }

  /// <summary>
  ///   获取国家分页
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  public async Task<(IList<Country> list, int total)> GetList(int pageNo, int pageSize, string name)
  {
    if (!string.IsNullOrEmpty(name))
    {
      var (list, total) = await _countryRepositories.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Contains(name) || f.LanguageCode.Contains(name));
      return (list, total);
    }

    var (data, totalCount) = await _countryRepositories.GetEntitiesForPaging(pageNo, pageSize, f => f.Id != 0);
    return (data, totalCount);
  }

  /// <summary>
  ///   获取国家列表
  /// </summary>
  /// <returns></returns>
  public async Task<ResultList<Country>> GetList()
  {
    var list = await _countryRepositories.GetEntities(f => f.Id != 0);
    if (list == null)
      return ResultList<Country>.ReFailure(ResultCodes.CountryNotExist);
    return ResultList<Country>.ReSuccess(list.ToList());
  }

  /// <summary>
  ///   添加国家
  /// </summary>
  /// <param name="country"></param>
  /// <returns></returns>
  public async Task<Result> Create(Country country)
  {
    if (await _countryRepositories.GetEntity(f =>
          f.Name.Equals(country.Name) || f.LanguageCode.Equals(country.LanguageCode)) != null)
      return Result.ReFailure(ResultCodes.CountryNameExistError);
    country.SetId(_idGenerator.GenId());
    var isAdd = await _countryRepositories.Add(country);
    if (!isAdd) return Result.ReFailure(ResultCodes.CountryCreateError);

    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改国家
  /// </summary>
  /// <param name="country"></param>
  /// <returns></returns>
  public async Task<Result> Modify(Country country)
  {
    if (await _countryRepositories.GetEntity(f =>
          f.Id != country.Id && (f.Name.Equals(country.Name) || f.LanguageCode.Equals(country.LanguageCode))) != null)
      return Result.ReFailure(ResultCodes.CountryNameExistError);
    var isUpdate = await _countryRepositories.Update(country);
    if (!isUpdate) return Result.ReFailure(ResultCodes.CountryUpdateError);

    return Result.ReSuccess();
  }

  /// <summary>
  ///   硬 删除国家
  /// </summary>
  /// <param name="country"></param>
  /// <returns></returns>
  public async Task<Result> Delete(Country country)
  {
    var isDelete = await _countryRepositories.Delete(country);
    if (!isDelete) return Result.ReFailure(ResultCodes.CountryDeleteError);

    return Result.ReSuccess();
  }
}