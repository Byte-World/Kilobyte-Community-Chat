var socket = io();
var page = 'login';
var username;
var chatRoom = 'main room';
var usernameSet = false;
var bannedNames = ['abc123', 'bye'];
$('.login-page').show();
$('.chat-page').hide();

$('form').submit(function () {
  var mssg = $('#inputMssg').val;
  if (mssg.split(' ')[0] == '/room') {
    socket.emit('check rooms', mssg.split(' ')[1]);
  }
  socket.emit('chat message', mssg, username, chatRoom);
  $('#inputMssg').val('');
  return false;
});

socket.on('chat message', function(msg, username, sendChatRoom) {
  if (sendChatRoom == chatRoom) {
    var stringMssg = username + ": " + msg;
    $('#messages').append($('<li>').text(stringMssg));
  }
});

socket.on('room connect success', function (room) {
  alert('You have successfully connected to the new chat room.');
  changeRoom(room);
});

socket.on('create room', function (room) {
  alert('There is currently no room under the name of ' + room + '. Another room has been created called ' + room + '.');
  changeRoom(room);
});

function togglePages() {
  if (page == 'login') {
    $('.login-page').show();
    $('.chat-page').hide();
    page = 'chat';
  } else if (page == 'chat') {
    $('chat-page').show();
    $('login-page').hide();
  }
}

function determineUname(setUname, method) {
  for (i = 0; i < bannedNames.length; i++) {
    if (setUname == bannedNames[i]) {
      alert('You may not enter the chat room because this name is banned.');
    } else if (method == 'manual') {
      togglePages();
    } else if (method == 'buttons') {
      alert('You are in dev mode.')
      togglePages();
    }
  }
}

function changeRoom(room) {
  $('#messages').empty();
  chatRoom = room;
}

$('.nav-side .nav-toggle').on('click', function(event) {
  event.preventDefault();
  $(this).parent().toggleClass('nav-open');
});
