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


function kick(user) {
  for (var i = 0; i < users.length; i++) {
    var cUser = users[i];
    if (cUser == user) {
      socket.emit('user is kicked');
      user.disconnect();
    }
  }
}

//Functions for future command purposes, WIP

window.onload=function() {
    setInterval(updateTheme, 1);
};

function addSystemMessage(message) {
    var messageElement = document.createElement('li');
    messageElement.className = 'message';

    var messageBody = document.createElement('span');
    messageBody.innerHTML = '[System] ' + message;
    messageBody.className = 'system';

    messageElement.appendChild(messageBody);
    addMessageElement(messageElement);
}

socket.on('user has left', function (data) {
      log(data.username + ' has exited the room.');
    addParticipantsMessage(data);
    removeChatTyping(data);
    removeUserFromRoster(data.username);
});

function newSwitchStyle(css_title) {
  all_link = document.getElementsByTagName("link");
  main_link = all_link[0];
  if (css_title == "default") {
    main_link.href = "default.css";
    //log("Default theme has been set as your theme.");
  } else if (css_title == "abstract") {
    main_link.href = "#";
  } else if (css_title == "#") {
    main_link.href = "#";
  } else {
    log("Sorry, that is not a valid theme. Remember, the themes are case-sensitive.")
  }
}
//Script for changing the theme.
/*function newStyleSwitch(css_href) {
  $(link).attr("href", css_href);
}*/
function switchStyle(css_title) {
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
