<?php
global $db;

function checkLoggedIn($u, $p) {
	global $connection;
	
	// Perform query
	$result = $connection -> query("SELECT id, name, password, isAdmin FROM user WHERE name = '".$u."' AND password = '".$p."'");
	
	return $result->fetch_all(MYSQLI_ASSOC)[0];
}

function checkAdmIn($username, $password) {
	global $connection;
	
	// Perform query
	$result = $connection -> query("SELECT id, name, password, isAdmin FROM user WHERE name = '$username' AND password = '$password' AND isAdmin=1");
	
	return $result->fetch_all(MYSQLI_ASSOC);
}
?>