# battlebox
## 명명 규칙
### 변수
* Resharp 에게 모든 걸 맡긴다. 파란 줄 안뜨도록 하자.

## 시스템
### core
* space 와 signal type 를 구분할때, 10 이상부터는 space - 10 미만은 signal type
### signal type
* -1 is send to server
* -2 is send to client in client space
* -3 is send to server and client (client space)
* -4 is send to server and all client
* 0 is space 0