﻿const connection = new signalR.HubConnectionBuilder()
    .withUrl("/jfexec")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    console.log("connected");
});

