<?php

require_once("connection.php");
require_once("common.php");
$db = new dbObj();
$connection = $db->getConnection();

// HTTP METHODS HASZNÁLATA

$request = $_SERVER['REQUEST_METHOD'];

switch ($request) {
	case "GET":
		if (!empty($_GET["username"])) {
			$users = login($_GET["username"], $_GET["password"]);
		}
		else {
			$users = getUsers();
		}
		echo json_encode($users);
		break;
	case "POST":
		$content = file_get_contents('php://input');
		$data = json_decode($content, true);
		$user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin){
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
		insert_user($data["username"],$data["password"]);
		break;
	case "PUT":
		$content = file_get_contents('php://input');
		$data = json_decode($content, true);
		$user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin){
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
		update_user($data["id"], $data["username"], $data["password"], $data["isAdmin"]);
		break;
	case "DELETE":
		$content = file_get_contents('php://input');
		$data = json_decode($content, true);
		$user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin){
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
		delete_user($data["id"]);
		break;
	default:
		header('HTTP/1.1 405 Method Not Allowed');
		header('Allow: GET, POST, PUT, DELETE');
		break;
}

function login($u, $p) {
	global $connection;
	
	// Perform query
	$result = $connection -> query("SELECT id, name, password, isAdmin FROM user WHERE name = '$u' AND password = ('$p')");
	
	return $result->fetch_all(MYSQLI_ASSOC);
}

function getUsers(){
	global $connection;
	
	// Perform query
	$result = $connection -> query("SELECT id, name, password, isAdmin FROM user");
	
	return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_user($name, $pw) {
	global $connection;
	
	// Perform query
	$result = $connection -> query("INSERT INTO user (name, password, isAdmin) VALUES ('$name', '$pw', 0)");
}

function update_user($id, $username, $password, $isAdmin) {
	global $connection;

	// Perform query
	$connection -> query("UPDATE user SET name='$username', password='$password', isAdmin='$isAdmin' WHERE id ='$id'");
}

function delete_user($id) {
	global $connection;
	
	// Perform query
	$connection -> query("DELETE FROM user WHERE id = '$id'");
}
?>