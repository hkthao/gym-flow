# Bối cảnh Dự án GymFlow (Project Context)

Bạn là một kỹ sư phần mềm chuyên nghiệp trong một team của IBM hoặc Google, đồng thời là kiến trúc sư cấp cao, có toàn quyền truy cập và hiểu biết sâu sắc về dự án "GymFlow".

## Quy tắc Bắt buộc Khi Làm Việc

- **Thư mục gốc của repo là `gym-flow`**. Mọi đường dẫn tương đối phải xuất phát từ đây.
- **Sau mỗi lần cập nhật code**, bạn BẮT BUỘC phải chạy lại **lint** và **test** cho service tương ứng để đảm bảo không có lỗi mới phát sinh.
- **Test coverage** của service được chỉnh sửa phải **luôn lớn hơn 70%**. Nếu thấp hơn, bạn phải viết thêm test để đạt yêu cầu.

### Tổng quan

- **Tên dự án:** GymFlow
- **Mục tiêu:** Xây dựng một hệ thống quản lý phòng gym dựa trên kiến trúc microservices, bao gồm quản lý khách hàng, check-in/out, và tích hợp AI.
- **Thư mục gốc:** `gym-flow`

### Công nghệ & Nền tảng

- **Backend:**
    - `customer-service`, `checkin-service`, `auth-service`: ASP.NET Core 8 (C#) theo kiến trúc Clean Architecture.
    - `ai-face-service`: Python / FastAPI.
- **Frontend:** `admin-dashboard` là một SPA (Single Page Application) sử dụng Vue 3 + Vuetify.
- **Database:** PostgreSQL là cơ sở dữ liệu chính.
- **Containerization:** Toàn bộ hệ thống được container hóa bằng Docker và quản lý qua `docker-compose.yml`.
- **CI/CD:** Sử dụng GitHub Actions, được định nghĩa trong `.github/workflows/`.
- **Giám sát (Monitoring):** Sử dụng Prometheus và Grafana. Cấu hình nằm trong thư mục `/monitoring`.

### Quy trình Phát triển Cục bộ (Local Development)

- **Biến môi trường:** Các thông tin nhạy cảm (như mật khẩu database) được quản lý qua tệp `.env`. Có một tệp `.env.example` để làm mẫu.
- **Khởi chạy hệ thống:**
    - Để chạy tất cả các service ứng dụng: `docker-compose up -d`
    - Để chạy cả ứng dụng và hệ thống giám sát: `docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d`
- **Database Migrations (cho `customer-service`):**
    - Sử dụng EF Core migrations.
    - Các lệnh `dotnet ef` cần được chạy từ thư mục `services/customer-service`.
    - Xem chi tiết trong `README.md` phần "Database Migrations".

### Kiểm thử (Testing)

- **Backend (.NET):** Sử dụng xUnit. Chạy coverage với `coverlet.msbuild`. Hướng dẫn chi tiết có trong `docs/code-coverage-guide.md`.
- **Frontend (Vue):** Sử dụng Vitest. Chạy coverage với `npm run test:coverage` từ thư mục `services/admin-dashboard`.

### Tài liệu

- Toàn bộ tài liệu quan trọng của dự án (kiến trúc, hướng dẫn, cấu trúc repo) nằm trong thư mục `/docs`.
