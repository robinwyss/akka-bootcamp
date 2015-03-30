using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Akka.Actor;
using Akka.Util.Internal;

using ChartApp.Actors;

namespace ChartApp {
  public partial class Main : Form {
    private ActorRef _coordinatorActor;

    private readonly Dictionary<CounterType, ActorRef> _toggleActors = new Dictionary<CounterType, ActorRef>();

    private ActorRef _chartActor;

    private readonly AtomicCounter _seriesCounter = new AtomicCounter( 1 );

    public Main() {
      InitializeComponent();
    }

    #region Initialization

    private void Main_Load( object sender, EventArgs e ) {
      _chartActor = Program.ChartActors.ActorOf( Props.Create( () => new ChartingActor( sysChart, pauseBtn ) ), "charting" );
      _chartActor.Tell( new ChartingActor.InitializeChart( null ) ); //no initial series

      _coordinatorActor = Program.ChartActors.ActorOf( Props.Create( () =>
              new PerformanceCounterCoordinatorActor( _chartActor ) ), "counters" );

      // CPU button toggle actor
      _toggleActors[CounterType.Cpu] = Program.ChartActors.ActorOf(
          Props.Create( () => new ButtonToggleActor( _coordinatorActor, cpuBtn, CounterType.Cpu, false ) )
              .WithDispatcher( "akka.actor.synchronized-dispatcher" ) );

      // MEMORY button toggle actor
      _toggleActors[CounterType.Memory] = Program.ChartActors.ActorOf(
         Props.Create( () => new ButtonToggleActor( _coordinatorActor, memoryBtn, CounterType.Memory, false ) )
             .WithDispatcher( "akka.actor.synchronized-dispatcher" ) );

      // DISK button toggle actor
      _toggleActors[CounterType.Disk] = Program.ChartActors.ActorOf(
         Props.Create( () => new ButtonToggleActor( _coordinatorActor, diskBtn, CounterType.Disk, false ) )
             .WithDispatcher( "akka.actor.synchronized-dispatcher" ) );

      // Set the CPU toggle to ON so we start getting some data
      _toggleActors[CounterType.Cpu].Tell( new ButtonToggleActor.Toggle() );
    }

    #endregion

    private void memoryBtn_Click( object sender, EventArgs e ) {
      _toggleActors[CounterType.Memory].Tell( new ButtonToggleActor.Toggle() );
    }

    private void diskBtn_Click( object sender, EventArgs e ) {
      _toggleActors[CounterType.Disk].Tell( new ButtonToggleActor.Toggle() );
    }

    private void cpuBtn_Click( object sender, EventArgs e ) {
      _toggleActors[CounterType.Cpu].Tell( new ButtonToggleActor.Toggle() );
    }


    private void pauseBtn_Click( object sender, EventArgs e ) {
      _chartActor.Tell( new ChartingActor.TogglePause() );
    }
  }
}