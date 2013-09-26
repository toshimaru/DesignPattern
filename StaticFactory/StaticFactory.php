<?php

interface FactoryInterface {
}

class Foo implements FactoryInterface {
}

class Bar implements FactoryInterface {
}

class StaticFactory {
	public static function factory($type) {
		$className = ucfirst($type);
		if (!class_exists($className)) {
			throw new InvalidArgumentException('Missing format class.');
		}
		return new $className();
	}
}

StaticFactory::factory('foo');
StaticFactory::factory('bar');
