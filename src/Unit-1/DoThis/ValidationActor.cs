using Akka.Actor;

namespace WinTail {
  /// <summary>
  ///   Actor that validates user input and signals result to others.
  /// </summary>
  internal class ValidationActor : UntypedActor {
    private readonly ActorRef _consoleWriterActor;

    public ValidationActor( ActorRef consoleWriterActor ) {
      _consoleWriterActor = consoleWriterActor;
    }

    protected override void OnReceive( object message ) {
      var msg = message as string;
      if ( string.IsNullOrEmpty( msg ) ) {
        // signal that the user needs to supply an input, as previously
        // received input was blank
        _consoleWriterActor.Tell( new Messages.NullInputError( "No input received." ) );
      }
      else {
        bool valid = IsValid( msg );
        if ( valid ) {
          _consoleWriterActor.Tell( new Messages.InputSuccess( "Thank you! Message was valid." ) );
        }
        else {
          _consoleWriterActor.Tell( new Messages.ValidationError( "Invalid: input had odd number of characters." ) );
        }
      }
      Sender.Tell( new Messages.ContinueProcessing() );
    }

    /// <summary>
    ///   Validates <see cref="message" />.
    ///   Currently says messages are valid if contain even number of characters.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private static bool IsValid( string message ) {
      bool valid = message.Length % 2 == 0;
      return valid;
    }
  }
}