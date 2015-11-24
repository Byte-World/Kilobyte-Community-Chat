var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = 3000;
var users = [];
var adminCodes = ["abc123", "321cba"]

app.get('/', function(req, res){
  res.sendFile(__dirname + '/client/index.html');
});

io.on('connection', function(socket){
  socket.on('chat message', function(msg){
    io.emit('chat message', msg);
  });

  socket.on('newUser' function(username) {
    users.push(username);
    socket.emit('logUserEnterRoom', username);
  });

  socket.on('kick' function (username, kickUser) {
    socket.emit('checkAdmin');
  });

  socket.on('adminToServer' function (pword) {
    for (var i = 0; i < adminCodes.length; i++) {
      if (pword == adminCodes[i]) {
        i = adminCodes.length + 1;
        //kick(kickUser);
      }
    }
  });
});

});

http.listen(port, function(){
  var logMssg = "Server is running on port: " + port;
  console.log(logMssg);
});

/*Work in progress
function kick(user) {

}
*/
