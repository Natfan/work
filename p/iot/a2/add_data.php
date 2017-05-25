<?php
    include_once 'dbconfig.php';

    if(isset($_POST['save']))
    {
        $name = $_POST['name'];

        $sql_query = "INSERT INTO person(name) VALUES('$name')";
        echo $sql_query;
        mysqli_query($link, $sql_query);
        header("Location: get_data.php");
        exit;
    }
?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Create Person</title>
    </head>
    <body>
        <form method="post">
            <label for="name">Name: </label>
            <input type="text" name="name" required />
            <button type="submit" name="save"><strong>Save</strong></button>
        </form>
    </body>
</html>






