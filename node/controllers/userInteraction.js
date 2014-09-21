/**
 * Created by Paul on 9/20/2014.
 */
module.exports = function(app, modules) {
    var section = '/userInteraction/';

    // Controller
    app.get('/actions' + section + 'poke', function(req, res) {
        var accessToken = req.session.accessToken;
        var targetUserId = null;
        modules.async.series([
            function(callback) {
                modules.fb.api('me/taggable_friends', 'get', { access_token: accessToken }, function(result) {
                    if (result == null || result.data == null) {
                        console.log('You have no friends');
                        return;
                    }
                    // TODO:  Get the user from the game.
                    targetUserId = result.data[0].id;
                    console.log('friend:' + targetUserId);
                    callback();
                });
            },
            function(callback) {
                var body = 'I poked you, @[' + targetUserId + ']!';

                modules.fb.api('me/friftapp:pokey', 'post', { message: body, access_token: accessToken, object: { type: 'object', title: 'Frift!' } }, function(result) {
                    if(!result || result.error) {
                        console.log(!result ? 'error occurred' : result.error);
                        callback();
                    }
                    res.send('success');
                    callback();
                });
            }
        ], function() {});
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