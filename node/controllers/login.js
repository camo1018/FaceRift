module.exports = function(app, modules) {
    var section = '/login/'

	
    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });
	
	
    // Api Controller
	
	app.get('/actions' + section + 'login', function(req, res) {
		var response = req.query.response;
        var token = response.authResponse.accessToken;

        modules.fb.setAccessToken(token);
		var body = 'Hey g uys I think Im really dumb';
		modules.fb.api('me/feed', 'post', { message: body}, function (res) {
			if(!res || res.error) {
				console.log(!res ? 'error occurred' : res.error);
				return;
			}
			console.log('Post Id: ' + res.id);
		});
	});
}