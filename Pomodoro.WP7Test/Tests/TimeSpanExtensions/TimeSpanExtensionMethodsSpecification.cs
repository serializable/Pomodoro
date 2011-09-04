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
using ExecutableSpecification;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro.TimeSpanExtensions;
using ExecutableSpecfication;

namespace Pomodoro.WP7Test.Tests.TimeSpanExtensions
{
    [TestClass]
    public class TimeSpanExtensionMethodsSpecification : SilverlightTest
    {
        [TestMethod]
        public void It_should_round_to_nearest_lowest_second()
        {
            var target = TimeSpan.FromMilliseconds(2500);
            var actual = target.RoundTimeToNearestSecond();
            actual.ShouldEqual(TimeSpan.FromSeconds(2));
        }
    }
}
