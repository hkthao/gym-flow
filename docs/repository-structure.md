# Hướng dẫn Cấu trúc Repository

Chào mừng đến với dự án GymFlow! Tài liệu này cung cấp một cái nhìn chi tiết về cấu trúc của repository để giúp các nhà phát triển (developer) điều hướng codebase một cách hiệu quả.

## Cấu trúc Thư mục Cấp cao nhất

Đây là tổng quan về các thư mục và tệp chính ở cấp cao nhất của repository:

```
gym-flow/
├── .github/              # Các tệp cấu hình cho GitHub (workflows, issue templates).
├── docs/                 # Tài liệu dự án (kiến trúc, hướng dẫn, v.v.).
├── monitoring/           # Cấu hình cho Prometheus, Grafana, và Alertmanager.
├── services/             # Chứa tất cả các microservice.
├── .env.example          # Tệp môi trường mẫu cho việc phát triển cục bộ.
├── .gitignore            # Chỉ định các tệp không cần theo dõi bởi Git.
├── docker-compose.yml    # Định nghĩa các service của ứng dụng cho phát triển cục bộ.
├── docker-compose.override.yml # Định nghĩa các thành phần giám sát (Prometheus, Grafana).
└── README.md             # Tệp chính cung cấp thông tin tổng quan về dự án.
```

### Giải thích các Thư mục Chính

-   **`.github/`**: Thư mục này chứa tất cả các cấu hình liên quan đến GitHub.
    -   `workflows/`: Chứa các định nghĩa pipeline CI/CD cho GitHub Actions.
    -   `ISSUE_TEMPLATE/`: Định nghĩa các mẫu (template) để tạo issue mới (bug, feature).

-   **`docs/`**: Chứa tất cả tài liệu liên quan đến dự án. Đây là nơi tốt nhất để bắt đầu tìm hiểu về tầm nhìn, kiến trúc, và các hướng dẫn phát triển của dự án.

-   **`monitoring/`**: Tất cả các tệp cấu hình cho hệ thống giám sát (Prometheus, Grafana, Alertmanager) được tập trung tại đây.

-   **`services/`**: Đây là thư mục cốt lõi chứa mã nguồn cho mỗi microservice. Mỗi thư mục con đại diện cho một service riêng biệt trong hệ thống.

## Cấu trúc Microservice (`services/`)

Mỗi microservice trong thư mục `services/` tuân theo một cấu trúc nhất quán. Chúng ta sẽ dùng `customer-service` làm ví dụ cho việc áp dụng kiến trúc Clean Architecture cho các service .NET.

### Ví dụ: `customer-service`

```
services/customer-service/
├── src/
│   ├── CustomerService.Api/              # Điểm khởi chạy: Chứa Controllers, Program.cs, appsettings.
│   ├── CustomerService.Application/      # Logic nghiệp vụ: Chứa Services, DTOs, Validators.
│   ├── CustomerService.Domain/           # Các thực thể cốt lõi, enums, và interfaces của repository.
│   └── CustomerService.Infrastructure/   # Truy cập dữ liệu: Chứa DbContext, Repositories, Migrations.
├── tests/
│   ├── CustomerService.UnitTests/        # Unit test cho các tầng Application và Domain.
│   └── CustomerService.IntegrationTests/ # Integration test cho các tầng Api và Infrastructure.
├── Dockerfile                          # Các chỉ dẫn để build Docker image cho service.
└── CustomerService.sln                 # Tệp solution cho service.
```

-   **`Api`**: Tầng trình bày (presentation). Tầng này xử lý các HTTP request, routing, và API response. Nó phụ thuộc vào tầng `Application`.
-   **`Application`**: Chứa logic nghiệp vụ cốt lõi, các service, và các vấn đề cụ thể của ứng dụng. Nó phụ thuộc vào tầng `Domain`.
-   **`Domain`**: Trái tim của service. Tầng này chứa các thực thể (entity) nghiệp vụ cốt lõi, các đối tượng giá trị (value object), và các interface của repository. Nó không có sự phụ thuộc vào các tầng bên ngoài.
-   **`Infrastructure`**: Triển khai các interface được định nghĩa trong tầng `Domain`. Đây là nơi xử lý các mối quan tâm bên ngoài như cơ sở dữ liệu, hệ thống tệp, và các dịch vụ ngoại vi khác.

Việc phân tách các mối quan tâm (separation of concerns) này giúp cho codebase dễ dàng bảo trì, kiểm thử, và mở rộng. Các service khác, như `ai-face-service` được viết bằng Python, cũng tuân theo cấu trúc đặc trưng của framework tương ứng nhưng vẫn duy trì nguyên tắc phân tách này.