using System.Timers;

public class TimedBonus : BaseAttribute {

    private Attribute parent;
    private Timer timer;
    
    /// <param name="time">Time in milliseconds</param>
    public TimedBonus(Attribute parent, int time, int value = 0, float multiplier = 0, string name = "") : base(value, multiplier, name) {
        this.parent = parent;

        //Setup timer
        timer = new Timer(time);
        timer.AutoReset = false;
        timer.Elapsed += OnTimerFinished;
        timer.Start();
    }
    
    /// <summary>
    /// Callback when the timer has run out
    /// </summary>
    private void OnTimerFinished(object source, ElapsedEventArgs e) {
        parent.RemoveBonus(this);
    }

}
