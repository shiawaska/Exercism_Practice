using System.Diagnostics;

public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{    
    private ITimer? _timer;
    public StopwatchState State { get; set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap { get; set; } = TimeSpan.Zero;
    public TimeSpan Total { get; set; } = TimeSpan.Zero;
    public List<TimeSpan> PreviousLaps { get; } = [];

    public void Start()
    {
        if (State == StopwatchState.Running) throw new InvalidOperationException();
        State = StopwatchState.Running;
        TimerCallback timerCallback = state =>
        {
            Total = Total.Add(TimeSpan.FromSeconds(1)); 
            CurrentLap = CurrentLap.Add(TimeSpan.FromSeconds(1));
        };
        
       _timer = time.CreateTimer(timerCallback, StopwatchState.Running,TimeSpan.FromSeconds(1),TimeSpan.FromSeconds(1));
    }

    public void Stop()
    {
        if (State == StopwatchState.Stopped || State == StopwatchState.Ready) throw new InvalidOperationException();
        State = StopwatchState.Stopped;
        _timer?.Dispose();
    }

    public void Reset()
    {
        if (_timer == null || State == StopwatchState.Running) throw new InvalidOperationException();
        _timer.Dispose();
        State = StopwatchState.Ready;
        CurrentLap = TimeSpan.Zero;
        Total = TimeSpan.Zero;
        PreviousLaps.Clear();
    }

    public void Lap()
    {
        if (CurrentLap == TimeSpan.Zero) throw new InvalidOperationException();
        PreviousLaps.Insert(PreviousLaps.Count,CurrentLap);
        CurrentLap = TimeSpan.Zero;
    }
}
