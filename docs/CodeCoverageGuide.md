# Hướng dẫn chạy Test Coverage trong .NET Core Project

Chào bạn, với vai trò là một kỹ sư DevOps, tôi sẽ hướng dẫn bạn cách chạy và tích hợp test coverage cho dự án .NET Core của chúng ta một cách chi tiết, dễ hiểu.

## 1. Cách chạy Test Coverage cục bộ (Cách đơn giản)

Cách tiếp cận này sử dụng `coverlet.msbuild`, cho phép bạn xem ngay kết quả tóm tắt % coverage trên console sau khi chạy test.

### Bước 1: Cài đặt Package

Đảm bảo rằng bạn đã thêm package `coverlet.msbuild` vào **tất cả các project test** của bạn.

```bash
dotnet add <path-to-test-project.csproj> package coverlet.msbuild
```

### Bước 2: Chạy Test và Xem Coverage

Chạy lệnh sau từ thư mục `services/customer-service`:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=teamcity
```

Sau khi test chạy xong, bạn sẽ thấy một bảng tóm tắt % coverage trực tiếp trên console.

### Giải thích các tham số

*   `/p:CollectCoverage=true`:
    *   **Ý nghĩa:** Thuộc tính MSBuild này sẽ kích hoạt `coverlet` để thu thập dữ liệu coverage.
    *   **Dành cho Junior:** Bật công tắc "ghi lại xem code nào đã được chạy".

*   `/p:CoverletOutputFormat=teamcity`:
    *   **Ý nghĩa:** Định dạng output để hiển thị một bảng tóm tắt rõ ràng trên console. Nếu bỏ qua, nó sẽ dùng định dạng `json` (khó đọc hơn).
    *   **Dành cho Junior:** Chọn kiểu "báo cáo nhanh" để xem ngay trên màn hình.

## 2. Cách sinh Report HTML chi tiết (Tùy chọn)

Nếu bạn muốn có một báo cáo HTML chi tiết để xem dòng code nào đã được cover, bạn có thể kết hợp `coverlet` và `reportgenerator`.

### Bước 1: Chạy Test và Xuất ra file Cobertura

Sử dụng lệnh sau để vừa hiển thị tóm tắt trên console, vừa tạo ra file `coverage.cobertura.xml` cần thiết cho `reportgenerator`.

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=\"teamcity,cobertura\"
```
*   **Lưu ý:** Lệnh này sẽ tạo ra một tệp `coverage.cobertura.xml` trong thư mục của mỗi project test.

### Bước 2: Cài đặt `reportgenerator`

Nếu bạn chưa có, hãy cài đặt `reportgenerator` như một công cụ toàn cục:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```

### Bước 3: Sinh Report HTML

Chạy lệnh sau từ thư mục gốc của repo (`gym-flow`):

```bash
reportgenerator "-reports:services/customer-service/tests/**/coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:Html
```

Sau đó, mở tệp `index.html` trong thư mục `coverage-report` để xem báo cáo chi tiết.

## 3. Tích hợp vào GitHub Actions

Quy trình CI/CD của chúng ta đã được cập nhật để sử dụng phương pháp `coverlet.msbuild`.

Trong tệp `.github/workflows/ci-cd.yml`, bước `test-dotnet` sẽ chạy lệnh sau cho `customer-service`:

```yaml
- name: Test
  run: |
    if [ "${{ matrix.service }}" == "customer-service" ]; then
      dotnet test services/customer-service/CustomerService.sln --no-build /p:CollectCoverage=true /p:CoverletOutputFormat=\"teamcity,cobertura\"
    else
      dotnet test services/${{ matrix.service }}/${{ matrix.service }}.csproj --no-restore
    fi
```

Điều này đảm bảo rằng mỗi khi code được push, chúng ta sẽ thấy được tóm tắt coverage trong logs của GitHub Actions, đồng thời file `coverage.cobertura.xml` cũng được tạo ra để có thể sử dụng cho các bước sau này (nếu cần).