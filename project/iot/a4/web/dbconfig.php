<?php
	$host = "localhost";
	$user = "root";
	$password = "";
	$database = "coreproject";
	$link = mysqli_connect($host,$user,$password);
	mysqli_select_db($link, $database);
?>
