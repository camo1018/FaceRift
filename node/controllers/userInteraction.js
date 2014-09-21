/**
 * Created by Paul on 9/20/2014.
 */
var fs = require('fs');
module.exports = function(app, modules) {
    var section = '/userInteraction/';

    // Controller
    app.get('/actions' + section + 'poke', function(req, res) {
        var accessToken = req.query.accessToken;
        var targetUserId = req.query.friendID;
		var body = 'I poked you, @[' + targetUserId + ']!';
		modules.fb.api('me/friftapp:pokey', 'post', { message: body, access_token: accessToken, object: { type: 'object', title: 'Frift!' } }, function(result) {
			if(!result || result.error) {
				console.log(!result ? 'error occurred' : result.error);
			}
			res.send('success');
		});
    });
	
    app.get('/actions' + section + 'getMe', function(req,res){
        var accessToken = req.query.accessToken;
        modules.fb.api('me', 'get', { access_token: accessToken }, function(result) {
                    if (result == null || result == null) {
                    }
                    console.log(result);
                    var arr = [result.id, result.first_name + " " + result.last_name];
                    // TODO:  Get the user from the game.
                    res.send(arr);
                });
    });
	
	app.get('/actions' + section + 'postPhoto', function(req,res){
		var accessToken = req.query.accessToken;
		var body = "Partying in #frift!"
        var createdSource = fs.createReadStream("unity/frift_Data/screen.png");
		modules.fb.api('me/photos', 'post',
		{
			source:			createdSource,
            fileUpload:     "true", 
			access_token: 	accessToken,
			message:		body
		},
		function(result){
			if(!result || result.error) {
				console.log(!result ? 'error occurred' : result.error);
                return;
            }
            res.send('success');
		});
	});

	app.get('/actions' + section + 'spotifyAlbum', function(req, res) {
		modules.requestPage("http://tinysong.com/a/Girl+Talk+Ask+About+Me?format=json&key=45dbb061f69c29a8ea36d499f1260d3d", function (error, response, body) {
		  if (!error && response.statusCode == 200) {
			console.log("going to" + body) // Print the google web page.
			res.send(body);
		  }
		});
	});
}