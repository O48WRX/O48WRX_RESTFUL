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
            $data = get_psu_by_id($id);
            echo json_encode($data);
        }else
            $data = get_all_psus();
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
        insert_psu($data["manufacturer"], $data["model"], $data["performance"], $data["price"]);
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
        update_psu($data["id"], $data["manufacturer"], $data["model"], $data["performance"], $data["price"]);
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
        delete_psu($data["id"]);
    break;
    
    default:
        header('HTTP/1.1 405 Method Not Allowed');
        header('Allow: GET, POST, PUT, DELETE');
    break;
}

function get_all_psus(){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, performance, price FROM psu");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function get_psu_by_id($id=0){
    global $connection;
    
    // Perform query
    $result = $connection -> query("SELECT id, manufacturer, model, performance, price FROM psu WHERE id = '$id'");
    
    return $result->fetch_all(MYSQLI_ASSOC);
}

function insert_psu($manufacturer, $model, $performance, $price){
    global $connection;
    
    // Perform query
    $result = $connection -> query("INSERT INTO psu SET id = default, manufacturer = '$manufacturer', model = '$model', performance = '$performance', price = '$price'");
}

function update_psu($id, $manufacturer, $model, $performance, $price){
    global $connection;

    // Perform query
    $connection -> query("UPDATE psu SET manufacturer = '$manufacturer', model = '$model', performance = '$performance', price = '$price' WHERE id = '$id'");
}

function delete_psu($id){
    global $connection;

    // Perform query
    $connection -> query("DELETE FROM psu WHERE id = '$id'");
}

?>