<?php
    include_once 'dbconfig.php';
?>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>List People</title>
    </head>
    <body>
        <a href="add_data.php">Add new</a>
        <table width="300px">
            <tr>
                <th align="left">ID</th>
                <th align="left">Name</th>
                <th align="left">Delete</th>
                <th align="left">Edit</th>
            </tr>
            <?php
                $sql_query="SELECT * FROM person";
                $result_set=mysqli_query($link, $sql_query);
                
                while($row=mysqli_fetch_row($result_set))
                { ?>
                    <tr>
                        <td align="left"><?= $row[0] ?></td>
                        <td align="left"><?= $row[1] ?></td>
                        <td align="left"><a href="delete_data.php?delete_id=<?= $row[0] ?>">Delete</a></td>
                        <td align="left"><a href="update_data.php?edit_id=<?= $row[0] ?>">Edit</a></td>
                    </tr>
                <?php } ?>
        </table>
    </body>
</html>



