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
                    console.log('blah' + result);
                    if (result.length == 0) {
                        console.log('You have no friends');
                        return;
                    }
                    console.log(result);
                    targetUserId = result.data[0].id;
                    callback();
                });
            },
            function(callback) {
                var body = 'I poked you!';

                modules.fb.api('me/feed', 'post', { message: body, place: 360864190749604, tags: targetUserId, access_token: accessToken }, function(result) {
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
}