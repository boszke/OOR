onmessage = function(event)
	{
		if(event.data === "start")
		{
			for(var x = 1; x <= 10000000; x++)
				postMessage(x);
		}
	};