using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;

namespace ASF.EntityFramework.Repository;
/// <summary>
/// 国家仓储
/// </summary>
public class CountryRepositories: Repositories<Country>, ICountryRepositories
{
  public CountryRepositories(RepositoryContext context) : base(context)
  {
  }
}