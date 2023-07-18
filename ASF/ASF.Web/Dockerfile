FROM mcr.microsoft.com/dotnet/sdk:7.0
# 复制项目到镜像的根目录中
COPY . /dockernode/dotnet
# 启动容器时，进入的目录
WORKDIR /dockernode/dotnet
# 该向外暴露端口是jwtDemo项目的端口
#EXPOSE 80
ENTRYPOINT [ "dotnet", "ASF.Web.dll" ]
