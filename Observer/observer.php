<?php

class User implements SplSubject {
    protected $data = array();

    /**
     * attach an observer
     */
    public function attach(SplObserver $observer) {
        $this->observers[] = $observer;
    }

    /**
     * detach an observer
     */
    public function detach(\SplObserver $observer) {
        $index = array_search($observer, $this->observers);
        if (false !== $index) {
            unset($this->observers[$index]);
        }
    }

    /**
     * notify observers
     */
    public function notify() {
        foreach ($this->observers as $observer) {
            $observer->update($this);
        }
    }

    public function __set($name, $value) {
        $this->data[$name] = $value;

        // notify the observers, that user has been updated
        $this->notify();
    }
}


/**
 * class UserObserver
 */
class UserObserver1 implements SplObserver {
    public function update(SplSubject $subject) {
        echo __CLASS__ . ':' . get_class($subject) . ' has been updated';
    }
}
class UserObserver2 implements SplObserver {
    public function update(SplSubject $subject) {
        echo __CLASS__ . ':' . get_class($subject) . ' has been updated';
    }
}

$observer1 = new UserObserver1();
$observer2 = new UserObserver2();

$user = new User();
$user->attach($observer1);
$user->attach($observer2);
$user->foo = 'bar';
// $user->notify();
