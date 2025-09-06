# Hướng dẫn chạy Test Coverage trong .NET Core Project

Chào bạn, với vai trò là một kỹ sư DevOps, tôi sẽ hướng dẫn bạn cách chạy và tích hợp test coverage cho dự án .NET Core của chúng ta một cách chi tiết, dễ hiểu.

## 1. Cách chạy Test Coverage cục bộ

Để chạy test coverage trên máy cục bộ, chúng ta sẽ sử dụng `coverlet` tích hợp sẵn với `dotnet test`. `coverlet` là một công cụ mã nguồn mở, đa nền tảng giúp thu thập thông tin về độ bao phủ mã.

### Câu lệnh cơ bản

Bạn có thể chạy test coverage cho một dự án test cụ thể (ví dụ: `CustomerService.UnitTests.csproj`) bằng câu lệnh sau:

```bash
dotnet test services/customer-service/tests/CustomerService.UnitTests/CustomerService.UnitTests.csproj /p:CollectCoverage=true /p:CoverletOutput=./TestResults/coverage.xml /p:CoverletOutputFormat=cobertura
```

### Giải thích các tham số

*   `/p:CollectCoverage=true`:
    *   **Ý nghĩa:** Đây là một thuộc tính (property) của MSBuild, được truyền cho `dotnet test`. Nó ra lệnh cho `coverlet` bắt đầu thu thập dữ liệu độ bao phủ mã khi các bài kiểm thử chạy. Nếu không có tham số này, `coverlet` sẽ không hoạt động.
    *   **Dành cho Junior:** Hãy nghĩ đơn giản là bạn đang bật công tắc "ghi lại xem code nào đã được chạy" khi chạy test.

*   `/p:CoverletOutput=./TestResults/coverage.xml`:
    *   **Ý nghĩa:** Thuộc tính này chỉ định đường dẫn và tên của tệp báo cáo độ bao phủ sẽ được tạo ra. Trong ví dụ này, báo cáo sẽ được lưu vào thư mục `TestResults` với tên `coverage.xml`.
    *   **Dành cho Junior:** Đây là nơi bạn muốn lưu lại kết quả "ghi chép" của mình. Bạn có thể đặt tên file và thư mục tùy ý.

*   `/p:CoverletOutputFormat=cobertura`:
    *   **Ý nghĩa:** Thuộc tính này xác định định dạng của tệp báo cáo độ bao phủ. `cobertura` là một định dạng XML phổ biến, được nhiều công cụ khác (như `reportgenerator` hoặc các plugin IDE) hỗ trợ để tạo báo cáo trực quan. Các định dạng khác có thể là `json`, `opencover`, `lcov`...
    *   **Dành cho Junior:** Có nhiều cách để "ghi chép" kết quả. `cobertura` là một kiểu "ghi chép" mà nhiều công cụ khác có thể đọc và biến thành báo cáo đẹp mắt.

### Hướng dẫn mở file coverage để xem nhanh

Tệp `coverage.xml` (hoặc bất kỳ định dạng nào bạn chọn) là một tệp XML chứa dữ liệu thô về độ bao phủ. Để xem nó một cách trực quan hơn:

*   **Mở trực tiếp (XML):** Bạn có thể mở tệp `coverage.xml` bằng bất kỳ trình soạn thảo văn bản nào (như VS Code, Notepad++). Tuy nhiên, nó sẽ khó đọc vì là dữ liệu thô.
*   **Sử dụng Plugin trong IDE:**
    *   **Visual Studio:** Cài đặt các extension như "Fine Code Coverage" hoặc "Code Coverage for VS Code" (nếu bạn dùng VS Code). Các plugin này có thể đọc tệp `coverage.xml` và hiển thị độ bao phủ trực tiếp trong trình soạn thảo code của bạn (ví dụ: tô màu xanh cho code đã chạy, màu đỏ cho code chưa chạy).
    *   **JetBrains Rider:** Rider có tính năng code coverage tích hợp sẵn, bạn có thể cấu hình để nó sử dụng `coverlet` và hiển thị kết quả.

## 2. Cách sinh Report đẹp (HTML Report)

Để có một báo cáo độ bao phủ đẹp mắt, dễ đọc và chia sẻ, chúng ta sẽ sử dụng `reportgenerator`.

### Cài đặt `reportgenerator` (Global Tool)

Nếu bạn chưa có, hãy cài đặt `reportgenerator` như một công cụ toàn cục trên máy của mình:

```bash
dotnet tool install --global reportgenerator
```
*   **Dành cho Junior:** Đây là một công cụ "phù thủy" giúp biến những "ghi chép" thô (file XML) thành một cuốn báo cáo đẹp đẽ, có hình ảnh, biểu đồ, rất dễ nhìn.

### Sinh Report HTML từ file `coverage.xml`

Sau khi đã chạy `dotnet test` với `coverlet` và có tệp `coverage.xml`, bạn có thể sinh báo cáo HTML:

```bash
reportgenerator -reports:./TestResults/coverage.xml -targetdir:./CoverageReport -reporttypes:Html
```
*   `-reports:./TestResults/coverage.xml`: Chỉ định tệp báo cáo độ bao phủ đầu vào (tệp XML mà `coverlet` đã tạo).
*   `-targetdir:./CoverageReport`: Chỉ định thư mục mà báo cáo HTML sẽ được tạo ra.
*   `-reporttypes:Html`: Chỉ định định dạng báo cáo đầu ra là HTML.

### Vị trí mở file HTML để xem coverage trực quan

Sau khi chạy lệnh trên, bạn sẽ tìm thấy báo cáo HTML trong thư mục `CoverageReport` (hoặc tên thư mục bạn đã chỉ định).

*   Mở tệp `index.html` trong thư mục `CoverageReport` bằng trình duyệt web của bạn. Bạn sẽ thấy một dashboard tổng quan về độ bao phủ, và có thể click vào từng file code để xem chi tiết từng dòng code đã được test hay chưa.

## 3. Cách tích hợp vào GitHub Actions

Để tự động hóa việc chạy test coverage và tạo báo cáo trong quy trình CI/CD, chúng ta sẽ tích hợp các bước này vào GitHub Actions.

### Thêm step `dotnet test` với `coverlet`

Bạn sẽ thêm một bước vào file `.github/workflows/ci-cd.yml` (hoặc file workflow tương ứng của bạn) để chạy test và thu thập coverage.

```yaml
# ... (các bước trước đó như checkout, setup .NET) ...

- name: Run Tests and Collect Coverage
  run: dotnet test services/customer-service/CustomerService.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=${{ github.workspace }}/coverage.xml
  # Lưu ý: Thay thế services/customer-service/CustomerService.sln bằng đường dẫn solution hoặc project test của bạn
  # ${{ github.workspace }} là biến môi trường trỏ đến thư mục gốc của repo trên runner
```
*   **Dành cho Junior:** Bước này giống như việc bạn chạy test trên máy mình, nhưng giờ là GitHub làm hộ. Kết quả "ghi chép" sẽ được lưu vào file `coverage.xml` ở thư mục gốc của dự án trên GitHub.

### Thêm step `reportgenerator` để tạo HTML report artifact

Sau khi có file `coverage.xml`, chúng ta sẽ dùng `reportgenerator` để tạo báo cáo HTML.

```yaml
# ... (sau bước Run Tests and Collect Coverage) ...

- name: Generate Coverage Report
  uses: danielpalme/reportgenerator-github-action@v5.2.0 # Hoặc chạy lệnh dotnet tool run reportgenerator
  with:
    reports: '${{ github.workspace }}/coverage.xml'
    targetdirectory: '${{ github.workspace }}/CoverageReport'
    reporttypes: 'Html'
```
*   **Dành cho Junior:** Bước này là để GitHub tạo ra cuốn báo cáo đẹp đẽ từ file `coverage.xml` mà nó vừa tạo ra. Báo cáo này sẽ nằm trong thư mục `CoverageReport`.

### Upload Report Artifact vào GitHub Actions

Để team có thể tải về và xem báo cáo HTML, chúng ta sẽ upload thư mục `CoverageReport` như một artifact của workflow.

```yaml
# ... (sau bước Generate Coverage Report) ...

- name: Upload Coverage Report
  uses: actions/upload-artifact@v3
  with:
    name: Code-Coverage-Report
    path: ${{ github.workspace }}/CoverageReport
```
*   **Dành cho Junior:** Bước này giống như việc bạn đóng gói cuốn báo cáo đẹp đẽ đó vào một cái hộp và gửi lên GitHub. Sau khi CI chạy xong, bạn có thể vào phần "Actions" trên GitHub, tìm đến lần chạy CI đó, và tải cái hộp này về để xem báo cáo.
