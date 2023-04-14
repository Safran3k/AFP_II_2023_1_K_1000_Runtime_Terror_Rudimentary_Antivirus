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

function registration($username, $password) {
    global $connection;
    $count = count($connection -> query("SELECT * FROM users WHERE userName = '$username';") -> fetch_all(MYSQLI_ASSOC));
    
	if ($count == 0) {
		$result = $connection -> query("INSERT INTO users (userName, password) VALUES ('$username', md5('$password'));");
		echo json_encode(
			array(
				'error' => 0,
				'message' => 'New user added!'
			)
		);
	}
	else {
		echo json_encode(array(
				'error' => 1,
				'message' => 'User already exists!'
			)
		);
	}
}


function userExist($u, $p) {
	global $connection;
	
	$result = count($connection -> query("SELECT * FROM users WHERE userName = '$u' AND password = MD5('$p');") -> fetch_all());
	return $result > 0;
}