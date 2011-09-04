using System;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Pomodoro.TimeSpanExtensions;

namespace Pomodoro.Timer
{
    public class CountdownTimer
    {
        public TimeSpan RemainingTime { get; private set; }

        public delegate void CountdownTimerEventHandler(object sender, CountdownTimerEventArgs eventArgs);
        public event CountdownTimerEventHandler Tick;

        private readonly DispatcherTimer _timer;
        private readonly TimeSpan _defaultTimeInterval = TimeSpan.FromMinutes(25);

        public CountdownTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            Reset();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            RemainingTime = RemainingTime - TimeSpan.FromSeconds(1);
            if (Tick != null)
                Tick(this, new CountdownTimerEventArgs {RemainingTime = this.RemainingTime});
        }

        public void Start()
        {
            Reset();
            _timer.Start();
        }

        private void Reset()
        {
            RemainingTime = _defaultTimeInterval;
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
