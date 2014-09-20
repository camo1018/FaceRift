var express = require('express');
var ejs = require('ejs');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

var modules = require('./modules');

var app = express();

app.use(cookieParser('HelloMother'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.set('views', __dirname+'/views');
app.set('view options', { pretty: true });
app.set('view engine', 'html');
app.engine('.html', ejs.renderFile);
app.use(express.static(__dirname+'/public'));

// Render Routes
app.get('/', function(req, res) {
    res.render('index.html');
});

// Controllers
require('./controllers/login.js')(app, modules);

console.log('Server started at port 8000');

app.listen(8000);