### Tổng quan kiến trúc (Architecture Overview)

- **Microservices**:
    1. Dịch vụ Quản lý khách hàng
    2. Dịch vụ Nhận diện khuôn mặt
    3. Dịch vụ Check-in/out
    4. Dịch vụ Thông báo
- **Database**: PostgreSQL / MongoDB
- **Frontend**: React.js Admin Dashboard
- **API Gateway**: Điều hướng request tới các dịch vụ
- **CI/CD Pipeline**: Tekton / Jenkins
- **Deployment**: Docker → Kubernetes / OpenShift
- **Monitoring & Logging**: Prometheus + Grafana, centralized logs