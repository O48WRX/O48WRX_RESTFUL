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
            $data = get_mobo_by_id($id);
            echo json_encode($data);
        }else
            $data = get_all_mobos();
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
        insert_mobo($data["manufacturer"], $data["model"], $data["ram_type"], $data["ram_sockets"], $data["price"]);
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
        update_mobo($data["id"], $data["manufacturer"], $data["model"], $data["ram_type"], $data["ram_sockets"], $data["price"]);
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
        delete_mobo($data["id"]);
    break;
    
    default:
        header('HTTP/1.1 405 Method Not Allowed');
        header('Allow: GET, POST, PUT, DELETE');
    break;
}

function get_all_mobos(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, ram_type, ram_sockets, price FROM mobo");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_mobo_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, ram_type, ram_sockets, price FROM mobo WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_mobo($manufacturer, $model, $ram_type, $ram_sockets, $price){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO mobo SET id = default, manufacturer = '$manufacturer', model = '$model', ram_type = '$ram_type', ram_sockets = '$ram_sockets', price = '$price'");
}

function update_mobo($id, $manufacturer, $model, $ram_type, $ram_sockets, $price){
    global $connection;

    // Perform query
    $connection -> query("UPDATE mobo SET manufacturer = '$manufacturer', model = '$model', ram_type = '$ram_type', ram_sockets = '$ram_sockets', price = '$price' WHERE id = '$id'");
}

function delete_mobo($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM mobo WHERE id = '$id'");
}

?>