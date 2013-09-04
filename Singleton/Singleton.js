
// http://coffeescriptcookbook.com/chapters/design_patterns/singleton

var Singleton = (function() {
  function Singleton(){};

  var instance = null;

  var PrivateClass = (function() {
    function PrivateClass(message) {
      this.message = message;
    }
    PrivateClass.prototype.echo = function() {
      console.log(this.message);
    };
    return PrivateClass;
  })();

  Singleton.get = function(message) {
    return instance != null ? instance : instance = new PrivateClass(message);
  };
  
  return Singleton;
})();


a = Singleton.get("message1");
a.echo();

b = Singleton.get("message2");
b.echo();

