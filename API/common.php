<?php

include("./db.php");


function authenticateUser($userName, $password) {
	global $connection;
	
	$result = count($connection -> query("SELECT * FROM users WHERE userName = '$userName' AND password = MD5('$password');") -> fetch_all());
	return $result > 0;
}