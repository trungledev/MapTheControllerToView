# Bộ ánh xạ Controller sang View
    
### 1, Sử dụng 2 namespace: System.Reflection và System.Diagnostics
```cs 
using System.Reflection;
using System.Diagnostics;
```
### 2, Gọi hàm của View tại Controller chỉ cần khởi tạo tên theo cấu trúc:

   #### Tên controller : phải chứa từ khóa "Controller", tên view : "View";
   
   Ví dụ:
```cs Controller
public class GameController
{
    //Code here
}
```
```cs View
public class GameView
{
    //Code here
}
```

   Tên hàm: phải giống nhau tại 2 lớp:
```cs Start() Controller
public class GameController : Controller
{
    public void Start()
    {
    
    }
}
public class GameView
{
    public string Start()
    {
        //Code here
    }
}
```

            
### 3, Lớp controller phải kế thừa lớp Controller 
Ví dụ
```cs 
public class GameController : Controller 
{
    //Code here
}
```
### 4, Các lớp phải được sử dụng trong cùng Assembly
Ví dụ : Game.dll
### 5, Phải đồng bộ tham số truyền vào và tham số nhận 
   Ví dụ:
```cs class GameController
public class GameController : Controller
{
    public void Start()
    {
        View(new object[]{ "Hello World", 123, true });
    }
}
```
```cs class GameView
public class GameView
{
    public void Start(string message, int id, bool success)
    {
        //Code here
    }
}
