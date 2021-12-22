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
            $data = get_vga_by_id($id);
            echo json_encode($data);
        }else
            $data = get_all_vgas();
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
        insert_vga($data["manufacturer"], $data["model"], $data["vram"], $data["clock"], $data["price"]);
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
        update_vga($data["id"], $data["manufacturer"], $data["model"], $data["vram"], $data["clock"], $data["price"]);
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

function get_all_vgas(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, vram, clock, price FROM vga");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_vga_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, vram, clock, price FROM vga WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_vga($manufacturer, $model, $vram, $clock, $price){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO vga SET id = default, manufacturer = '$manufacturer', model = '$model', vram = '$vram', clock = '$clock', price = '$price'");
}

function update_vga($id, $manufacturer, $model, $vram, $clock, $price){
    global $connection;

    // Perform query
    $connection -> query("UPDATE vga SET manufacturer = '$manufacturer', model = '$model', vram = '$vram', clock = '$clock', price = '$price' WHERE id = '$id'");
}

function delete_vga($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM vga WHERE id = '$id'");
}

?>