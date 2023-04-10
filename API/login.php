<?php

include("./db.php");
include("./common.php");

$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (authenticateUser($_GET["userName"], $_GET["password"])) {
			echo json_encode(array(
					'error' => 0,
					'message' => 'You have successfully logged in!'
				)
			);
		}
		else {
			echo json_encode(array(
					'error' => 1,
					'message' => 'Login failed!'
				)
			);
		}
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET');
		break;
}