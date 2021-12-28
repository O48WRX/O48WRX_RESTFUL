var http = require("http");
var express = require('express');
var app = express();
var mysql = require('mysql2');
var bodyParser = require('body-parser');
const { connect } = require("http2");
const AdminToken = "6eeb08e18ea7ee9335ec2d46793ea1bd"; //AdminToken szó szerint

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
});

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));

var server = app.listen(3000, "127.0.0.1", function () {
  var host = server.address().address;
  var port = server.address().port;
  console.log("A következő portot figyeljük : https://%s:%s", host, port)
});

//USER METHODS
app.get('/user', function(req, res) {
  connection.query('SELECT * FROM user', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/user/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM user WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/adduser/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO user SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updateuser/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE user SET username = "'+req.body.username+'", password = "'+req.body.password+'", isAdmin = '+req.body.isAdmin+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/deluser/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM user WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

//VGA METHODS
app.get('/vga', function(req, res) {
  connection.query('SELECT * FROM vga', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/vga/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM vga WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addvga/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO vga SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updatevga/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE vga SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", vram = '+req.body.vram+', clock = '+req.body.clock+', price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delvga/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM vga WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});


//PROCESSOR METHODS
app.get('/processor', function(req, res) {
  connection.query('SELECT * FROM processor', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/processor/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM processor WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addprocessor/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO processor SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updateprocessor/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE processor SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", clock = '+req.body.clock+', price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delprocessor/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM processor WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

//POWER SUPPLY UNIT METHODS
app.get('/psu', function(req, res) {
  connection.query('SELECT * FROM psu', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/psu/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM psu WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addpsu/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO psu SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updatepsu/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE psu SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", performance = "'+req.body.performance+'", price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delpsu/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM psu WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

//RAM METHODS
app.get('/ram', function(req, res) {
  connection.query('SELECT * FROM ram', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/ram/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM ram WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addram/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO ram SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updateram/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE ram SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", clock = '+req.body.clock+', capacity = "'+req.body.capacity+'", price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delram/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM ram WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

//MOTHERBOARD METHODS
app.get('/mobo', function(req, res) {
  connection.query('SELECT * FROM mobo', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/mobo/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM mobo WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addmobo/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    var postData = req.body;
    connection.query('INSERT INTO mobo SET ?', postData, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updatemobo/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE mobo SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", ram_type = "'+req.body.ram_type+'", ram_sockets = '+req.body.ram_sockets+', price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delmobo/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM mobo WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

//CONNECTION TABLE METHODS
app.get('/ordered', function(req, res) {
  connection.query('SELECT * FROM ordered', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/ordered/:id', function(req, res) {
  console.log(req);
  connection.query('SELECT * FROM ordered WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.post('/addorder/:token', function(req, res) {
  if (req.params.token == AdminToken) {
  var postData = req.body;
  connection.query('INSERT INTO ordered SET ?', postData, function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.put('/updateorder/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('UPDATE ordered SET user_id = '+req.body.user_id+', processor_id = '+req.body.processor_id+', vga_id = '+req.body.vga_id+', psu_id = '+req.body.psu_id+', ram_id = '+req.body.ram_id+', mobo_id = '+req.body.mobo_id+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

app.delete('/delorder/:id/:token', function(req, res) {
  if (req.params.token == AdminToken) {
    connection.query('DELETE FROM ordered WHERE id ='+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});