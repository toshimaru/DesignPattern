<?php

class Singleton {
  static protected $instance;

  /**
   * Not allowed to use constructer
   */
  private function __construct() {
  }

  static public function getInstance() {
    if (static::$instance === null)
      static::$instance = new static();
    return static::$instance;
  }
}

$singleton1 = Singleton::getInstance();
$singleton2 = Singleton::getInstance();

print_r ($singleton1 === $singleton2);
