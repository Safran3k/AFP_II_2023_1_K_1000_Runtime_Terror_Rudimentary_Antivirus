<?php

include("./db.php");
include("./common.php");

$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
    case 'POST':
        
        break;
    
    default:
        header('HTTP/1.1 405 Method Not Allowed');
        header('Allow: POST');
        break;
}


function userExist($u, $p) {
	global $connection;
	
	$result = count($connection -> query("SELECT * FROM users WHERE userName = '$u' AND password = MD5('$p');") -> fetch_all());
	return $result > 0;
}