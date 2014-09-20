module.exports = function(app, modules) {
    var section = '/login/'

    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });

    // Api Controller
}