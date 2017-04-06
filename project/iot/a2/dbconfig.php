<?php
	$host = "localhost";
	$user = "FA10";
	$serverPassword = "ki90RM";
	$databasePassword = "m44lN3hjDzGP4vZe";

	$password = $serverPassword; //Comment out if you need databasePassword instead.
	#$password = $databasePassword; //Comment out if you need serverPassword instead.

	$database = "coreproject";
	$link = mysqli_connect($host, $user, $password);
	mysqli_select_db($link, $database);
?>




