-- 插入租户
INSERT INTO asf_tenancy (name,create_id) VALUES('总部集团',1);
INSERT INTO asf_tenancy (name,create_id) VALUES('公司a',1);
-- 插入(控制面板)权限数据
INSERT INTO asf_permission (code,name,type,is_system) VALUES ('asf_dash','控制台',2,1);
INSERT INTO asf_permission (code,name,type,is_system) VALUES ('asf','控制面板权限',1,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_account',2,'账户管理权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_permission',2,'权限管理权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_menu',2,'菜单管理权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_authapi',2,'授权api管理权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_role',2,'角色管理权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_audio',2,'审计管理权限',1,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_audio_error',8,'错误日志权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_audio_log',8,'操作日志权限',2,1);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_scheduled_task',2,'调度任务权限',2,0);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_tenancy',2,'租户管理权限',2,0);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_department',2,'部门管理权限',2,0);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_post',2,'岗位管理权限',2,0);
INSERT INTO asf_permission (code,parent_id,name,type,is_system) VALUES ('asf_translate',2,'多语言管理权限',2,0);

--  插入公共权限
INSERT INTO asf_permission (code,name,type,is_system) VALUES ('asf_openapi','公共权限',3,1);
-- 插入权限菜单数据
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('控制台','控制台菜单',1,'icon-dash_board','/','控制台菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('控制面板','控制面板菜单',2,'icon-dash_board','/control','控制面板菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('账户管理','账户管理',3,'icon--proxyaccount','/control/account','账户管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('权限管理','权限管理',4,'icon-icon-authority','/control/permission','权限管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('菜单管理','菜单管理',5,'icon-caidan','/control/menu','菜单管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('授权api管理','api管理',6,'icon-api','/control/api','授权api菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('角色管理','角色管理',7,'icon-role','/control/role','角色管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('审计管理','审计管理',8,'icon-audio','/audio','审计管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('错误日志','错误日志',9,'icon-errorcorrection_default','/control/audio-error','错误日志菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('操作日志','操作日志',10,'icon-errorcorrection_default','/control/audio-oper','操作日志菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('调度任务','调度任务',11,'icon-schedule_date','/control/scheduled_task','调度任务菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('租户管理','租户管理',12,'icon-tenancy','/control/tenancy','租户管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('部门管理','部门管理',13,'icon-bumen','/control/department','部门管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('岗位管理','岗位管理',14,'icon-gangwei','/control/post','岗位管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('多语言管理','多语言管理',15,'icon-EA','/control/translate','多语言管理菜单');
INSERT INTO asf_permission_menu (title,subtitle,permission_id,icon,menu_url,description) VALUES ('tiny富文本','tiny富文本',16,'icon-EA','/editor','富文本编辑器');
-- 插入api 权限数据
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (1, '获取控制台信息权限',2,'/api/asf/dash/getdetails','get',1,'获取控制台信息权限');

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (3, '获取账户列表',2,'/api/asf/account/getlist','get',1,'获取账户信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '添加账户',2,'/api/asf/account/create','post',1,'添加账户信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户',2,'/api/asf/account/modify','post,put',1,'修改账户信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (3, '获取账户详情',2,'/api/asf/account/details','get',1,'获取账户信息详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '删除账户',2,'/api/asf/account/delete/[0-9]{1,12}','post,delete',1,'删除账户信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户状态',2,'/api/asf/account/modifystatus','post,put',1,'修改账户状态权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户密码',2,'/api/asf/account/resetpassword','post,put',1,'修改账户密码权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户邮箱',2,'/api/asf/account/modifyemail','post,put',1,'修改账户邮箱权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户邮箱',2,'/api/asf/account/modifytelphone','post,put',1,'修改账户手机权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '修改账户头像',2,'/api/asf/account/modifyavatar','post,put',1,'修改账户头像权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '账户分配角色',2,'/api/asf/account/assignrole','post,put',1,'账户分配角色权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '账户分配部门',2,'/api/asf/account/assigndepartment','post,put',1,'账户分配部门权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (3, '账户分配岗位',2,'/api/asf/account/assignpost','post,put',1,'账户分配岗位权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (4, '获取权限列表',2,'/api/asf/permission/getlist','get',1,'获取权限信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (4, '添加权限',2,'/api/asf/permission/create','post',1,'添加权限信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (4, '修改权限',2,'/api/asf/permission/modify','post,put',1,'修改权限信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (4, '获取权限详情',2,'/api/asf/permission/details','get',1,'获取权限详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (4, '删除权限',2,'/api/asf/permission/delete/[0-9]{1,12}','post,delete',1,'删除权限信息权限',1);



INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (5, '获取菜单列表',2,'/api/asf/menu/getlist','get',1,'获取菜单信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (5, '添加菜单',2,'/api/asf/menu/create','post',1,'添加菜单信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (5, '修改菜单',2,'/api/asf/menu/modify','post,put',1,'修改菜单信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (5, '获取菜单详情',2,'/api/asf/menu/details','get',1,'获取菜单详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (5, '删除菜单',2,'/api/asf/menu/delete/[0-9]{1,12}','post,delete',1,'删除菜单信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (5, '修改菜单是否隐藏',2,'/api/asf/menu/modifyhidden','post,put',1,'修改菜单隐藏权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (6, '获取api列表',2,'/api/asf/api/getlist','get',1,'获取api信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (6, '添加api',2,'/api/asf/api/create','post',1,'添加api信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (6, '修改api',2,'/api/asf/api/modify','post,put',1,'修改api信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (6, '获取api详情',2,'/api/asf/api/details','get',1,'获取api详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (6, '删除api',2,'/api/asf/api/delete/[0-9]{1,12}','post,delete',1,'删除api信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (6, '删除api',2,'/api/asf/api/batchdelete','post,delete',1,'批量删除api信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (6, '是否禁用api',2,'/api/asf/api/modifystatus','post,put',1,'是否禁用api',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (7, '获取角色列表',2,'/api/asf/role/getlist','get',1,'获取角色信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (7, '添加角色',2,'/api/asf/role/create','post',1,'添加角色信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (7, '修改角色',2,'/api/asf/role/modify','post,put',1,'修改角色信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (7, '获取角色详情',2,'/api/asf/role/details','get',1,'获取角色详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (7, '删除角色',2,'/api/asf/role/delete/[0-9]{1,12}','post,delete',1,'删除角色信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (7, '是否禁用角色',2,'/api/asf/role/modifystatus','post,put',1,'是否禁用角色',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (7, '角色分配权限',2,'/api/asf/role/assignpermission','post,put',1,'角色分配权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (9, '获取错误日志列表',2,'/api/asf/audio/geterrorlist','get',1,'获取错误日志信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (9, '删除错误日志',2,'/api/asf/audio/deleteerror/[0-9]{1,12}','post,delete',1,'删除错误日志信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (10, '获取操作日志列表',2,'/api/asf/audio/getloglist','get',1,'获取操作日志信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (10, '删除操作日志',2,'/api/asf/audio/deletelog/[0-9]{1,12}','post,delete',1,'删除操作日志信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (11, '获取调度任务列表',2,'/api/asf/task/getlist','get',1,'获取调度任务信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (11, '添加调度任务',2,'/api/asf/task/create','post',1,'添加调度任务信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (11, '修改调度任务',2,'/api/asf/task/modify','post,put',1,'修改调度任务信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (11, '获取调度任务详情',2,'/api/asf/task/details','get',1,'获取调度任务详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (11, '删除调度任务',2,'/api/asf/task/delete/[0-9]{1,12}','post,delete',1,'删除调度任务信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (12, '获取租户分页列表',2,'/api/asf/tenancy/getlist','get',1,'获取租户信息分页列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (12, '添加租户',2,'/api/asf/tenancy/create','post',1,'添加租户信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (12, '修改租户',2,'/api/asf/tenancy/modify','post,put',1,'修改租户信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (12, '获取租户详情',2,'/api/asf/tenancy/details','get',1,'获取租户详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (12, '删除租户',2,'/api/asf/tenancy/delete','post,put',1,'删除租户信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (13, '获取部门分页列表',2,'/api/asf/department/getlist','get',1,'获取部门信息分页列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (13, '获取部门列表',2,'/api/asf/department/getlists','get',1,'获取部门信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (13, '添加部门',2,'/api/asf/department/create','post',1,'添加部门信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (13, '修改部门',2,'/api/asf/department/modify','post,put',1,'修改部门信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (13, '获取部门详情',2,'/api/asf/department/details','get',1,'获取部门详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (13, '分配部门角色',2,'/api/asf/department/assign','post,put',1,'分配部门角色',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (14, '获取岗位分页列表',2,'/api/asf/post/getlist','get',1,'获取岗位信息分页列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (14, '获取岗位列表',2,'/api/asf/post/getlists','get',1,'获取岗位信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (14, '添加岗位',2,'/api/asf/post/create','post',1,'添加岗位信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (14, '修改岗位',2,'/api/asf/post/modify','post,put',1,'修改岗位信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (14, '获取岗位详情',2,'/api/asf/post/details','get',1,'获取岗位详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (14, '删除岗位',2,'/api/asf/post/delete/[0-9]{1,12}','post,delete',1,'删除岗位信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (15, '获取多语言分页列表',2,'/api/asf/translate/getlist','get',1,'获取多语言信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (15, '获取多语言所有列表',2,'/api/asf/translate/getlists','get',1,'获取多语言信息列表权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (15, '添加多语言',2,'/api/asf/translate/create','post',1,'添加多语言信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (15, '修改多语言',2,'/api/asf/translate/modify','post,put',1,'修改多语言信息权限',1);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description) VALUES (15, '获取多语言详情',2,'/api/asf/translate/details','get',1,'获取多语言详情权限');
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (15, '删除多语言',2,'/api/asf/translate/delete/[0-9]{1,12}','post,delete',1,'删除多语言信息权限',1);

INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '登录',1,'/api/asf/authorise/login','post',1,'登录账户权限',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '登出',1,'/api/asf/authorise/logout','post',1,'登出账户权限',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '获取登录账户信息',1,'/api/asf/account/accountinfo','get',1,'登出账户权限',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '获取租户列表集合',1,'/api/asf/tenancy/getlists','get',1,'获取租户列表集合',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '获取富文本内容',1,'/api/asf/editor/getlists','get',1,'获取富文本内容',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '修改富文本内容',1,'/api/asf/editor/modify','put',1,'修改富文本内容',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '获取轮播图',1,'/api/asf/editor/getbanner','get',1,'获取轮播图',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '提交咨询内容',1,'/api/asf/editor/concat','get',1,'提交咨询内容',0);
INSERT INTO asf_apis (permission_id, name,type,path,http_methods,is_system,description,is_logger) VALUES (16, '咨询内容列表',1,'/api/asf/editor/getConcatList','get',1,'咨询内容列表',0);
-- 插入角色数据
INSERT INTO asf_role (tenancy_id,name,description,create_id) VALUES (1, 'superadmin', '总超级管理员拥有下属租户所有权限',1);
INSERT INTO asf_role (tenancy_id,name,description,create_id) VALUES (1, 'admin', '普通管理员，拥有部分权限',1);
INSERT INTO asf_role (tenancy_id,name,description,create_id) VALUES (1, 'user', '总部 普通员工, 拥有普通权限',1);

-- 分配角色权限
-- 总系统超级管理员
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,1);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,2);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,3);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,4);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,5);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,6);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,7);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,8);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,9);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,10);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,11);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,12);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,13);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,14);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,15);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (1,16);
--  下属租户运维部权限
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,1);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,2);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,6);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,7);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,8);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,9);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,10);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,12);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,13);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,14);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,15);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (2,16);
-- 下属租户普通员工
-- INSERT INTO asf_role_permission (role_id,permission_id) VALUES (3,1);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (3,1);
INSERT INTO asf_role_permission (role_id,permission_id) VALUES (3,16);
-- 插入部门数据
INSERT INTO asf_department (tenancy_id,name) VALUES(1,'开发部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'.net 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'java 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'app 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'php 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'前端 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'ui 组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(1,1,'运维 组');

INSERT INTO asf_department (tenancy_id,name) VALUES(1,'人事部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(9,1,'人事一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(9,1,'人事二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(9,1,'人事三组');

INSERT INTO asf_department (tenancy_id,name) VALUES(1,'财务部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(13,1,'财务一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(13,1,'财务二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(13,1,'财务三组');

INSERT INTO asf_department (tenancy_id,name) VALUES(1,'运营部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(17,1,'运营一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(17,1,'运营二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(17,1,'运营三组');

INSERT INTO asf_department (tenancy_id,name) VALUES(2,'人事部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(21,2,'人事一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(21,2,'人事二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(21,2,'人事三组');

INSERT INTO asf_department (tenancy_id,name) VALUES(2,'财务部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(25,2,'财务一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(25,2,'财务二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(25,2,'财务三组');

INSERT INTO asf_department (tenancy_id,name) VALUES(2,'运营部');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(29,2,'运营一组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(29,2,'运营二组');
INSERT INTO asf_department (pid,tenancy_id,name) VALUES(29,2,'运营三组');
-- 插入岗位数据
INSERT INTO asf_post (tenancy_id, name) VALUES (1, 'java 开发');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '运维');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '.net 开发');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, 'android 开发');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '前端 开发');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, 'ios 开发');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '员工');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '组长');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '经理');
INSERT INTO asf_post (tenancy_id, name) VALUES (1, '主管');

INSERT INTO asf_post (tenancy_id, name) VALUES (2, '员工');
INSERT INTO asf_post (tenancy_id, name) VALUES (2, '组长');
INSERT INTO asf_post (tenancy_id, name) VALUES (2, '经理');
INSERT INTO asf_post (tenancy_id, name) VALUES (2, '主管');

-- 插入用户数据
INSERT INTO asf_accounts (tenancy_id,department_id,name,username,password,password_salt,telphone,email,avatar,sex) VALUES (1, 2, 'keep_wan', 'admin', '20V6MgmX8XVtiRz10AI4Ib5H16a9JyrNmSwmgJ2k0iI=', '8283e4c3-f87e-4d85-85fb-f5c0de063992', '86+13800000000', 'admin@qq.com', '/avatar.jpg', 1);
-- 分配账户角色
INSERT INTO asf_account_role (account_id,role_id) VALUES (1,3);
--  分配角色到部门
INSERT INTO asf_department_role (department_id,role_id) VALUES (1,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (2,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (3,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (4,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (5,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (6,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (7,1);
INSERT INTO asf_department_role (department_id,role_id) VALUES (8,2);
INSERT INTO asf_department_role (department_id,role_id) VALUES (9,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (10,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (11,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (12,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (13,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (14,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (15,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (16,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (17,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (18,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (19,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (20,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (21,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (22,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (23,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (24,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (25,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (26,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (27,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (28,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (29,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (30,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (31,3);
INSERT INTO asf_department_role (department_id,role_id) VALUES (32,3);
--  分配账户岗位
INSERT INTO asf_account_post (account_id,post_id) VALUES (1,3);
INSERT INTO asf_account_post (account_id,post_id) VALUES (1,7);
-- 插入默认富文本内容
INSERT INTO asf_editor (name,type,path,banner,old_content) VALUES  ('首页',1,'/var/www/html/441/index.html','{"indexBanner":"https://s1.imagehub.cc/images/2021/07/10/_20210710094116b65d7190215c67be.jpg,https://s1.imagehub.cc/images/2021/07/10/_2021071009442886dbe32710da6040.jpg,https://s1.imagehub.cc/images/2021/07/10/_2021071009443888c5c4f50f2284c0.jpg"}','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司概况',2,'/var/www/html/441/a/gongsigaikuang/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司概念',3,'/var/www/html/441/a/gongsigainian/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司网络',4,'/var/www/html/441/a/gongsiwangluo/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('设备展示',5,'/var/www/html/441/a/products/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('工程案例->工业厂房强夯',6,'/var/www/html/441/a/jingmi/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('工程案例->道路强夯',7,'/var/www/html/441/a/jingmi/index1.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('工程案例->机场码头强夯',8,'/var/www/html/441/a/jingmi/index2.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('工程案例->住宅强夯',9,'/var/www/html/441/a/jingmi/index3.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('新闻中心',10,'/var/www/html/441/a/news/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新闻',11,'/var/www/html/441/a/gongsixinwen/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新闻内容1',12,'/var/www/html/441/a/gongsixinwen/18.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新闻内容2',13,'/var/www/html/441/a/gongsixinwen/17.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新闻内容3',14,'/var/www/html/441/a/gongsixinwen/16.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新文内容4',15,'/var/www/html/441/a/gongsixinwen/15.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('公司新闻内容5',16,'/var/www/html/441/a/gongsixinwen/14.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻',17,'/var/www/html/441/a/xingyexinwen/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻1',18,'/var/www/html/441/a/xingyexinwen/24.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻2',19,'/var/www/html/441/a/xingyexinwen/23.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻3',20,'/var/www/html/441/a/xingyexinwen/22.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻4',21,'/var/www/html/441/a/xingyexinwen/21.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('行业新闻5',22,'/var/www/html/441/a/xingyexinwen/20.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示',23,'/var/www/html/441/a/jishuzhanshi/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示1',24,'/var/www/html/441/a/jishuzhanshi/33.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示2',25,'/var/www/html/441/a/jishuzhanshi/32.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示3',26,'/var/www/html/441/a/jishuzhanshi/31.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示4',27,'/var/www/html/441/a/jishuzhanshi/30.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('技术展示5',28,'/var/www/html/441/a/jishuzhanshi/29.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('资质证书',29,'/var/www/html/441/a/service/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('在线留言',30,'/var/www/html/441/a/feedback/index.html','');
INSERT INTO asf_editor (name,type,path,old_content) VALUES ('联系我们',31,'/var/www/html/441/a/contact/index.html','');