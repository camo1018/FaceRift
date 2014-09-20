var express = require('express');
var ejs = require('ejs');

var modules = require('./modules');

var app = express();

app.use(express.cookieParser());
app.use(express.session({ secret: 'QaBiOP21ABTSX' }));
app.use(express.urlencoded());
app.use(express.json());

app.configure(function() {
    app.set('views', __dirname+'/views');
    app.set('view options', { pretty: true });
    app.set('view engine', 'html');
    app.engine('.html', ejs.renderFile);
    app.use(express.static(__dirname+'/public'));
});

// Render Routes
app.get('/', function(req, res) {
    res.render('index.html');
});

// Controllers
require('./controllers/login.js')(app, modules);