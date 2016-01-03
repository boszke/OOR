<html>
<head>
	<meta charset="UTF-8">
	<title>Web Workers</title>
	<!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
	<link href="css/custom.css" rel="stylesheet">
	<script src="scripts.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
	
</head>
<body>
<div class="container">
	<div class="row">
		<h1 class="text-center">Działanie WebWorkers</h1>
	</div>	
	<div class="row">
		<div class="col-sm-4">
			<button onclick="startWorker()">Licznik</button> 
			<p>Licznik: <output id="result"></output></p>
		</div>
		<div class="col-sm-4">
			<button onclick="stopWorker()">Stop Worker</button>
		</div>
		<div class="col-sm-4">
			<button onclick="fibonacci()">Fibonacci</button>
			<div class="row">
			<div class="col-sm-2">
				<p>index: <div id="index"></div></p>
			</div>
			<div class="col-sm-2">
				<p>wynik: <div id="wynik"></div></p>
			</div>
			</div>
		</div>
	</div>
</div>
</body>
</html>