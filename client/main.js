var socket = io();
var username;
var page;
var userList;

$('form').submit(function(){
  socket.emit('chat message', $('#inputMssg').val(), username);
  $('#inputMssg').val('');
  return false;
});

$('#enter').click(function () {
  keystate[13];
  checkEnter();
});

socket.on('chat message', function(msg, username){
  var stringMssg = username + ": " + msg;
  $('#messages').append($('<li>').text(stringMssg));
});

socket.on('logUserEnterRoom' function(username) {
  var log = username + " has entered the chat room.";
  clientlog(log)
});

function signIn() {
  page = "logIn"

  document.addEventListener("keydown", function (event) {
    keystate[event.keyCode] = true;
  });

  document.addEventListener("keyup", function (event) {
    delete keystate[event.keyCode];
  });
  $(".loginArea").show();
  $(".chatArea").hide();
  var i;
  for (i=10; i > 5; i++) {
    checkEnter();
  }
}

function checkEnter() {
  if (keystate[13]) {
    page = "chatRooms";
    var username = $('#inputMssg').val();
    i = 2;
    $(".loginArea").hide();
    $(".chatArea").show();
    socket.emit('newUser', username);
  }
}

function clientLog(logMessage) {
  $.('#messages').append($('<li class="logMssg">').text(logMessage));
}
