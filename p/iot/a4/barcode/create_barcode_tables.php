<?php
    include_once 'dbconfig.php';

	$sql_query = "DROP TABLE IF EXISTS `barcode_items`;";
	mysqli_query($link, $sql_query);

	$sql_query = "DROP TABLE IF EXISTS `barcode_scans`;";
	mysqli_query($link, $sql_query);

	// Barcode items (Barcode, Item name, Price)
	$sql_query = "CREATE TABLE IF NOT EXISTS `barcode_items` (
		  `code` varchar(50) NOT NULL,
		  `name` varchar(255) NOT NULL,
		  `price` decimal(10,0) NOT NULL
		);";
	mysqli_query($link, $sql_query);

	$sql_query = "ALTER TABLE `barcode_items`
		ADD PRIMARY KEY (`code`);";
	mysqli_query($link, $sql_query);

	// Barcode scans (Barcode, Datetime)
	$sql_query = "CREATE TABLE IF NOT EXISTS `barcode_scans` (
		  `datetime` datetime NOT NULL,
		  `code` varchar(50) NOT NULL,
		  `receipt` tinyint(1) NOT NULL DEFAULT '0'
		);";
	mysqli_query($link, $sql_query);

	$sql_query = "ALTER TABLE `barcode_scans`
		ADD PRIMARY KEY (`datetime`);";
	mysqli_query($link, $sql_query);
	
	echo "Barcode tables were created."
?>
