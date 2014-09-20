module.exports = function(app, modules) {
    var section = '/login/'

	
    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });
	
	
    // Api Controller
	
	app.get('/actions' + section + 'login', function(req, res) {
		var response = req.query.response;
		modules.fb.setAccessToken(response.authResponse.accessToken);
		var body = 'My first post using facebook-node-sdk';
		modules.fb.api('me/feed', 'post', { message: body}, function (res) {
			if(!res || res.error) {
				console.log(!res ? 'error occurred' : res.error);
				return;
			}
			console.log('Post Id: ' + res.id);
		});
	});
}