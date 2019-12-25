# Dotnet Core Template

>  Mẫu được tạo dự theo principles Clean Architecture, CRSQ

**Technologies**
*  Dotnet Net Core 3.1
*  FluentValidation 8.6.0 (Dùng trong validate dữ liệu
*  MediatR 7.0.0 (Dùng để hiện thực CRSQ)
*  Serilog 2.9.0 (Dùng ghi log)
*  Microsoft.EntityFrameworkCore 3.1.0 (Kết nối database)
*  

# Overview

**Domain**

Chứa toàn bộ các entities, enums, exceptions, interfaces, types và code logic của domain

**Application**

Chứa tất các các logic của ứng dụng, Nó chỉ phụ thuộc layer Domain, Là nơi định nghĩa các Interfaces giao tiếp với bên ngoài

**Infrastructure**

Chứa tất cả các lớp dùng thực hiện giao tiếp với hệ thống bên ngoài ví dụ như File, Database, Webservice, ResApi, Queue