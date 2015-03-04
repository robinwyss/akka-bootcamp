using System;

using Akka.Actor;

namespace WinTail {
  /// <summary>
  ///   Actor responsible for reading FROM the console.
  ///   Also responsible for calling <see cref="ActorSystem.Shutdown" />.
  /// </summary>
  internal class ConsoleReaderActor : UntypedActor {
    public const string ExitCommand = "exit";

    public const string StartCommand = "start";

    private readonly ActorRef _validationActor;

    public ConsoleReaderActor( ActorRef validationActor ) {
      _validationActor = validationActor;
    }

    protected override void OnReceive( object message ) {
      if ( message.Equals( StartCommand ) ) {
        DoPrintInstructions();
      }
      GetAndValidateInput();
    }

    #region Internal methods

    private void DoPrintInstructions() {
      Console.WriteLine( "Write whatever you want into the console!" );
      Console.WriteLine( "Some entries will pass validation, and some won't...\n\n" );
      Console.WriteLine( "Type 'exit' to quit this application at any time.\n" );
    }
    private void GetAndValidateInput() {
      string message = Console.ReadLine();
      if ( !string.IsNullOrEmpty( message ) && message.Equals( ExitCommand ) ) {
        // shut down the entire actor system (allows the process to exit)
        Context.System.Shutdown();
        return;
      }
      _validationActor.Tell( message );
    }

    #endregion
  }
}