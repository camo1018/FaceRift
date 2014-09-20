/**
 * Created by Paul on 9/20/2014.
 */
module.exports = function(app, modules) {
    // Controller
    app.get('/test', function(req, res) {
        res.render('test/test.html');
    });
}