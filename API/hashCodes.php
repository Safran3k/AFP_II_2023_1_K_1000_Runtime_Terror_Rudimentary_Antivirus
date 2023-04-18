<?php

include('./common.php');
include("./db.php");

$request = $_SERVER['REQUEST_METHOD'];


switch ($request) {
    case 'GET': 
      if (getFileHashCode($_GET["fileHashCode"])) {
        echo json_encode(array(
            'error' => 0,
            'message' => 'The hash code is in the table.'
          )
        );
      }
      else {
        echo json_encode(array(
            'error' => 1,
            'message' => 'The hash code is not in the table.'
          )
        );
      }
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

function flagFileHashCodeAndStore($hashCode) {
  global $connection;
  $count = count($connection -> query("SELECT * FROM antivirushashcodes WHERE hashCode = '$hashCode';") -> fetch_all(MYSQLI_ASSOC));
  
  if ($count == 0) {
    $result = $connection -> query("INSERT INTO antivirushashcodes (hashCode, dateAdded) VALUES ('$hashCode', 'date()');");
    echo json_encode(
      array(
        'error' => 0,
        'message' => 'Actual file flagged, and stored in database!'
      )
    );
  }
  else {
    echo json_encode(array(
        'error' => 1,
        'message' => 'Actual file hash code is already in database!'
      )
    );
  }
}