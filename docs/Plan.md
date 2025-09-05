**GYM MANAGEMENT SYSTEM WITH FACE RECOGNITION**

### Quản lý Rủi ro (Risk Management)

| **Rủi ro tiềm ẩn**                                              | **Mức độ ảnh hưởng** | **Phương án giảm thiểu**                                                                                                                       |
| --------------------------------------------------------------- | -------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------- |
| Độ chính xác của model nhận diện khuôn mặt thấp hơn kỳ vọng     | Cao                  | Bắt đầu nghiên cứu và thử nghiệm các thư viện (dlib, OpenCV, face-api.js) từ sớm. Chuẩn bị phương án dự phòng như check-in bằng mã QR nếu cần. |
| Chậm trễ trong việc setup môi trường DevOps (Kubernetes, CI/CD) | Trung bình           | Ưu tiên hoàn thành luồng phát triển ở local trước. Bắt đầu quá trình setup môi trường song song với giai đoạn đầu của implementation.          |
| Khối lượng công việc cho một người quá lớn                      | Cao                  | Bám sát phạm vi MVP, tránh sa đà vào các tính năng phức tạp. Tái sử dụng các thành phần mã nguồn mở càng nhiều càng tốt.                       |

---

### Giai đoạn 0: Định nghĩa yêu cầu & Product Vision

**Mục tiêu:** Hiểu rõ sản phẩm, user stories, scope MVP.
**Thời gian dự kiến:** 1 tuần
**Sản phẩm đầu ra:** Tài liệu Yêu cầu Phần mềm (RSD) đã được đánh giá và hoàn thiện.

**Tasks:**

1.  **Xác định user stories & use cases**:
    - Quản lý thông tin khách hàng: tạo, cập nhật, xóa profile.
    - Check-in/out bằng nhận diện khuôn mặt.
    - Quản lý lịch tập, thông báo nhắc nhở.
2.  **Xác định MVP**:
    - Backend API cho profile + check-in/out.
    - Frontend admin dashboard.
    - Face recognition cơ bản (1 camera, real-time).
    - Logging & audit check-in/out.
3.  **Define non-functional requirements**:
    - Security: face data privacy, IAM, role-based access.
    - Scalability: số lượng khách hàng, số lượng camera.
    - Performance: nhận diện <2s.

**Áp dụng kiến thức:**

- Software Engineering: requirement analysis, user story mapping.
- Software Architecture: NFRs, constraints, design goals.

### Giai đoạn 1: Thiết kế kiến trúc (Architecture & Design)

**Mục tiêu:** Vẽ sơ đồ kiến trúc microservices & các module chính.
**Thời gian dự kiến:** 1 tuần
**Sản phẩm đầu ra:** Sơ đồ kiến trúc hệ thống v1.0, Tài liệu đặc tả API (API Spec) v1.0, Sequence diagram cho các luồng chính.

**Tasks:**

1.  **Xác định kiến trúc**: Microservices hoặc Modular Monolith cho MVP:
    - Service Customer Management
    - Service Face Recognition
    - Service Check-in/out
    - API Gateway (cho frontend & camera integration)
    - Database Service
2.  **Chọn công nghệ**:
    - Backend: Python Flask/FastAPI hoặc Node.js
    - Frontend: React.js / Vue.js
    - Database: PostgreSQL / MongoDB
    - Face recognition: OpenCV + dlib hoặc face-api.js
3.  **Thiết kế component diagram & sequence diagram**:
    - Sequence: Camera → Face Recognition → Customer Service → Check-in/out log
4.  **Design patterns**:
    - Singleton: Face Recognition model loader
    - Observer: Check-in/out event logging
    - Factory: Service creation

**Áp dụng kiến thức:**

- Software Design & Architecture: patterns, modularization, layered design, SOLID principles.

### Giai đoạn 2: Setup DevOps & Environment

**Mục tiêu:** Chuẩn bị môi trường phát triển, CI/CD, containerization.
**Thời gian dự kiến:** 2 tuần
**Sản phẩm đầu ra:** Repository Git, Dockerfiles cho các service, Kịch bản CI/CD cơ bản, Môi trường dev local (Docker Compose).

**Tasks:**

1.  **Version Control**: Git + GitHub repo
2.  **Containerization**: Docker cho từng microservice
3.  **Local Environment**: Setup Docker Compose để chạy các services cùng nhau.
4.  **CI/CD Pipeline** (GitHub Actions):
    - Lint → Unit Test → Build → Docker Push
5.  **Monitoring & Logging**: Lên kế hoạch tích hợp Prometheus/Grafana và ELK Stack.

**Áp dụng kiến thức:**

- IBM DevOps: CI/CD pipeline, automated testing, containerization, cloud deployment.

### Giai đoạn 3: Implementation (MVP)

**Mục tiêu:** Viết code cho các tính năng MVP.
**Thời gian dự kiến:** 3 tuần
**Sản phẩm đầu ra:** Mã nguồn Backend API, Module nhận diện khuôn mặt, Giao diện Admin Dashboard, Unit & Integration tests.

**Tasks:**

1.  **Backend APIs**:
    - Customer CRUD
    - Check-in/out logging
    - Authentication & authorization
2.  **Face Recognition Module**:
    - Train/Enroll face dataset
    - Detect & Match face → return customer ID
3.  **Frontend Dashboard**:
    - Admin: manage users, check-in logs, reporting
4.  **Database & ORM setup**:
    - Tables: Customers, Checkins, Sessions, etc.
5.  **Unit & Integration Tests** (TDD):
    - Python unittest / pytest, Node.js jest
    - Mock face recognition for testing

**Áp dụng kiến thức:**

- Software Engineering: TDD, unit & integration testing, CI integration
- Software Design: modular, maintainable, SOLID code

### Giai đoạn 4: Integration & Testing

**Mục tiêu:** Kiểm thử toàn hệ thống, load test, security test.
**Thời gian dự kiến:** 1 tuần
**Sản phẩm đầu ra:** Báo cáo kết quả End-to-end testing, Báo cáo performance test, Danh sách bug đã được ghi nhận và fix.

**Tasks:**

1.  **End-to-end testing**: Postman / Cypress
2.  **Load & Performance test**:
    - N concurrent check-in requests
3.  **Security testing**:
    - Role-based access control
    - Face data encryption & privacy
4.  **Bug fixing & refactoring**

**Áp dụng kiến thức:**

- DevOps & Software Engineering: CI/CD test stage, automated regression tests

### Giai đoạn 5: Deployment & Monitoring

**Mục tiêu:** Deploy stable version lên môi trường production, monitor metrics.
**Thời gian dự kiến:** 1 tuần
**Sản phẩm đầu ra:** Hệ thống chạy trên môi trường production, Dashboard giám sát, Quy trình cảnh báo và ghi log.

**Tasks:**

1.  Deploy to **production environment** (K8s / OpenShift)
2.  Configure **alerts & dashboards**:
    - CPU/Memory, API response time, Face Recognition latency
3.  Configure **audit logs**: check-in/out events

**Áp dụng kiến thức:**

- DevOps: continuous monitoring, alerting, incident response
- Security: auditing & logging, compliance with privacy

### Giai đoạn 6: Future Enhancements

- Multi-camera support
- Mobile app integration
- AI model improvement (face recognition accuracy)
- Analytics dashboard: attendance patterns, retention metrics
