## 2019 . 04 . 28

* 레퍼지토리 생성
* 서버 프로젝트 생성
* 서버 제작 시작
  * Javascript 처럼 Signal Event 를 처리할 수 있도록 함
  * Connect, Close, Receive, Start 이벤트 제작
  * AsyncLock 구현
  * 기능 별로 폴더를 나눔
  * DLL 연결 ( CGD Buffer, SuperSocket )
  * MongoDB 연결
* 클라이언트 프로젝트 생성

## 2019 . 04 . 29

* 서버 기능 추가
  * 하트비트
  * `MoveSpace.cs` , `RemoveUser.cs` 와 같은 **Task** 제작
  * `UserList` , `TaskLockInUserList` 와 같은 값들 생성
* 서버 기능 수정
  * `ServerNewRequestReceived.cs` 수정
  * `Config.cs` 로 서버 값 셋팅하도록 함
* 클라이언트 기능 추가
  * 기본적인 **Networking** 통신
* 데이터베이스를 `mongodb`에서 `mysql`로 변경함

