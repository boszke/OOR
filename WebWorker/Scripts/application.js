	var worker = new Worker('Script/worker.js');
	
	worker.onmessage = function(event)
	{
		$("#wyswietl").html(event.data);
	});
	
	$().ready(function()
	{
		$("#startbtn").click(function (event)
		{
			worker.postMessage("start");
		});
	});