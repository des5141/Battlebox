BattleBox Server
====================================================================================
 
## 1) Space  
### Space Number  
* 0 - unauthentication user
* 1 - loading
* 2 - menu
* 100 ~ alpha - ingame

### Send
 * 0, 1 - is can send packet only server, client is can only received

## 2) Buffer  
* `buffer.append(Encoding.UTF8.GetBytes(String) )` 로 `String` 을 적는다  
* `Encoding.UTF8.GetString(Buffer.extract<byte[]>())` 로 `String` 을 들고온다

## 3) Naming convention
 * 변수 이름은 무조건 대문자로 시작한다  
   > 그러나, UserData.cs 는 제외한다
 * 메서드 이름은 무조건 대문자로 시작한다

## 4) Async Task
* AsyncLock 을 이용하여 Task 를 Lock 할때, Task 본문 내에서 await Task.Delay(number); 를 사용하면 안된다 **절대로**shangus