<?php 

class Singleton {
  static private $instance = null;

  function __construct() {
  }

  static public function getInstance() {
    if (self::$instance === null)
      self::$instance = new self();
    return self::$instance;
  }
}

$singleton1 = Singleton::getInstance();
$singleton2 = Singleton::getInstance();
echo ($singleton1 === $singleton2);
