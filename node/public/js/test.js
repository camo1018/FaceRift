/**
 * Created by Paul on 9/20/2014.
 */
$(function() {
    $.get('/actions/userInteraction/poke', {}, function()
    {
        console.log('success!');
    });

});