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