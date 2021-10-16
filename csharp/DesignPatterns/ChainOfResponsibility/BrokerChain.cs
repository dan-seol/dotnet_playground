using System;
using System.Collections.Generic;
using static System.Console;

namespace ChainOfResponsibility
{
     // command query separation is being used here

  public class Query
  {
    public string LineName;

    public enum Argument
    {
      CurrentStation, Passengers
    }

    public Argument WhatToQuery;


    public object Value; // bidirectional

    public Query(string lineName, Argument whatToQuery, object value)
    {
      LineName = lineName ?? throw new ArgumentNullException(paramName: nameof(lineName));
      WhatToQuery = whatToQuery;
      Value = value;
    }
  }

//Mediator pattern
  public class TrainSchedule 
  {
    public event EventHandler<Query> Queries; // effectively a chain

    public void PerformQuery(object sender, Query q)
    {
      Queries?.Invoke(sender, q);
    }
  }
   public class Train
   {    
       private TrainSchedule schedule;
       private string lineName;
       private string currentStation;
       private int passengers;
       public string LineName => lineName;
       public string CurrentStation {
         get
         {
           var q = new Query(LineName, Query.Argument.CurrentStation, currentStation);
           schedule.PerformQuery(this, q);
           return Convert.ToString(q.Value);
           
          }
       }
       public int Passengers {
        get
         {
           var q = new Query(LineName, Query.Argument.Passengers, passengers);
           schedule.PerformQuery(this, q);
           return Convert.ToInt32(q.Value);
          }
       }
       public Train(TrainSchedule schedule, string lineName, string currentStation, int passengers)
       {
           this.schedule = schedule ?? throw new ArgumentNullException(paramName: nameof(schedule));
           this.lineName = lineName ?? throw new ArgumentNullException(paramName: nameof(lineName));
           this.currentStation = currentStation;
           this.passengers = passengers;
       }

       public override string ToString() // no game
       {
         return $"{nameof(lineName)}: {lineName}, {nameof(currentStation)}: {CurrentStation}, {nameof(passengers)}: {Passengers}";
         //                                                                  ^^^^^^^^ using a property               ^^^^^^^^^
       }
       
   }
   
   public abstract class TrainModifier: IDisposable
   {
    protected TrainSchedule schedule;
    protected Train train;
    protected TrainModifier(TrainSchedule schedule, Train train)
    {
      this.schedule = schedule;
      this.train = train;
      schedule.Queries += Handle;
    }

    protected abstract void Handle(object sender, Query q);

    public void Dispose()
    {
      schedule.Queries -= Handle;
    }
  }

  public class NextStationModifier : TrainModifier
  {
    private string nextStation;
    public NextStationModifier(TrainSchedule schedule, Train train, string nextStation) : base(schedule, train)
    {
      this.nextStation = nextStation;
    }

    protected override void Handle(object sender, Query q)
    {
      if (q.LineName == train.LineName &&
          q.WhatToQuery == Query.Argument.CurrentStation)
          {
            WriteLine($"Next station is : {nextStation}");
            q.Value = nextStation;
          }
          
    }
  }

  public class PassengerLeaveModifier : TrainModifier
  {
    private int passengersLeft;
    public PassengerLeaveModifier(TrainSchedule schedule, Train train, int passengersLeft) : base(schedule, train)
    {
      this.passengersLeft = passengersLeft;
    }

    protected override void Handle(object sender, Query q)
    {
      if (q.LineName == train.LineName &&
          q.WhatToQuery == Query.Argument.Passengers) 
          {
            int currentPassengers = Math.Max(0, Convert.ToInt32(q.Value) - this.passengersLeft);
          WriteLine($"There are {currentPassengers} now");
          q.Value = currentPassengers;
          }
          
    }
  }

  public class PassengerArrivalModifier : TrainModifier
  {
    private int passengersArrived;
    public PassengerArrivalModifier(TrainSchedule schedule, Train train, int passengersArrived) : base(schedule, train)
    {
      this.passengersArrived = passengersArrived;
    }

    protected override void Handle(object sender, Query q)
    {
      if (q.LineName == train.LineName &&
          q.WhatToQuery == Query.Argument.Passengers) {
             int currentPassengers = Convert.ToInt32(q.Value) + this.passengersArrived;
            WriteLine($"There are {currentPassengers} now");
            q.Value = currentPassengers;
          }
         

    }
  }
}
