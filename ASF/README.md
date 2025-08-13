# asf
asf 多租户rbac 权限管理系统后端
- 运行方式 在 asf.web目录下面 `appsettings.json` 内修改本地数据库连接方式与数据库类型 数据库类型是个枚举类型,修改完成之后运行 ./bash 迁移数据表到数据库中。 然后导入对应的初始化数据sql脚本; 运行程序;
docker exec -ti b8e3c4793c8f2f1c8d751d4190dcd41bd977e67b2acaed994bf1248622f0c158 pg_dump  -U postgres -d asf -O -x -c --inserts --if-exists --quote-all-identifiers >./db.sql
