# Các Test Case của Customer Service

Tài liệu này cung cấp tổng quan chi tiết về các test case hiện có cho dịch vụ `customer-service`. Các test case được phân loại dựa trên loại hình kiểm thử (Unit Test, Integration Test) và tập trung vào các khía cạnh chính của dịch vụ như quản lý khách hàng (CRUD), logic nghiệp vụ, và tương tác với cơ sở dữ liệu.

Mục tiêu của tài liệu này là giúp các nhà phát triển khác nhanh chóng nắm bắt được phạm vi kiểm thử hiện tại của `customer-service`, hiểu rõ các kịch bản đã được kiểm tra, và dễ dàng xác định nơi cần bổ sung test case khi phát triển tính năng mới hoặc sửa lỗi.

## 1. CustomerService.UnitTests/CustomerServiceTests.cs

*   `GetCustomerByIdAsync_ShouldReturnCustomer_WhenCustomerExists`
*   `CreateCustomerAsync_ShouldCreateCustomer_WhenCustomerIsValid`
*   `CreateCustomerAsync_ShouldThrowArgumentException_WhenPhoneExists`
*   `UpdateCustomerAsync_ShouldUpdateCustomer_WhenCustomerExists`
*   `DeleteCustomerAsync_ShouldDeleteCustomer_WhenCustomerExists`
*   `SearchCustomersAsync_ShouldReturnPagedResult_WithCorrectPagination`

## 2. CustomerService.IntegrationTests/Repositories/CustomerRepositoryTests.cs

*   `SearchCustomersAsync_Should_Return_Filtered_Customers`
*   `GetAllAsync_ShouldReturnAllCustomers`
*   `AddAsync_ShouldAddCustomer`
*   `Update_ShouldUpdateCustomer`
*   `Delete_ShouldRemoveCustomer`
*   `SearchCustomersAsync_ShouldReturnAllCustomers_WhenNoFilters`
*   `SearchCustomersAsync_ShouldFilterByKeyword_FullName`
*   `SearchCustomersAsync_ShouldFilterByKeyword_Phone`
*   `SearchCustomersAsync_ShouldFilterByKeyword_Email`
*   `SearchCustomersAsync_ShouldFilterByStatus`
*   `SearchCustomersAsync_ShouldHandleInvalidStatus`
*   `SearchCustomersAsync_ShouldReturnEmpty_WhenNoMatches`
*   `SearchCustomersAsync_ShouldReturnCorrectPage`
*   `GetByIdAsync_ShouldReturnNull_WhenCustomerNotFound`
*   `GetByPhoneAsync_ShouldReturnNull_WhenCustomerNotFound`
*   `GetByEmailAsync_ShouldReturnNull_WhenCustomerNotFound`
*   `GetByPhoneAsync_Should_Return_Customer`
*   `GetByEmailAsync_Should_Return_Customer`

## 3. CustomerService.IntegrationTests/CustomersControllerTests.cs

*   `GetCustomers_ReturnsSuccessStatusCodeAndCorrectContentType`
*   `GetCustomerById_ReturnsCustomer_WhenCustomerExists`
*   `GetCustomerById_ReturnsNotFound_WhenCustomerDoesNotExist`
*   `PostCustomer_ReturnsCreatedCustomer_WhenCustomerIsValid`
*   `PostCustomer_ReturnsBadRequest_WhenCustomerIsInvalid`
*   `PutCustomer_ReturnsNoContent_WhenCustomerIsValid`
*   `PutCustomer_ReturnsBadRequest_WhenIdMismatch`
*   `PutCustomer_ReturnsNotFound_WhenCustomerDoesNotExist`
*   `DeleteCustomer_ReturnsNoContent_WhenCustomerExists`
*   `DeleteCustomer_ReturnsNotFound_WhenCustomerDoesNotExist`
*   `GetCustomers_WithSearchAndPagination_ReturnsFilteredAndPagedResult`
