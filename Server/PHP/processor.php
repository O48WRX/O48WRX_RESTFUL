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
            $data = get_processor_by_id($id);
            echo json_encode($data);
        }else
            $data = get_all_processors();
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
        insert_processor($data["manufacturer"], $data["model"], $data["clock"], $data["price"]);
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
        update_processor($data["id"], $data["manufacturer"], $data["model"], $data["clock"], $data["price"]);
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
        delete_processor($data["id"]);
    break;
    
    default:
        header('HTTP/1.1 405 Method Not Allowed');
        header('Allow: GET, POST, PUT, DELETE');
    break;
}

function get_all_processors(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, clock, price FROM processor");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_processor_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, clock, price FROM processor WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_processor($manufacturer, $model, $clock, $price){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO processor SET id = default, manufacturer = '$manufacturer', model = '$model', clock = '$clock', price = '$price'");
}

function update_processor($id, $manufacturer, $model, $clock, $price){
    global $connection;

    // Perform query
    $connection -> query("UPDATE processor SET manufacturer = '$manufacturer', model = '$model', clock = '$clock', price = '$price' WHERE id = '$id'");
}

function delete_processor($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM processor WHERE id = '$id'");
}

?>