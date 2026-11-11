# 1. Factory đang che giấu quyết định thiết kế nào?
- Che giấu việc khởi tạo lớp cụ thể: `SmartLight`, `SmartFan`, hay `SmartDoor`.
- Client chỉ phụ thuộc vào abstraction chung (`IDevice`) mà không cần biết logic tạo hay cấu trúc constructor chi tiết của từng lớp con.

# 2. Singleton bảo đảm điều gì, nhưng tạo ra rủi ro nào?
- **Bảo đảm:** Trong toàn bộ ứng dụng chỉ có duy nhất một thể hiện của `HomeConfiguration` được tạo ra và cung cấp một điểm truy cập toàn cục.
- **Rủi ro:** Tạo ra trạng thái toàn cục, làm tăng tính phụ thuộc chặt chẽ và gây khó khăn khi viết Unit Test.

# 3. Facade khác Factory ở mục đích chính như thế nào?
- **Factory:** Mục đích chính là **tạo đối tượng** mà không để lộ logic khởi tạo cho client.
- **Facade:** Mục đích chính là **cung cấp giao diện mức cao** để tương tác với một tập hợp các subsystem phức tạp đã tồn tại.

# 4. Nếu bỏ SmartHomeFacade, client sẽ phải biết thêm những chi tiết nào?
- Phải trực tiếp quản lý tất cả các tham chiếu tới từng thiết bị riêng lẻ: `light`, `fan`, `door`.
- Phải tự gọi đúng thứ tự các phương thức của từng hệ thống con khi thực hiện kịch bản (ví dụ: `light.TurnOff()`, `fan.TurnOff()`, `door.Lock()`).
- Phải biết thêm về `HomeConfiguration` để lấy giá trị `NightLightLevel` khi kích hoạt chế độ ngủ.

