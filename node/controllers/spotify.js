module.exports = function(app, modules) {
    var section = '/spotify/'


    // Controller
    app.get(section + 'login', function(req, res) {
        res.render('login/login.html');
    });


    // Api Controller
    app.get('/actions' + section + 'playMusic', function(req, res) {

    });

}