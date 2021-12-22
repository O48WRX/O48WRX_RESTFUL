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

function get_all_orders(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, user_id, processor_id, vga_id, psu_id, ram_id, mobo_id, price FROM ordered");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_order_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, user_id, processor_id, vga_id, psu_id, ram_id, mobo_id, price FROM ordered WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_order($user_id, $processor_id, $vga_id, $psu_id, $ram_id, $mobo_id){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO ordered SET id = default, user_id = '$user_id', processor_id = '$processor_id', vga_id = '$vga_id', psu_id = '$psu_id', ram_id = '$ram_id', mobo_id = '$mobo_id'");
}

function update_order($id, $user_id, $processor_id, $vga_id, $psu_id, $ram_id, $mobo_id){
    global $connection;

    // Perform query
    $connection -> query("UPDATE ordered SET user_id = '$user_id', processor_id = '$processor_id', vga_id = '$vga_id', psu_id = '$psu_id', ram_id = '$ram_id', mobo_id = '$mobo_id' WHERE id = '$id'");
}

function delete_order($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM ordered WHERE id = '$id'");
}

?>