var socket = io();
var username;

$('form').submit(function(){
  socket.emit('chat message', $('#m').val(), username);
  $('#inputMssg').val('');
  return false;
});

socket.on('chat message', function(msg, username){
  var stringMssg = username + ": " + msg;
  $('#messages').append($('<li>').text(stringMssg));
});
