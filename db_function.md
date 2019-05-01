### Insert
 SQL : insert into users (“name”,”city”) values(“terry”,”seoul”)
 Mongo DB : db.users.insert({_id:”terry”,city:”seoul”})

### Select
 SQL : select * from users where id=”terry”
 Mongo DB : db.users.find({_id:”terry”})

### Update
 SQL : update users set city=”busan” where _id=”terry”
 Mongo DB : db.users.update( {_id:”terry”}, {$set :{ city:”Busan” } } )

### Delete
 SQL : delete from users where _id=”terry”
 Mongo DB : db.users.remove({_id:”terry”})

# MYSQL
cmd에서 원격 접속하는 방법
mysql -h ika.today -P 4000 -u root -p

계정 만들기
CREATE USER 'rhea31'@'localhost' IDENTIFIED BY 'password';
GRANT ALL PRIVILEGES ON *.* TO 'rhea31'@'localhost' WITH GRANT OPTION;
CREATE USER 'rhea31'@'%' IDENTIFIED BY 'password';
GRANT ALL PRIVILEGES ON *.* TO 'rhea31'@'%' WITH GRANT OPTION;
FLUSH PRIVILEGES;

-> 안만들어주면 외부에서 root로 접근해야하는데, 1130 에러 때문에 고생한다.

테이블 만들기
create table user (
	id varchar(20) not null,
	password varchar(20) not null,
	nickname varchar(20) not null,
	block int(1) not null,
	point int(32) not null,
	primary key (id)
);

값 넣는 방법
INSERT INTO user VALUES("test3", "test", "test", 101230, 10000);

값 수정
UPDATE tablename SET filedA='456' WHERE test='123' LIMIT 10;

값 여러개 동시 수정
UPDATE tablename SET filedA='456', fieldB='ABC' WHERE test='123' LIMIT 10;

NULL 값 수정
update user set money = 0 where ifnull(money, "NULL") = "NULL";

테이블 이름 바꾸기
ALTER TABLE user RENAME user2;

테이블에 컬럼 추가
ALTER TABLE bbs ADD name varchar(10);

테이블에 컬럼 삭제
ALTER TABLE bbs DROP colname;

테이블에 컬럼 수정
ALTER TABLE tablename MODIFY colname INT NOT NULL AUTO_INCREMENT PRIMARY KEY;

테이블에 컬럼 이름 변경
ALTER TABLE tablename CHANGE colname newcolname INT NOT NULL AUTO_INCREMENT;

테이블에 primary key 속성 삭제
ALTER TABLE test DROP PRIMARY KEY;

테이블 내용 전체 삭제
TRUNCATE TABLE tablename;

테이블에 컬럼 기본값 설정
alter table user alter play_win set default '0';


[SERVER IP]
61.84.196.74
61.84.196.75


[Node.js 에서 Mysql]
var mysql      = require('mysql');
// 비밀번호는 별도의 파일로 분리해서 버전관리에 포함시키지 않아야 합니다. 
var connection = mysql.createConnection({
  host     : 'localhost',
  user     : 'root',
  password : '111111',
  database : 'opentutorials'
});

connection.connect();

connection.query('SELECT * FROM topic', function (error, results, fields) {
    if (error) {
        console.log(error);
    }
    console.log(results);
});

connection.end();

Version 관련에러가 뜰때 (node.js Client does not support authentication protocol requested by server; consider upgrading MySQL client . . .)
ALTER USER 'root'@'%' IDENTIFIED WITH mysql_native_password BY 'YourRootPassword';