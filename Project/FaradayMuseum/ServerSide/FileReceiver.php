<?php
    $filename = $_GET["filename"]; 
    $file = $_GET["file"];

    $result = file_put_contents("UploadFolder/" . $filename, $file, FILE_APPEND | LOCK_EX);

    if ($result === FALSE) {
        $result = -1;
    }
    echo $result;
?>