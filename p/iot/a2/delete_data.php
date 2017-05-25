<?php
    include_once 'dbconfig.php';

    if(isset($_GET['delete_id']))
    {
        $sql_query = "DELETE FROM person WHERE id =".$_GET['delete_id'];
        echo $sql_query;
        print_r($_GET);
        mysqli_query($link, $sql_query);
    }

    header("Location: get_data.php");
    exit;
?>




