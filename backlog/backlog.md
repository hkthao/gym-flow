# Gym-Flow Backlog

## Epic 1: Quản lý Khách hàng (Customer Management) (label: epic)

- [ ] Task 1.1: Thiết kế và tạo database schema cho thông tin khách hàng (label: task)
- [ ] Task 1.2: Xây dựng API cho CRUD (Create, Read, Update, Delete) khách hàng (label: task)
- [ ] Task 1.3: Xây dựng giao diện quản lý khách hàng trên dashboard admin (label: task)
- [ ] Task 1.4: Tích hợp API quản lý khách hàng với giao diện dashboard (label: task)
- [ ] Task 1.5: Viết unit test cho API quản lý khách hàng (label: task)
- [ ] Task 1.6: Viết integration test cho luồng quản lý khách hàng (label: task)

## Epic 2: Check-in/Check-out (label: epic)

- [ ] Task 2.1: Nghiên cứu và lựa chọn thư viện nhận diện khuôn mặt (label: task)
- [ ] Task 2.2: Xây dựng API đăng ký khuôn mặt cho khách hàng (label: task)
- [ ] Task 2.3: Xây dựng API nhận diện khuôn mặt và ghi nhận check-in/out (label: task)
- [ ] Task 2.4: Thiết kế và tạo database schema cho lịch sử check-in/out (label: task)
- [ ] Task 2.5: Xây dựng giao diện check-in/out trên dashboard admin (label: task)
- [ ] Task 2.6: Tích hợp API check-in/out với giao diện dashboard (label: task)
- [ ] Task 2.7: Viết unit test cho API check-in/out (label: task)

## Epic 3: CI/CD (Continuous Integration/Continuous Deployment) (label: epic)

- [ ] Task 3.1: Cấu hình GitHub Actions cho CI (build & test) (label: task)
- [ ] Task 3.2: Viết Dockerfile cho các microservices (ASP.NET Core, Python) (label: task)
- [ ] Task 3.3: Cấu hình pipeline để build và push Docker image lên container registry (label: task)
- [ ] Task 3.4: Cấu hình CD pipeline để deploy ứng dụng lên Kubernetes (label: task)
- [ ] Task 3.5: Tích hợp linting và static analysis vào CI pipeline (label: task)

## Epic 4: IAM (Identity & Access Management) (label: epic)

- [ ] Task 4.1: Tích hợp Auth0 hoặc IdentityServer cho xác thực người dùng (label: task)
- [ ] Task 4.2: Cấu hình Role-Based Access Control (RBAC) cho các vai trò (admin, staff, member) (label: task)
- [ ] Task 4.3: Xây dựng API bảo vệ các endpoint dựa trên vai trò người dùng (label: task)
- [ ] Task 4.4: Xây dựng giao diện đăng nhập và quản lý tài khoản người dùng (label: task)

## Epic 5: Cloud/DevOps (label: epic)

- [ ] Task 5.1: Viết mã IaC (Infrastructure as Code) bằng Terraform để tạo hạ tầng (VPC, Kubernetes cluster) (label: task)
- [ ] Task 5.2: Cấu hình Helm chart cho việc deploy ứng dụng (label: task)
- [ ] Task 5.3: Cấu hình môi trường dev, staging, production (label: task)
- [ ] Task 5.4: Tự động hóa việc tạo và quản lý môi trường (label: task)

## Epic 6: Giám sát & Bảo mật (Monitoring & Security) (label: epic)

- [ ] Task 6.1: Tích hợp Prometheus để thu thập metrics từ các service (label: task)
- [ ] Task 6.2: Xây dựng Grafana dashboard để giám sát health, performance, error rate (label: task)
- [ ] Task 6.3: Cấu hình hệ thống logging tập trung (Loki/ELK) (label: task)
- [ ] Task 6.4: Tích hợp OpenTelemetry για distributed tracing (label: task)
- [ ] Task 6.5: Quét lỗ hổng bảo mật cho container images và dependencies (label: task)
- [ ] Task 6.6: Cấu hình và quản lý secrets bằng Vault hoặc Kubernetes Secrets (label: task)