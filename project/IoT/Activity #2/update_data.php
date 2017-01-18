<?php
    include_once 'dbconfig.php';

    if(isset($_GET['edit_id']))
    {
        $sql_query="SELECT * FROM person WHERE id=".$_GET['edit_id'];
        $result_set=mysqli_query($link, $sql_query);
        $fetched_row=mysqli_fetch_array($result_set);
    }

    if(isset($_POST['update']))
    {
        $name = $_POST['name'];
        $sql_query = "UPDATE person SET name='$name' WHERE id=".$_GET['edit_id'];
        mysqli_query($link, $sql_query);
        print_r($sql_query);

        header("Location: get_data.php");
        exit;
    }
?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Edit Person</title>
    <link rel="stylesheet" href="style.css" type="text/css" />
    </head>
    <body>
        <form method="post">
            <label for="name">Name: </label>
            <input type="text" name="name" required value="<?php echo $fetched_row['name']?>"/>
            <button type="submit" name="update"><strong>Save</strong></button>
        </form>
    </body>
</html>





