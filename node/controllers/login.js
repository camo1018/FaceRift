module.exports = function(app, modules) {
    var section = '/login/'

	
    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });

    app.get(section + 'launch', function(req, res) {
        res.render('login/launch.html');
    });
	
	
    // Api Controller
	app.get('/actions' + section + 'login', function(req, res) {
		var response = req.query.response;
        var token = response.authResponse.accessToken;
        req.session.accessToken = token;
        res.send('ready');
	});
}