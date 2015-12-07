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
  } else if (mssg == '/theme') {
    chatLog('default');
    chatLog('fake');
    chatLog('you can also set theme with the custom bar');
  } else if (mssg.split(' ')[0] == '/theme') {
    checkNewTheme(mssg.split(' ')[1]);
  } else {
    socket.emit('chat message', mssg, username, chatRoom);
  }
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

function changeClientTheme(newTheme) {
  var i, link_tag ;
  for (i = 0, link_tag = document.getElementsByTagName("link") ;
    i < link_tag.length ; i++ ) {
    if ((link_tag[i].rel.indexOf( "stylesheet" ) != -1) &&
      link_tag[i].title) {
      link_tag[i].disabled = true ;
      if (link_tag[i].title == css_title) {
        link_tag[i].disabled = false ;
      }
    }
  }
}

function checkNewTheme(theme) {
  var themeList = ['default', 'test invisible'];
  for (var i = 0; i < themeList.length; i++) {
    if (theme == themeList[i]) {
      i = themeList.length + 1;
      if (theme == 'test invisible') {
        alert('fake theme successful');
      } else {
        changeClientTheme(theme);
      }
    } else {
      alert('that is not a valid theme');
    }
  }
}

$('#defaultColor').click(function() {
  checkNewTheme('default');
});
