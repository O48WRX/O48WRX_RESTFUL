var http = require("http");
var express = require('express');
var app = express();
var mysql = require('mysql2');
var bodyParser = require('body-parser');

//MySQL
var connection = mysql.createConnection({
  host : 'localhost',
  user : 'root',
  port: '3305',
  password : '',
  database : 'sop'
});

connection.connect(function(err) {
  if (err) throw err;
  console.log('A csatlakozás sikerült...')
})

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));

var server = app.listen(3000, "127.0.0.1", function () {
  var host = server.address().address;
  var port = server.address().port;
  console.log("A következő portot figyeljük : https://%s:%s", host, port)
});

app.get('/user', function(req, res) {
  connection.query('SELECT * FROM user', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/vga', function(req, res) {
  connection.query('SELECT * FROM vga', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/processor', function(req, res) {
  connection.query('SELECT * FROM processor', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/psu', function(req, res) {
  connection.query('SELECT * FROM psu', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/ram', function(req, res) {
  connection.query('SELECT * FROM ram', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/mobo', function(req, res) {
  connection.query('SELECT * FROM mobo', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});

app.get('/ordered', function(req, res) {
  connection.query('SELECT * FROM ordered', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  })
});