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
});

http.listen(port, function(){
  var logMssg = "Server is running on port: " + port;
  console.log(logMssg);
});
