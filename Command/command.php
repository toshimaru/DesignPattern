<?php

class Receiver {
	public function write($str) {
		echo $str;
	}
}

class Command implements CommandInterface {
	protected $output;

	function __construct(Receiver $output) {
		$this->output = $output;
	}

	public function execute() {
		$this->output->write('Hello!');
	}
}

class Invoker {
	protected $command;

	public function setCommand(CommandInterface $cmd ) {
		$this->command = $cmd;
	}

	public function run() {
		$this->command->execute();
	}
}

interface CommandInterface {
	public function execute();
}

$receiver = new Receiver();
$command  = new Command($receiver);
$invoker  = new Invoker();

$invoker->setCommand($command);
$invoker->run();
