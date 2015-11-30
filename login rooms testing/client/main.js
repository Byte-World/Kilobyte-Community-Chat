var socket = io();
var page = 'login';
var username;
var usernameSet = false;
var bannedNames = ['abc123', 'bye'];
$('.login-page').show();
$('.chat-page').hide();

$('form').submit(function () {
  var mssg = $('#inputMssg').val;
  socket.emit('chat message', mssg, username);
  $('#inputMssg').val('');
  return false;
});

socket.on('chat message', function(msg, username){
  var stringMssg = username + ": " + msg;
  $('#messages').append($('<li>').text(stringMssg));
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
