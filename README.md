## 1. Factory đang che giấu quyết định thiết kế nào?
- Che giấu việc khởi tạo lớp cụ thể: `SmartLight`, `SmartFan`, hay `SmartDoor`.
- Client chỉ phụ thuộc vào abstraction chung (`IDevice`) mà không cần biết logic tạo hay cấu trúc constructor chi tiết của từng lớp con.

## 2. Singleton bảo đảm điều gì, nhưng tạo ra rủi ro nào?
- **Bảo đảm:** Trong toàn bộ ứng dụng chỉ có duy nhất một thể hiện của `HomeConfiguration` được tạo ra và cung cấp một điểm truy cập toàn cục.
- **Rủi ro:** Tạo ra trạng thái toàn cục, làm tăng tính phụ thuộc chặt chẽ và gây khó khăn khi viết Unit Test.

## 3. Facade khác Factory ở mục đích chính như thế nào?
- **Factory:** Mục đích chính là **tạo đối tượng** mà không để lộ logic khởi tạo cho client.
- **Facade:** Mục đích chính là **cung cấp giao diện mức cao** để tương tác với một tập hợp các subsystem phức tạp đã tồn tại.

## 4. Nếu bỏ SmartHomeFacade, client sẽ phải biết thêm những chi tiết nào?
- Phải trực tiếp quản lý tất cả các tham chiếu tới từng thiết bị riêng lẻ: `light`, `fan`, `door`.
- Phải tự gọi đúng thứ tự các phương thức của từng hệ thống con khi thực hiện kịch bản (ví dụ: `light.TurnOff()`, `fan.TurnOff()`, `door.Lock()`).
- Phải biết thêm về `HomeConfiguration` để lấy giá trị `NightLightLevel` khi kích hoạt chế độ ngủ.


## Thông tin chi tiết các Pattern

### Factory
- **Vị trí sử dụng:** `DeviceFactory.Create` trong `Program.cs` (tạo các đối tượng `light`, `fan`, `door`).
- **Lợi ích:** Tách việc khởi tạo đối tượng ra khỏi client, cho phép thay đổi lớp con mà không sửa mã client, hỗ trợ mở rộng loại thiết bị mới.
- **Hạn chế:** Khi thêm loại thiết bị mới, cần sửa trực tiếp `DeviceFactory`.

### Singleton
- **Vị trí sử dụng:** `HomeConfiguration.Instance` được gọi ở `Program.cs` và trong `SmartHomeFacade` để lấy cấu hình.
- **Lợi ích:** Đảm bảo duy nhất một cấu hình toàn cục, dễ dàng truy cập.
- **Hạn chế:** Tạo trạng thái toàn cục dẫn tới phụ thuộc chặt chẽ, khó mock trong unit test và khó xử lý khi sử dụng đồng thời.

### Facade
- **Vị trí sử dụng:** `SmartHomeFacade` được khởi tạo trong `Program.cs`; các phương thức `GoToWork` và `GoToSleep` được gọi để thực hiện các kịch bản.
- **Lợi ích:** Cung cấp giao diện đơn giản, gói gọn các thao tác phức tạp của nhiều subsystem, giảm số lần client phải gọi các phương thức con.
- **Hạn chế:** Ẩn chi tiết thực thi, nếu client cần hành vi tùy biến chi tiết hơn sẽ phải phá vỡ Facade hoặc kéo logic ra ngoài.