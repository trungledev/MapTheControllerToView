Bộ ánh xạ Controller sang View
    +Sử dụng 2 namespace: System.Reflection và System.Diagnostics;
    +Gọi hàm của View tại Controller chỉ cần khởi tạo tên theo cấu trúc:
        -Tên controller : phải chứa từ khóa "Controller", tên view : từ khóa "View";
            Ví dụ: GameController và GameView
        -Tên hàm: phải giống nhau tại 2 lớp:
            Ví dụ: Start() tại GameController và Start() tại GameView
    +Lớp controller phải kế thừa lớp Controller. Ví dụng GameController : Controller { }
    +Các lớp phải được sử dụng trong cùng Assembly
    +Phải đồng bộ tham số truyền vào và tham số nhận
        -Ví dụ: tại Hàm Start( new object[]{"Hello World", 123, true}) trong Controller
            => Start(string message. int id, bool success) trong View