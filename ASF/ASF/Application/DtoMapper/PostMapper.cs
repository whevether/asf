using ASF.Application.DTO.Post;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   岗位映射
/// </summary>
public class PostMapper : Profile
{
  /// <summary>
  ///   岗位映射
  /// </summary>
  public PostMapper()
  {
    //创建
    CreateMap<PostCreateRequestDto, Post>();
    //修改
    CreateMap<PostModifyRequestDto, Post>();
    //响应
    CreateMap<Post, PostResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id));
  }
}