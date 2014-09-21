/**
 * Created by Paul on 9/20/2014.
 */
function LaunchViewmodel() {
    var self = this;

    self.launch = function() {
        $.get('/actions/login/getAccessToken', null, function(accessToken) {
            console.log('hi');
            window.location = 'frift://' + accessToken;
        });
    };
};

var launchViewmodel = new LaunchViewmodel();
ko.applyBindings(launchViewmodel);