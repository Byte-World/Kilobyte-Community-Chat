var socket = io();
var username;
var page;
var userList = [];
var uRoster = $('#userList');

$('form').submit(function () {
  var mssg = $('#inputMssg').val;
  if (msgg == null) {
    clientLog("You may not send blank messages.");
  } else if (mssg.split(' ')[0] == "/kick") {
    var kickUser = mssg.split(' ')[1];
    socket.emit('kick', username, kickUser);
  } else {
    socket.emit('chat message', mssg, username);
  }
  $('#inputMssg').val('');
  return false;
});

$('#enter').click(function () {
  keystate[13];
  checkEnter();
});

socket.on('banned user enter', function (uName) {
  if (username == uName) {
    alert('You have been banned.');
  }
});

function updateUsers () {
  for (i = 0; i < userList.length; i++) {
    uRoster.append("<li>" + userList[i] + "</li>");
  }
}

socket.on('checkAdmin' function () {
  pword = prompt("Enter your admin password:");
  socket.emit('adminToServer', pword);
});

socket.on('chat message', function(msg, username){
  var stringMssg = username + ": " + msg;
  $('#messages').append($('<li>').text(stringMssg));
});

socket.on('logUserEnterRoom' function(username) {
  var log = username + " has entered the chat room.";
  clientlog(log);
  userList.unshift(username);
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
