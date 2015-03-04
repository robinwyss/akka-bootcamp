using Akka.Actor;

namespace WinTail {

  #region Program

  internal class Program {
    public static ActorSystem MyActorSystem;

    private static void Main( string[] args ) {
      // initialize MyActorSystem
      ActorSystem actorSystem = ActorSystem.Create( "MyActorSystem" );

      // time to make your first actors!
      Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
      ActorRef consoleWriterActor = actorSystem.ActorOf( consoleWriterProps, "consoleWriterActor" );

      Props validationProps = Props.Create( () => new ValidationActor( consoleWriterActor ) );
      ActorRef validationActor = actorSystem.ActorOf( validationProps, "validationActor" );

      Props consoleReaderProps = Props.Create<ConsoleReaderActor>( validationActor );
      ActorRef consoleReaderActor = actorSystem.ActorOf( consoleReaderProps, "consoleReaderActor" );

      // tell console reader to begin
      consoleReaderActor.Tell( ConsoleReaderActor.StartCommand );

      // blocks the main thread from exiting until the actor system is shut down
      actorSystem.AwaitTermination();
    }
  }

  #endregion
}