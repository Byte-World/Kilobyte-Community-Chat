var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = 3000;
var users = [];
var rooms = [main room];

app.get('/', function(req, res){
  res.sendFile(__dirname + '/client/index.html');
});

io.on('connection', function(socket) {
  socket.on('chat message', function(msg, username, chatRoom) {
    io.emit('chat message', msg, username, sendChatRoom);
  });

  socket.on('check rooms', function (room) {
    for (i = 0; i < rooms.length; i++) {
      if (room == rooms.length[i]) {
        rooms.unshift(room);
        socket.emit('create room', room);
      } else {
        socket.emit('room connect success', room);
      }
    }
  });
});

http.listen(port, function(){
  var logMssg = "Server is running on port: " + port;
  console.log(logMssg);
  console.log("Enter a server command");
  commandReady = true;
});
