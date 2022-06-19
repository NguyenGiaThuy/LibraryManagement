# Giới thiệu Project
Với sự phát triển không ngừng của thế giới hiện đại, con người ngày càng khám phá ra nhiều tri thức mới, đồng nghĩa với việc kiến thức nhân loại ngày càng nhiều hơn dẫn đến việc bùng nổ nhu cầu về sách cũng như các thư viện. Dẫn đến nhu cầu về phần mềm quản lý thư viện rất cao nhưng ở Việt Nam hiện chưa có nhiều phần mềm tốt.

Đây là dự án phát triển ứng dụng thư viện thuần Việt (hỗ trợ ngôn ngữ Việt Nam) đã được ấp ủ rất lâu nhưng đến bây giờ mới có cơ hội thực hiện, nhằm hỗ trợ người Việt thuận tiện hơn trong quá trình sử dụng.

Project link: https://github.com/NguyenGiaThuy/LibraryManagement

## Mục lục

- [Giới thiệu Project](#giới-thiệu-project)
  - [Mục lục](#mục-lục)
  - [Project liên quan](#project-liên-quan)
  - [Môi trường thực thi](#môi-trường-thực-thi)
  - [Cấu hình project chạy local](#cấu-hình-project-chạy-local)
  - [Deploy project](#deploy-project)
  - [Demo](#demo)
  - [Tiến độ hiện tại](#tiến-độ-hiện-tại)
  - [Tính năng chưa triển khai](#tính-năng-chưa-triển-khai)

## Project liên quan
Project của nhóm chỉ có 1 Gihub repository, đã dẫn link phía trên.

## Môi trường thực thi
Hệ điều hành: **Windows 7, 8, 9, 10, 11**

Cơ sở dữ liệu: **Microsoft SQL Server**

Frameworks and libraries: **ASP.NET Core**, **EF Core** và **WPF** trên nền tảng **.NET 6.0**

## Cấu hình project chạy local
Mở file ``Server/appsettings.json`` để xem thông tin **localhost** và **libmproddb**:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "localhost": "Data Source=localhost;Initial Catalog=LibraryManagement;Integrated Security=True",
    "libmproddb": "Data Source=libmanagement.database.windows.net;Initial Catalog=LibraryManagement;Persist Security Info=True;User ID=libadmin;Password=P@ssw0rd"
  },
  "AllowedHosts": "*"
}
```
Mở file ``Server/Models/LibraryManagementContext.cs`` để cấu hình:
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer("Name=localhost");
    }
}
```

## Deploy project
Đây là app dành cho PC nên chỉ có thể truy cập server thông qua API
![image](https://github.com/NguyenGiaThuy/LibraryManagement/blob/main/Image/deploy.png)

## Demo


## Tiến độ hiện tại
Hoàn thành các chức năng cơ bản:
+ Thêm, xóa, sửa nhân viên
+ Thêm, xóa, sửa sách
+ Thêm, xóa, sửa thẻ mượn sách
+ Thêm xóa, sửa độc giả
+ Thống kê các thông số
+ Giao diện cơ bản

## Tính năng chưa triển khai
- Nâng cấp giao diện 
- Bổ sung thêm tính năng hiẻn thị một số thông tin trong phiếu mượn phạt sách khi lập 
phiếu phạt.
- Tinh chỉnh giao diện phù hợp hơn với người dùng.

