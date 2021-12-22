<?php
require_once("connection.php");
require_once("common.php");

$db = new dbObj();
$connection = $db->getConnection();
$request_method = $_SERVER["REQUEST_METHOD"];

switch($request_method){
    case 'GET':         
        if(!empty($_GET["id"])){
            $id = intval($_GET["id"]);
            $data = get_ram_by_id($id);
            echo json_encode($data);
        }else
            $data = get_all_rams();
            echo json_encode($data);
    break;
    case 'POST':
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);
        $user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin){
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
        insert_ram($data["manufacturer"], $data["model"], $data["clock"], $data["capacity"], $data["price"]);
    break;
    
    case 'PUT': 
        $content = file_get_contents('php://input');
        $data = json_decode($content, true);
        $user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin){
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
        update_vga($data["id"], $data["manufacturer"], $data["model"], $data["clock"], $data["capacity"], $data["price"]);
    break;
    
    case 'DELETE': 
        $content = file_get_contents('php://input');
        $data = json_decode($content, true); // asszociatív tömb
        $user = checkLoggedIn($data["username"], $data["password"]);
        $admin = checkAdmIn($data["username"], $data["password"]);
        if(!$user or !$admin) {
            header('HTTP/1.0 401 Unauthorized ');
            break;
        }
        delete_vga($data["id"]);
    break;
    
    default:
        header('HTTP/1.1 405 Method Not Allowed');
        header('Allow: GET, POST, PUT, DELETE');
    break;
}

function get_all_rams(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, clock, capacity, price FROM ram");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_ram_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, clock, capacity, price FROM ram WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_ram($manufacturer, $model, $clock, $capacity, $price){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO ram SET id = default, manufacturer = '$manufacturer', model = '$model', clock = '$clock', capacity = '$capacity', price = '$price'");
}

function update_ram($id, $manufacturer, $model, $clock, $capacity, $price){
    global $connection;

    // Perform query
    $connection -> query("UPDATE vga SET manufacturer = '$manufacturer', model = '$model', clock = '$clock', capacity = '$capacity', price = '$price' WHERE id = '$id'");
}

function delete_ram($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM ram WHERE id = '$id'");
}

?>