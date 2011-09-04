using System;

namespace Pomodoro.Timer
{
    public class CountdownTimerEventArgs : EventArgs
    {
        public TimeSpan RemainingTime { get; set; }
    }
}