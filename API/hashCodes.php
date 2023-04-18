<?php

include('./common.php');
include("./db.php");

$request = $_SERVER['REQUEST_METHOD'];


switch ($request) {
    case 'GET': 

		break;

        default:
        header('HTTP/1.1 405 Method Not Allowed');
        break;
}

function getFileHashCode($fileHashCode) {
	global $connection;
	
	$result = count($connection -> query("SELECT * FROM antivirushashcodes WHERE hashCode = '$fileHashCode' ") -> fetch_all());
	return $result > 0;
}