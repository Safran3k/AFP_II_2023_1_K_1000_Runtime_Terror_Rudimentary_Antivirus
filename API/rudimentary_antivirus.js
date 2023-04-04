var http = require("http");
var express = require("express");
var app = express();
var mysql = require("mysql");

app.use(
  session({
    secret: "secret",
    resave: true,
    saveUninitialized: true,
  })
);

var connection = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "",
  database: " rudimentary_antivirus_db",
});

connection.connect(function (err) {
  if (err) {
    throw err;
  } else {
    console.log("A csatlakozás sikerült...");
  }
});

var server = app.listen(81, "127.0.0.1", function () {
  var host = server.address().address;
  var port = server.address().port;

  console.log("Figyeljük a következő URI-t http://%s:%s", host, port);
});

app.get("/conn", (req, res) => {
  res.send("API sikeresen csatlakozott");
});

app.listen(3000, () => {
  console.log("API fut a következő porton: 3000");
});
