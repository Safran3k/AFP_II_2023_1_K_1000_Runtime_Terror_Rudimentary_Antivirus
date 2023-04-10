<?php

include('./common.php');
include("./db.php");

$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
    case 'GET': //select
        
		break;

        default:
        header('HTTP/1.1 405 Method Not Allowed');
        break;
}
