namespace ConsoleApplication
{
  class MainApp
  {
    static void Main (string[] args)
    {
      var receiver = new Receiver ();
      var command = new ConcreteCommand (receiver);
      var invoker = new Invoker ();

      invoker.Command = command;
      invoker.ExecuteCommand ();
    }
  }

  class Receiver
  {
    public void Action ()
    {
      Console.WriteLine ("Receiver.Action()");
    }
  }

  abstract class Command
  {
    protected Receiver receiver;

    public Command (Receiver receiver)
    {
      this.receiver = receiver;
    }

    public abstract void Execute ();
  }

  class ConcreteCommand : Command
  {
    public ConcreteCommand (Receiver receiver) : base(receiver)
    {
    }

    public override void Execute ()
    {
      this.receiver.Action ();
    }
  }

  class Invoker
  {
    private Command _command;

    public Command Command {
      private get { return this._command; }
      set { this._command = value; }
    }

    public void ExecuteCommand ()
    {
      this.Command.Execute ();
    }
  }
}
