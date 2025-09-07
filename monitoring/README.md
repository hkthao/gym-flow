# Cấu hình Giám sát (Monitoring)

Thư mục này chứa tất cả các tệp cấu hình cần thiết cho hệ thống giám sát và cảnh báo của dự án, dựa trên Prometheus và Grafana.

## Tổng quan

Hệ thống giám sát được định nghĩa trong tệp `docker-compose.override.yml` ở thư mục gốc của repository. Nó bao gồm các dịch vụ sau:

-   **Prometheus:** Thu thập và lưu trữ các chỉ số (metrics) từ các microservice.
-   **Grafana:** Trực quan hóa các chỉ số được thu thập bởi Prometheus thông qua các dashboard.
-   **Alertmanager:** Xử lý các cảnh báo (alerts) được gửi bởi Prometheus.
-   **cAdvisor:** Cung cấp các chỉ số giám sát cho container.

## Cấu trúc Tệp

-   `prometheus.yml`: Tệp cấu hình chính cho Prometheus. Nó định nghĩa các mục tiêu (target, tức là các service) cần được scrape để lấy metrics.
-   `alertmanager.yml`: Tệp cấu hình cho Alertmanager, định nghĩa cách các cảnh báo được xử lý và định tuyến.
-   `rules.yml`: Chứa các định nghĩa về quy tắc cảnh báo (alerting rules). Prometheus sử dụng tệp này để xác định khi nào cần kích hoạt một cảnh báo.

## Cách sử dụng

1.  **Khởi chạy Hệ thống Giám sát:**
    Để chạy các dịch vụ giám sát cùng với ứng dụng, hãy sử dụng tệp `docker-compose.override.yml` từ thư mục gốc của dự án:
    ```bash
    docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
    ```

2.  **Truy cập các Dịch vụ:**
    -   **Prometheus:** `http://localhost:9090`
    -   **Grafana:** `http://localhost:3000` (Đăng nhập mặc định: `admin`/`admin`)
    -   **Alertmanager:** `http://localhost:9093`
    -   **cAdvisor:** `http://localhost:8080`

3.  **Cấu hình Grafana:**
    Trong lần chạy đầu tiên, bạn sẽ cần cấu hình Grafana để sử dụng Prometheus làm nguồn dữ liệu (data source):
    -   Đăng nhập vào Grafana.
    -   Đi đến `Configuration > Data Sources`.
    -   Nhấp vào `Add data source` và chọn `Prometheus`.
    -   Đặt `HTTP > URL` thành `http://prometheus:9090`.
    -   Nhấp vào `Save & Test`.

Bây giờ bạn có thể tạo các dashboard trong Grafana để trực quan hóa các chỉ số của ứng dụng.