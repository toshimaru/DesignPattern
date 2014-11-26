# modularize Subject (more Ruby way!)
module Subject
  def initialize
    @observers = []
  end

  def add_observer(observer)
    @observers << observer
  end

  def delete_observer(observer)
    @observers.delete observer
  end

  def notify_observers
    @observers.each {|o| o.update(self) }
  end
end

class Employee
  include Subject

  attr_reader :name, :title, :salary

  def initialize(name, title, salary)
    super()
    @name = name
    @title = title
    @salary = salary
  end

  def salary=(new_salary)
    @salary = new_salary
    notify_observers
  end
end

class Payroll
  def update(changed_employee)
    puts "Current salary is #{changed_employee.salary}"
  end
end

toshi = Employee.new("toshi", "salary-man", 100_000)
toshi.add_observer Payroll.new()
toshi.salary = 1_000_000
