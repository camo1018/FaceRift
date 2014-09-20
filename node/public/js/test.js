/**
 * Created by Paul on 9/20/2014.
 */
$(function() {
    $.get('/actions/userInteraction/poke', {}, function()
    {
        console.log('success!');
    });
	$.get('/actions/userInteraction/spotifyAlbum', {}, function(response)
	{
		console.log("response   "  + response);
		window.open(response.replace(/"/g, ''));
	});
});