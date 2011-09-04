using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Pomodoro.TimeSpanExtensions
{
    public static class TimeSpanExtensionMethods
    {
        public static TimeSpan RoundTimeToNearestSecond(this TimeSpan timeSpan)
        {
            return TimeSpan.FromSeconds(Math.Floor(timeSpan.TotalSeconds));
        }
    }
}
