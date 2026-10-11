using System;
using ASF.Internal.Results;

namespace ASF.Domain;

/// <summary>
///   错误结果代码（Item2 为 SharedResource 多语言键）
/// </summary>
public class ResultCodes : BaseResultCodes
{
#pragma warning disable 1591

  public static ValueTuple<int, string> TenancyNameExist = (10001, nameof(TenancyNameExist));
  public static ValueTuple<int, string> TenancyNotExist = (10002, nameof(TenancyNotExist));
  public static ValueTuple<int, string> TenancyCreateFailure = (10003, nameof(TenancyCreateFailure));
  public static ValueTuple<int, string> TenancyModifyFailure = (10004, nameof(TenancyModifyFailure));
  public static ValueTuple<int, string> TenancyDisabled = (10005, nameof(TenancyDisabled));
  public static ValueTuple<int, string> TenancyMatchExist = (10006, nameof(TenancyMatchExist));

  public static ValueTuple<int, string> TenancyIsDelete = (10007, nameof(TenancyIsDelete));

  public static ValueTuple<int, string> AccountUpdateError = (11000, nameof(AccountUpdateError));
  public static ValueTuple<int, string> AccountOldPasswordAndNewPasswordSame = (11002, nameof(AccountOldPasswordAndNewPasswordSame));
  public static ValueTuple<int, string> AccountNotExist = (11003, nameof(AccountNotExist));
  public static ValueTuple<int, string> AccountRoleAssignationFailed = (11004, nameof(AccountRoleAssignationFailed));
  public static ValueTuple<int, string> AccountNotAllowedLogin = (11005, nameof(AccountNotAllowedLogin));
  public static ValueTuple<int, string> AccountUnavailable = (11006, nameof(AccountUnavailable));
  public static ValueTuple<int, string> AccountPasswordNotSame2 = (11007, nameof(AccountPasswordNotSame2));
  public static ValueTuple<int, string> AccountPasswordNotSame = (11007, nameof(AccountPasswordNotSame));
  public static ValueTuple<int, string> AccountPasswordNotSameOverrun = (11008, nameof(AccountPasswordNotSameOverrun));
  public static ValueTuple<int, string> AccountLoginExpired = (11009, nameof(AccountLoginExpired));
  public static ValueTuple<int, string> AccountExist = (11010, nameof(AccountExist));
  public static ValueTuple<int, string> AccountCreate = (11011, nameof(AccountCreate));
  public static ValueTuple<int, string> AccountOldEmailError = (11012, nameof(AccountOldEmailError));
  public static ValueTuple<int, string> AccountOldTelPhoneError = (11013, nameof(AccountOldTelPhoneError));
  public static ValueTuple<int, string> AccountExistTelPhoneError = (11014, nameof(AccountExistTelPhoneError));
  public static ValueTuple<int, string> AccountExistEmailError = (11015, nameof(AccountExistEmailError));
  public static ValueTuple<int, string> AccountExistUserNameError = (11015, nameof(AccountExistUserNameError));
  public static ValueTuple<int, string> AccountExistTypeError = (11016, nameof(AccountExistTypeError));

  public static ValueTuple<int, string> AccountNameExistTypeError = (11017, nameof(AccountNameExistTypeError));

  public static ValueTuple<int, string> RoleNotExist = (12000, nameof(RoleNotExist));
  public static ValueTuple<int, string> RoleUnavailable = (12001, nameof(RoleUnavailable));
  public static ValueTuple<int, string> RoleCreateFailed = (12002, nameof(RoleCreateFailed));
  public static ValueTuple<int, string> RolePermissionAssignationFailed = (12003, nameof(RolePermissionAssignationFailed));
  public static ValueTuple<int, string> RoleIdNotExist = (12004, nameof(RoleIdNotExist));
  public static ValueTuple<int, string> RoleNameExist = (12005, nameof(RoleNameExist));
  public static ValueTuple<int, string> RoleModifyFailed = (12006, nameof(RoleModifyFailed));
  public static ValueTuple<int, string> RoleNotSuperFailed = (12007, nameof(RoleNotSuperFailed));

  public static ValueTuple<int, string> RoleDeleteError = (12008, nameof(RoleDeleteError));

  public static ValueTuple<int, string> PermissionNotExist = (13000, nameof(PermissionNotExist));
  public static ValueTuple<int, string> PermissionCreateError = (13001, nameof(PermissionCreateError));
  public static ValueTuple<int, string> PermissionUpdateError = (13002, nameof(PermissionUpdateError));
  public static ValueTuple<int, string> PermissionDeleteError = (13003, nameof(PermissionDeleteError));
  public static ValueTuple<int, string> PermissionSysDeleteError = (13004, nameof(PermissionSysDeleteError));
  public static ValueTuple<int, string> PermissionSystemNotModify = (13005, nameof(PermissionSystemNotModify));
  public static ValueTuple<int, string> PermissionSystemNotCreate = (13005, nameof(PermissionSystemNotCreate));
  public static ValueTuple<int, string> PermissionApiNotExist = (13006, nameof(PermissionApiNotExist));
  public static ValueTuple<int, string> PermissionApiCreateError = (13007, nameof(PermissionApiCreateError));
  public static ValueTuple<int, string> PermissionApiUpdateError = (13008, nameof(PermissionApiUpdateError));
  public static ValueTuple<int, string> PermissionSysApiUpdateError = (13009, nameof(PermissionSysApiUpdateError));
  public static ValueTuple<int, string> PermissionSysApiDeleteError = (130010, nameof(PermissionSysApiDeleteError));
  public static ValueTuple<int, string> PermissionApiPathExist = (13011, nameof(PermissionApiPathExist));
  public static ValueTuple<int, string> PermissionMenuNotExist = (13012, nameof(PermissionMenuNotExist));
  public static ValueTuple<int, string> PermissionMenuTitleOrUrlExist = (13013, nameof(PermissionMenuTitleOrUrlExist));
  public static ValueTuple<int, string> PermissionMenuCreateError = (13014, nameof(PermissionMenuCreateError));
  public static ValueTuple<int, string> PermissionMenuUpdateError = (13015, nameof(PermissionMenuUpdateError));
  public static ValueTuple<int, string> PermissionMenuDeleteError = (13016, nameof(PermissionMenuDeleteError));
  public static ValueTuple<int, string> PermissionNameOrCodeExist = (13017, nameof(PermissionNameOrCodeExist));

  public static ValueTuple<int, string> PermissionIdNotExist = (13018, nameof(PermissionIdNotExist));

  public static ValueTuple<int, string> LogginDeletedCannoBeWithinThreeMonths = (14000, nameof(LogginDeletedCannoBeWithinThreeMonths));
  public static ValueTuple<int, string> LogginDeletedError = (14001, nameof(LogginDeletedError));

  public static ValueTuple<int, string> LoggingNotExist = (14002, nameof(LoggingNotExist));

  public static ValueTuple<int, string> TranslateNotExist = (15000, nameof(TranslateNotExist));
  public static ValueTuple<int, string> TranslateNameExist = (15001, nameof(TranslateNameExist));
  public static ValueTuple<int, string> TranslateCreateError = (15002, nameof(TranslateCreateError));
  public static ValueTuple<int, string> TranslateUpdateError = (15003, nameof(TranslateUpdateError));

  public static ValueTuple<int, string> TranslateDeleteError = (15004, nameof(TranslateDeleteError));

  public static ValueTuple<int, string> CountryNotExist = (15005, nameof(CountryNotExist));
  public static ValueTuple<int, string> CountryCreateError = (15006, nameof(CountryCreateError));
  public static ValueTuple<int, string> CountryUpdateError = (15007, nameof(CountryUpdateError));
  public static ValueTuple<int, string> CountryDeleteError = (15008, nameof(CountryDeleteError));
  public static ValueTuple<int, string> CountryNameExistError = (15010, nameof(CountryNameExistError));

  public static ValueTuple<int, string> DepartmentNotExist = (16000, nameof(DepartmentNotExist));
  public static ValueTuple<int, string> DepartmentNameExist = (16001, nameof(DepartmentNameExist));
  public static ValueTuple<int, string> DepartmentCreateError = (16002, nameof(DepartmentCreateError));
  public static ValueTuple<int, string> DepartmentUpdateError = (16003, nameof(DepartmentUpdateError));

  public static ValueTuple<int, string> DepartmentUnavailable = (16004, nameof(DepartmentUnavailable));

  public static ValueTuple<int, string> PostNotExist = (17000, nameof(PostNotExist));
  public static ValueTuple<int, string> PostNameExist = (17001, nameof(PostNameExist));
  public static ValueTuple<int, string> PostCreateError = (17002, nameof(PostCreateError));
  public static ValueTuple<int, string> PostModifyError = (17003, nameof(PostModifyError));
  public static ValueTuple<int, string> PostDeleteError = (17004, nameof(PostDeleteError));

  public static ValueTuple<int, string> PostUnavailable = (17004, nameof(PostUnavailable));

  public static ValueTuple<int, string> DictionaryNotExist = (18000, nameof(DictionaryNotExist));
  public static ValueTuple<int, string> DictionaryKeyExist = (18001, nameof(DictionaryKeyExist));
  public static ValueTuple<int, string> DictionaryCreateError = (18002, nameof(DictionaryCreateError));
  public static ValueTuple<int, string> DictionaryUpdateError = (18003, nameof(DictionaryUpdateError));
  public static ValueTuple<int, string> DictionaryDeleteError = (18004, nameof(DictionaryDeleteError));
}
