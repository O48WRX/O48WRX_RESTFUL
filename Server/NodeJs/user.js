var http = require("http");
const https = require('https');
var express = require('express');
var app = express();
var mysql = require('mysql2');
var bodyParser = require('body-parser');
const { connect } = require("http2");
const AdminToken = "6eeb08e18ea7ee9335ec2d46793ea1bd"; //AdminToken szó szerint
const swaggerUI = require("swagger-ui-express");
//const swaggerDocument = require('./swagger.json');
const swaggerJsDoc = require("swagger-jsdoc");
const options = {
  hostname: '127.0.0.1',
  port: 443,
  path: '/SOP/PHP/ordered.php',
  method: 'GET',
  rejectUnauthorized: false,
  requestCert: true,
  agent: false
}
//process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';

//***************************************************
//A swagger elérhető a 'localhost:3000/api-docs/'-on*
//***************************************************

const swaggerOptions ={
    definition:{
      openapi:'3.0.0',
      info:{
        title:'Számítástechnikai Bolt API',
        version:'1.0.0',
        description:'Bolt API, bolt menedzseléséért',
        contact:{
          name:'Kardos Zsolt (NK = O48WRX)',
          email:'kardyy81@gmail.com'
        },
        servers:['http://localhost:3000']
      }
    },
    apis:["user.js"]
}

const swaggerDocs = swaggerJsDoc(swaggerOptions);
app.use('/api-docs', swaggerUI.serve,swaggerUI.setup(swaggerDocs));

app.use(function (req, res, next) {
  res.header("Content-Type",'application/json');
  next();
});

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
  console.log('mySQL connection successful...')
  console.log(' ');
});

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));

var server = app.listen(3000, "127.0.0.1", function () {
  var host = server.address().address;
  var port = server.address().port;
  console.log("========================================================================================================================")
  console.log(' ');
  console.log("Server is listening at : https://%s:%s", host, port)
});


/**
 * @swagger
 * tags:
 * - name: "user"
 *   description: "Everything about your Users!"
 * - name: "vga"
 *   description: "Everything about your Videocards!"
 * - name: "processor"
 *   description: "Everything about your Processors!"
 * - name: "psu"
 *   description: "Everything about your Power Supply Units!"
 * - name: "ram"
 *   description: "Everything about your RAM sticks!"
 * - name: "mobo"
 *   description: "Everything about your Motherboards!"
 * - name: "ordered"
 *   description: "Everything about your orders!"
 */

/**
 * @swagger
 * definitions:
 *  User:
 *   type: object
 *   properties:
 *    username:
 *     type: string
 *     description: username of the user
 *     example: 'Kzsolt112'
 *    password:
 *     type: string
 *     description: password of the user
 *     example: '123'
 *    isAdmin:
 *     type: integer
 *     description: Designates whether the user is and administrator or not
 *     example: '0'
 *  Vga:
 *   type: object
 *   properties:
 *    manufacturer:
 *     type: string
 *     description: Name of the manufacturer
 *     example: 'MSI'
 *    model:
 *     type: string
 *     description: Designation of the model.
 *     example: Geforce GTX 1080 Ti
 *    vram:
 *     type: integer
 *     description: Available VRAM for the card.
 *     example: 8192
 *    clock:
 *     type: string
 *     description: Memory clock for the card.
 *     example: '1900 MHz'
 *    price:
 *     type: integer
 *     description: Price of the card.
 *     example: 350000
 *  Processor:
 *   type: object
 *   properties:
 *    manufacturer:
 *     type: string
 *     description: Manufacturer of the processor
 *     example: Intel
 *    model:
 *     type: string
 *     description: Model designation of the processor.
 *     example: I7-10900K
 *    clock:
 *     type: string
 *     description: Clock of the processor
 *     example: 5-6.5GHz
 *    price:
 *     type: integer
 *     description: Price of the processor.
 *     example: 200000
 *  Psu:
 *   type: object
 *   properties:
 *    manufacturer:
 *     type: string
 *     description: Name of the manufacturer
 *     example: TestManu
 *    model:
 *     type: string
 *     description: Designation of the PSU model.
 *     example: TestModel
 *    performance:
 *     type: string
 *     description: Power output of the PSU
 *     example: 550W
 *    price:
 *     type: integer
 *     description: Price of the PSU
 *     example: 20000
 *  Ram:
 *   type: object
 *   properties:
 *    manufacturer:
 *     type: string
 *     description: Name of the manufacturer.
 *     example: TestMan1
 *    model:
 *     type: string
 *     description: Model designation.
 *     example: TestModel1
 *    clock:
 *     type: string
 *     description: Memory clock of the sticks.
 *     example: 3000MHz
 *    capacity:
 *     type: string
 *     description: Memory capacity of the sticks.
 *     example: 16Gb
 *    price:
 *     type: integer
 *     description: Price of the RAM stick(s).
 *     example: 30000
 *  Mobo:
 *   type: object
 *   properties:
 *    manufacturer:
 *     type: string
 *     description: Name of the manufacturer
 *     example: TestMan
 *    model:
 *     type: string
 *     description: Model designation of the motherboard
 *     example: TestModel
 *    ram_type:
 *     type: string
 *     description: The type of RAM that fits the board
 *     example: DDR4
 *    ram_sockets:
 *     type: integer
 *     description: The number of RAM sockets on the board
 *     example: 4
 *    price:
 *     type: integer
 *     description: price of the board
 *     example: 45000
 *  Ordered:
 *   type: object
 *   properties:
 *    user_id:
 *     type: integer
 *     description: The Id of the user who ordered.
 *     example: 2
 *    processor_id:
 *     type: integer
 *     description: The ID of the processor the user ordered.
 *     example: 2
 *    vga_id:
 *     type: integer
 *     description: The ID of the VGA the user ordered.
 *     example: 2
 *    psu_id:
 *     type: integer
 *     description: The ID of the PSU the user ordered.
 *     example: 2
 *    ram_id:
 *     type: integer
 *     description: The ID of the RAM the user ordered.
 *     example: 2
 *    mobo_id:
 *     type: integer
 *     description: The ID of the Motherboard the user ordered.
 *     example: 2
 */


//USER METHODS
app.get('/user', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM user', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /user:
 *  get:
 *   tags:
 *   - "user"
 *   summary: get all users
 *   description: Get all users from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/user/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM user WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /user/{id}:
 *  get:
 *   tags:
 *   - "user"
 *   summary: get user by id
 *   description: Get a user with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the user
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/adduser/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /adduser/{token}:
  *  post:
  *   tags:
  *   - "user"
  *   summary: create user
  *   description: Creates user in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/User'
  *   responses:
  *    200:
  *     description: user created succesfully
  *    500:
  *     description: failure in creating user
  */



app.put('/updateuser/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
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

/**
 * @swagger
 * /updateuser/{id}/{token}:
 *  put:
 *   tags:
 *   - "user"
 *   summary: update user
 *   description: Updates user with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the user
 *      example: 9
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/User'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/User'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/User'
 */

app.delete('/deluser/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /deluser/{id}/{token}:
 *  delete:
 *   tags:
 *   - "user"
 *   summary: delete user by id
 *   description: Deletes user with the use of the ID of the user
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the user
 *      example: 9
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */

//VGA METHODS
app.get('/vga', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM vga', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /vga:
 *  get:
 *   tags:
 *   - "vga"
 *   summary: get all graphics cards
 *   description: Get all graphics cards from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/vga/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM vga WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /vga/{id}:
 *  get:
 *   tags:
 *   - "vga"
 *   summary: get graphics card by id
 *   description: Get a graphics card with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the vga
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addvga/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addvga/{token}:
  *  post:
  *   tags:
  *   - "vga"
  *   summary: create vga
  *   description: Creates vga in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Vga'
  *   responses:
  *    200:
  *     description: vga created succesfully
  *    500:
  *     description: failure in creating vga
  */

app.put('/updatevga/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
  if (req.params.token == AdminToken) {
    connection.query('UPDATE vga SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", vram = '+req.body.vram+', clock = "'+req.body.clock+'", price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

/**
 * @swagger
 * /updatevga/{id}/{token}:
 *  put:
 *   tags:
 *   - "vga"
 *   summary: update vga
 *   description: Updates vga with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the vga
 *      example: 5
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Vga'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Vga'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Vga'
 */

app.delete('/delvga/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delvga/{id}/{token}:
 *  delete:
 *   tags:
 *   - "vga"
 *   summary: delete vga by id
 *   description: Deletes vga with the use of the ID of the vga
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the vga
 *      example: 9
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */


//PROCESSOR METHODS
app.get('/processor', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM processor', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /processor:
 *  get:
 *   tags:
 *   - "processor"
 *   summary: get all processors
 *   description: Get all processor records from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/processor/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM processor WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /processor/{id}:
 *  get:
 *   tags:
 *   - "processor"
 *   summary: get processor by id
 *   description: Get a processor with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the processor
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addprocessor/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addprocessor/{token}:
  *  post:
  *   tags:
  *   - "processor"
  *   summary: create processor
  *   description: Creates a processor in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Processor'
  *   responses:
  *    200:
  *     description: processor created succesfully
  *    500:
  *     description: failure in creating processor
  */

app.put('/updateprocessor/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
  if (req.params.token == AdminToken) {
    connection.query('UPDATE processor SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", clock = "'+req.body.clock+'", price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

/**
 * @swagger
 * /updateprocessor/{id}/{token}:
 *  put:
 *   tags:
 *   - "processor"
 *   summary: update processor
 *   description: Updates a processor with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the processor
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Processor'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Processor'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Processor'
 */

app.delete('/delprocessor/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delprocessor/{id}/{token}:
 *  delete:
 *   tags:
 *   - "processor"
 *   summary: delete processor by id
 *   description: Deletes processor with the use of the ID of the processor
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the vga
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */

//POWER SUPPLY UNIT METHODS
app.get('/psu', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM psu', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /psu:
 *  get:
 *   tags:
 *   - "psu"
 *   summary: get all psus
 *   description: Get all psu records from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/psu/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM psu WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /psu/{id}:
 *  get:
 *   tags:
 *   - "psu"
 *   summary: get psu by id
 *   description: Get a psu with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the psu
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addpsu/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addpsu/{token}:
  *  post:
  *   tags:
  *   - "psu"
  *   summary: create psu
  *   description: Creates a psu in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Psu'
  *   responses:
  *    200:
  *     description: psu created succesfully
  *    500:
  *     description: failure in creating psu
  */

app.put('/updatepsu/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
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

/**
 * @swagger
 * /updatepsu/{id}/{token}:
 *  put:
 *   tags:
 *   - "psu"
 *   summary: update psu
 *   description: Updates a psu with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the psu
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Psu'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Psu'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Psu'
 */

app.delete('/delpsu/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delpsu/{id}/{token}:
 *  delete:
 *   tags:
 *   - "psu"
 *   summary: delete psu by id
 *   description: Deletes psu with the use of the ID of the psu
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the vga
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */

//RAM METHODS
app.get('/ram', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM ram', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /ram:
 *  get:
 *   tags:
 *   - "ram"
 *   summary: get all ram
 *   description: Get all ram records from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/ram/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM ram WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /ram/{id}:
 *  get:
 *   tags:
 *   - "ram"
 *   summary: get ram by id
 *   description: Get a ram with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the ram
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addram/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addram/{token}:
  *  post:
  *   tags:
  *   - "ram"
  *   summary: create ram
  *   description: Creates a ram in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Ram'
  *   responses:
  *    200:
  *     description: ram created succesfully
  *    500:
  *     description: failure in creating ram
  */

app.put('/updateram/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
  if (req.params.token == AdminToken) {
    connection.query('UPDATE ram SET manufacturer = "'+req.body.manufacturer+'", model = "'+req.body.model+'", clock = "'+req.body.clock+'", capacity = "'+req.body.capacity+'", price = '+req.body.price+' WHERE id = '+req.params.id, function(error, results, fields) {
      if (error) throw error;
      res.json(results);
    });
  }
  else {
    return res.status(403).json({'"403"':'"Unauthorized API call"'});
  };
});

/**
 * @swagger
 * /updateram/{id}/{token}:
 *  put:
 *   tags:
 *   - "ram"
 *   summary: update ram
 *   description: Updates a ram with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the ram
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Ram'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Ram'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Ram'
 */

app.delete('/delram/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delram/{id}/{token}:
 *  delete:
 *   tags:
 *   - "ram"
 *   summary: delete ram by id
 *   description: Deletes ram with the use of the ID of the ram
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the ram
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */

//MOTHERBOARD METHODS
app.get('/mobo', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM mobo', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /mobo:
 *  get:
 *   tags:
 *   - "mobo"
 *   summary: get all mobo
 *   description: Get all mobo records from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/mobo/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM mobo WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /mobo/{id}:
 *  get:
 *   tags:
 *   - "mobo"
 *   summary: get mobo by id
 *   description: Get a mobo with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the mobo
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addmobo/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addmobo/{token}:
  *  post:
  *   tags:
  *   - "mobo"
  *   summary: create mobo
  *   description: Creates a mobo in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Mobo'
  *   responses:
  *    200:
  *     description: Mobo created succesfully
  *    500:
  *     description: failure in creating mobo
  */

app.put('/updatemobo/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
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

/**
 * @swagger
 * /updatemobo/{id}/{token}:
 *  put:
 *   tags:
 *   - "mobo"
 *   summary: update mobo
 *   description: Updates a mobo with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the mobo
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Mobo'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Mobo'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Mobo'
 */

app.delete('/delmobo/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delmobo/{id}/{token}:
 *  delete:
 *   tags:
 *   - "mobo"
 *   summary: delete mobo by id
 *   description: Deletes mobo with the use of the ID of the mobo
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the mobo
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */

//CONNECTION TABLE METHODS
app.get('/ordered', function(req, res) {
  console.log('Incoming GET request...');
  connection.query('SELECT * FROM ordered', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

app.get('/orderedPHP', function(req, res1) {
  let data = [];
  let orders;
  const req1 = https.request(options, res => {
    console.log('Incoming GET request...');
    console.log(`statusCode: ${res.statusCode}`)
  
    res.on('data', chunk => {
      data.push(chunk);
    });

    res.on('end', () => {
      console.log('Response ended: ');
      orders = JSON.parse(Buffer.concat(data).toString());
      res1.send(orders);
    });
  })
  
  req1.on('error', error => {
    console.error(error)
  })
  req1.end();
});

app.get('/orderedINFO', function(req, res) {
  console.log('Incoming GET INFO request...');
  connection.query('SELECT user.username, processor.model AS processor_model, vga.model AS vga_model, psu.model AS psu_model, ram.model AS ram_model, mobo.model AS mobo_model FROM ordered INNER JOIN user ON ordered.user_id = user.id INNER JOIN processor ON processor_id = processor.id INNER JOIN vga ON vga_id = vga.id INNER JOIN psu ON psu_id = psu.id INNER JOIN ram ON ram_id = ram.id INNER JOIN mobo ON mobo_id = mobo.id WHERE user_id = '+req.body.user_id+' AND processor_id = '+req.body.processor_id+' AND vga_id = '+req.body.vga_id+' AND psu_id = '+req.body.psu_id+' AND ram_id = '+req.body.ram_id+' AND mobo_id = '+req.body.mobo_id+'', function(error, results, fields) {
    if (error) throw error;
    res.json(results);
    console.log('Sent results...');
  });
});

/**
 * @swagger
 * /ordered:
 *  get:
 *   tags:
 *   - "ordered"
 *   summary: get all orders
 *   description: Get all order records from the Database
 *   responses:
 *    200:
 *     description: success
 *    500:
 *     description: error
 */

app.get('/ordered/:id', function(req, res) {
  console.log('Incoming GET request...');
  console.log(req);
  connection.query('SELECT * FROM ordered WHERE id=?',[req.params.id], function(error, results, fields) {
    if (error) throw error;
    res.json(results);
  });
});

/**
 * @swagger
 * /ordered/{id}:
 *  get:
 *   tags:
 *   - "ordered"
 *   summary: get order by id
 *   description: Get a order with the use of their ID
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the order
 *      example: 2
 *   responses:
 *    200:
 *     description: success
 */

app.post('/addorder/:token', function(req, res) {
  console.log('Incoming POST request...');
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

/**
  * @swagger
  * /addorder/{token}:
  *  post:
  *   tags:
  *   - "ordered"
  *   summary: create order
  *   description: Creates a order in the store's Database
  *   parameters:
  *    - in: path
  *      name: token
  *      schema:
  *       type: string
  *      required: true
  *      description: Admin token for CRUD functions.
  *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
  *   requestBody:
  *    content:
  *     application/json:
  *      schema:
  *       $ref: '#/definitions/Ordered'
  *   responses:
  *    200:
  *     description: order created succesfully
  *    500:
  *     description: failure in creating order
  */

app.put('/updateorder/:id/:token', function(req, res) {
  console.log('Incoming PUT request...');
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

/**
 * @swagger
 * /updateorder/{id}/{token}:
 *  put:
 *   tags:
 *   - "ordered"
 *   summary: update order
 *   description: Updates a order with the use of their ID
 *   consumes:
 *    - application/json
 *   produces:
 *    - application/json
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the order
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *    - in: body
 *      name: body
 *      required: true
 *      description: body object
 *      schema:
 *       $ref: '#/definitions/Ordered'
 *   requestBody:
 *    content:
 *     application/json:
 *      schema:
 *       $ref: '#/definitions/Ordered'
 *   responses:
 *    200:
 *     description: success
 *     content:
 *      application/json:
 *       schema:
 *        $ref: '#/definitions/Ordered'
 */

app.delete('/delorder/:id/:token', function(req, res) {
  console.log('Incoming DELETE request...');
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

/**
 * @swagger
 * /delorder/{id}/{token}:
 *  delete:
 *   tags:
 *   - "ordered"
 *   summary: delete order by id
 *   description: Deletes order with the use of the ID of the mobo
 *   parameters:
 *    - in: path
 *      name: id
 *      schema:
 *       type: integer
 *      required: true
 *      description: id of the order
 *      example: 6
 *    - in: path
 *      name: token
 *      schema:
 *       type: string
 *      required: true
 *      description: Admin token for CRUD functions.
 *      example: 6eeb08e18ea7ee9335ec2d46793ea1bd
 *   responses:
 *    200:
 *     description: success
 */