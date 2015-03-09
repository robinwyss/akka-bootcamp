﻿using Akka.Actor;

namespace WinTail {
  internal class Program {
    public static ActorSystem MyActorSystem;

    private static void Main( string[] args ) {
      // make an actor system 
      MyActorSystem = ActorSystem.Create( "MyActorSystem" );

      // this is here to show you what NOT to do
      // this approach to props has no type safety
      // it will compile, but can easily blow up in your face at runtime :(
      // UNCOMMENT THE BELOW TWO LINES, BUILD THE SOLUTION, AND THEN TRY TO RUN IT TO SEE
      //Props fakeActorProps = Props.Create( typeof( FakeActor ) );
      //ActorRef fakeActor = MyActorSystem.ActorOf( fakeActorProps, "fakeActor" );

      // set up actors, using props (split props onto own line so easier to read)
      Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
      ActorRef consoleWriterActor = MyActorSystem.ActorOf( consoleWriterProps, "consoleWriterActor" );

      Props tailCoordinatorProps = Props.Create<TailCoordinatorActor>();
      ActorRef tailCoordinatorActor = MyActorSystem.ActorOf( tailCoordinatorProps, "tailCoordinatorActor" );

      Props validationActorProps = Props.Create<FileValidatorActor>( consoleWriterActor );
      ActorRef validationActor = MyActorSystem.ActorOf( validationActorProps, "validationActor" );

      Props consoleReaderProps = Props.Create<ConsoleReaderActor>();
      ActorRef consoleReaderActor = MyActorSystem.ActorOf( consoleReaderProps, "consoleReaderActor" );

      // tell console reader to begin
      consoleReaderActor.Tell( ConsoleReaderActor.StartCommand );

      // blocks the main thread from exiting until the actor system is shut down
      MyActorSystem.AwaitTermination();
    }

    /// <summary>
    /// Fake actor / marker class. Does nothing at all, and not even an actor actually. 
    /// Here to show why you shouldn't use typeof approach to Props.
    /// </summary>
    public class FakeActor {
    }
  }
}