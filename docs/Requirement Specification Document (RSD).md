TÀI LIỆU YÊU CẦU PHẦN MỀM (RSD)

### Tầm nhìn sản phẩm (Product Vision)

Hệ thống Gym Management System with Face Recognition giúp phòng gym quản lý thông tin khách hàng, theo dõi check-in/out tự động bằng nhận diện khuôn mặt, và cung cấp báo cáo attendance. Hệ thống hướng tới tăng trải nghiệm khách hàng, giảm thao tác thủ công cho nhân viên, đồng thời bảo mật dữ liệu khách hàng.

### Các bên liên quan (Stakeholders)

| **Vai trò** | **Trách nhiệm** |
| --- | --- |
| Admin / Quản lý | Quản lý thông tin khách hàng, xem báo cáo check-in/out, tạo/disable tài khoản nhân viên |
| Nhân viên lễ tân | Giám sát check-in/out, hỗ trợ khách khi cần |
| Khách hàng | Check-in/out tự động bằng nhận diện khuôn mặt, nhận thông báo nhắc nhở |
| IT Team | Triển khai, bảo trì hệ thống, giám sát logs và bảo mật |

### User Stories

| **Epic (Chức năng lớn)** | **Feature (Tính năng)** | **User Story (Câu chuyện người dùng)** | **MVP** |
| --- | --- | --- | --- |
| **Quản lý người dùng** | Đăng ký/Đăng nhập | Là người dùng mới, tôi muốn đăng ký tài khoản qua Auth0, để có thể truy cập ứng dụng gym một cách an toàn. | ✅ |
| | | Là người dùng đã đăng ký, tôi muốn đăng nhập bằng email hoặc Google, để truy cập hồ sơ của tôi dễ dàng. | ✅ |
| | | Là người dùng, tôi muốn đặt lại mật khẩu qua Auth0, để khôi phục quyền truy cập khi quên mật khẩu. | ✅ |
| | Quản lý hồ sơ cá nhân | Là người dùng, tôi muốn cập nhật thông tin cá nhân (tên, số điện thoại, email), để hồ sơ luôn chính xác. | ✅ |
| | | Là người dùng, tôi muốn xóa tài khoản, để dữ liệu của tôi được loại bỏ khỏi hệ thống. | |
| | Đăng ký khuôn mặt | Là một hội viên mới, tôi muốn đăng ký khuôn mặt của mình một cách an toàn qua một quy trình được hướng dẫn, để hệ thống có thể nhận diện tôi cho các lần check-in sau. | ✅ |
| **Check-in / Check-out** | Check-in/out tự động | Là người dùng, tôi muốn check-in/out tự động bằng cách nhìn vào camera, để không cần dùng thẻ hoặc ứng dụng. | ✅ |
| | Lịch sử check-in | Là người dùng, tôi muốn xem lịch sử check-in, để theo dõi hoạt động tập luyện của mình. | ✅ |
| | Thông báo xác nhận | Là người dùng, tôi muốn nhận thông báo xác nhận sau khi check-in/out, để biết phiên làm việc đã được ghi nhận. | ✅ |
| **Quản lý hội viên** | Thông tin gói hội viên | Là người dùng, tôi muốn xem trạng thái hội viên hiện tại, để biết tôi có thể truy cập phòng gym hay không. | ✅ |
| | Thanh toán & gia hạn | Là người dùng, tôi muốn mua hoặc gia hạn hội viên trực tuyến, để không cần tới quầy lễ tân. | |
| | | Là người dùng, tôi muốn nhận nhắc nhở trước khi hội viên hết hạn, để kịp gia hạn. | |
| **Thông báo** | Push Notification | Là người dùng, tôi muốn nhận thông báo đẩy qua Firebase, để được nhắc nhở về các buổi tập hoặc khuyến mãi. | ✅ |
| | Thông báo hệ thống | Là người dùng, tôi muốn nhận thông báo hệ thống (bảo trì, đóng cửa), để lên kế hoạch tập luyện. | |
| **Báo cáo & Phân tích** | Thống kê người dùng | Là người dùng, tôi muốn xem thống kê check-in tuần/tháng, để theo dõi tiến độ tập luyện. | |
| | Khuyến nghị cá nhân | Là người dùng, tôi muốn nhận gợi ý cá nhân dựa trên lịch sử check-in, để cải thiện kế hoạch tập luyện. | |
| **Admin / Quản lý** | Quản lý người dùng | Là admin, tôi muốn thêm/sửa/xóa tài khoản người dùng, để quản lý hội viên. | ✅ |
| | Giám sát check-in | Là admin, tôi muốn xem tất cả dữ liệu check-in/out, để theo dõi việc sử dụng phòng gym. | ✅ |
| | Quản lý gói hội viên | Là admin, tôi muốn quản lý các gói hội viên (thêm, sửa, xóa), để đảm bảo thành viên đăng ký đúng gói. | |
| | Báo cáo & thống kê | Là admin, tôi muốn tạo báo cáo (hàng ngày/tuần/tháng), để phân tích hiệu suất phòng gym. | |
| | Bảo mật & cảnh báo | Là admin, tôi muốn nhận cảnh báo khi có hoạt động bất thường, để kịp thời xử lý sự cố bảo mật. | |
| **Tùy chọn / Nâng cao** | Đặt lớp tập | Là người dùng, tôi muốn đặt trước các lớp tập, để đảm bảo có chỗ tham gia. | |
| | Quản lý lịch lớp | Là người dùng, tôi muốn hủy hoặc thay đổi lịch đặt lớp, để linh hoạt quản lý thời gian. | |

### Giả định và Ràng buộc (Assumptions and Constraints)

| **Loại** | **Nội dung** |
| --- | --- |
| Giả định | Phòng gym có kết nối mạng ổn định cho các camera và hệ thống. |
| Giả định | Người dùng cuối (hội viên) đồng ý cung cấp dữ liệu khuôn mặt để sử dụng tính năng check-in. |
| Ràng buộc | Hệ thống phải được triển khai trên hạ tầng máy chủ có sẵn của khách hàng. |
| Ràng buộc | Giải pháp nhận diện khuôn mặt phải ưu tiên sử dụng các thư viện mã nguồn mở để tối ưu chi phí. |

### Yêu cầu chức năng (Functional Requirements – MVP)

1.  **Quản lý khách hàng**
    - Tạo / Xem / Cập nhật / Xóa hồ sơ khách hàng.
    - Lưu thông tin cá nhân: Tên, Ngày sinh, Loại membership.
2.  **Đăng ký và Nhận diện Khuôn mặt**
    - **Sự đồng thuận:** Trước khi thu thập dữ liệu, hệ thống phải hiển thị thông báo và yêu cầu sự đồng thuận của khách hàng về việc sử dụng dữ liệu sinh trắc học.
    - **Đăng ký khuôn mặt:** Cung cấp giao diện cho phép người dùng (hoặc nhân viên) chụp và đăng ký dữ liệu khuôn mặt lần đầu. Dữ liệu khuôn mặt phải được mã hóa.
    - **Check-in/out:** Nhận diện khuôn mặt thời gian thực qua camera, so khớp với dữ liệu đã lưu và ghi nhận log (ID khách hàng, thời gian).
3.  **Lưu trữ và Truy vấn**
    - Lưu trữ lịch sử check-in/out.
    - Hỗ trợ truy vấn lịch sử theo ngày, khách hàng.
4.  **Bảng quản trị (Admin Dashboard)**
    - Hiển thị danh sách khách hàng và trạng thái.
    - Xem log check-in/out theo thời gian thực.
    - Quản lý quyền truy cập (admin/nhân viên).
5.  **Bảo mật**
    - Áp dụng Role-Based Access Control (RBAC).
    - Mã hóa dữ liệu nhạy cảm (thông tin cá nhân, dữ liệu khuôn mặt).
6.  **Thông báo**
    - Gửi thông báo trong ứng dụng (in-app notification) xác nhận check-in/out thành công.

### Yêu cầu phi chức năng (Non-Functional Requirements – NFRs)

| **Yêu cầu** | **Mô tả** |
| --- | --- |
| Hiệu năng | Thời gian nhận diện khuôn mặt < 2 giây ngay cả trong giờ cao điểm, với cơ sở dữ liệu 500+ khách hàng. |
| Khả năng mở rộng | Hỗ trợ >500 khách hàng và 2–3 camera cùng lúc trong phiên bản đầu; có khả năng mở rộng trong tương lai. |
| Bảo mật | Mã hóa toàn bộ dữ liệu khách hàng (at-rest và in-transit); áp dụng RBAC cho quyền truy cập. |
| Độ tin cậy | 99% uptime cho dịch vụ check-in. |
| Dễ bảo trì | Kiến trúc Microservices, có CI/CD pipeline tích hợp, code được viết theo unit test. |
| Tuân thủ | Tuân thủ các quy định về bảo vệ dữ liệu (tương tự GDPR). Hệ thống phải hỗ trợ xóa hoàn toàn dữ liệu người dùng khi có yêu cầu. |

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

### Scope MVP & Roadmap

| **Tính năng** | **Ưu tiên** | **Sprint** |
| --- | --- | --- |
| Customer CRUD | Cao | Sprint 1 |
| Face Recognition Check-in/out | Cao | Sprint 2 |
| Attendance Logging | Cao | Sprint 2 |
| Admin Dashboard | Trung bình | Sprint 2 |
| Thông báo | Trung bình | Sprint 3 |
| Hỗ trợ nhiều camera | Thấp | Sprint 4 |
| Dashboard phân tích nâng cao | Thấp | Sprint 4 |

### Tiêu chí nghiệm thu (Acceptance Criteria)

- Customer CRUD hoạt động qua REST API và dashboard.
- Check-in/out bằng face recognition < 2 giây.
- Admin có thể truy vấn log check-in/out.
- Quyền truy cập theo vai trò được áp dụng.
- CI/CD pipeline deploy tự động các phiên bản mới.
- Logs & monitoring hiển thị chỉ số real-time.

### Các cải tiến trong tương lai

- Mobile app cho khách hàng.
- Tối ưu AI model nâng cao accuracy nhận diện khuôn mặt.
- Tích hợp thanh toán/gia hạn membership.
- Dashboard phân tích: attendance trends, retention metrics.
