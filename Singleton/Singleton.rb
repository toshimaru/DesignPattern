require 'singleton'
class SingletonObject
  include Singleton
  attr_accessor :counter

  def initialize
    @counter = 0
  end
end

# private method `new' called for SingletonObject:Class
#SingletonObject.new
a,b = SingletonObject.instance, SingletonObject.instance
puts "a==b = #{a == b}"
puts a.counter # => 0
a.counter += 1
puts b.counter # => 1
