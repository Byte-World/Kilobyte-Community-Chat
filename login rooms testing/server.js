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

  (function resendeCommand() {
    prompt.get(['severCommand']), function(err, res) {
      if (res.command == 'kick') {
        prompt.get(['message'], function (err, res) {
          result.username.disconnect();
        });
      }

      if (res.command == 'ban') {
        prompt.get(['message'], function (err, res) {
          result.username.disconnect();
          bannedPeople.unshift(result.username);
        });
      }

      if (res.command == 'changeGlobalTheme') {
        prompt.get(['message']), function (err, res) {
          socket.emit('change theme', res.theme)
        }
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
