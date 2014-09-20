module.exports = function(app, modules) {
    var section = '/login/'

	
    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });
	
	
    // Api Controller
	
	app.get('/actions/login/login', function(req, res) {
		var response = req.query.response;
		console.log(response);
	});
}