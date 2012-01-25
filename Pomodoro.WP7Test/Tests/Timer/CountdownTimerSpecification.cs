using System;
using ExecutableSpecfication;
using ExecutableSpecification;
using Microsoft.Silverlight.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro.Timer;

namespace Pomodoro.WP7Test.Tests.Timer
{
    public class CountdownTimerSpecfication : ContextSpecification<CountdownTimer>
    {
        protected override CountdownTimer CreateSystemUnderTest()
        {
            return new CountdownTimer();
        }

        [TestClass]
        public class When_the_timer_is_constructed : CountdownTimerSpecfication
        {
            [TestMethod]
            [Tag("Specification")]
            public void It_should_read_the_default_time()
            {
                Sut.RemainingTime.ShouldEqual(new TimeSpan(0, 0, 25, 0));
            }
        }

        [TestClass]
        public class When_the_timer_is_started : CountdownTimerSpecfication
        {
            private bool _tickCallbackHasBeenCalled;
            private TimeSpan _remainingTime;
            private CountdownTimer _eventSender;

            protected override void GivenThat()
            {
                _tickCallbackHasBeenCalled = false;
                _remainingTime = new TimeSpan();
                _eventSender = null;
                Sut.Tick += (o, e) =>
                                {
                                    _tickCallbackHasBeenCalled = true;
                                    _remainingTime = e.RemainingTime;
                                    _eventSender = o as CountdownTimer;
                                };
            }

            protected override void BecauseOf()
            {
                Sut.Start();
            }

            [TestMethod]
            [Tag("Specification")]
            [Asynchronous]
            public void It_should_raise_the_tick_event_after_a_while()
            {
                EnqueueConditional(() => _tickCallbackHasBeenCalled);
                EnqueueCallback(() => _tickCallbackHasBeenCalled.ShouldBeTrue());
                EnqueueTestComplete();
            }

            [TestMethod]
            [Tag("Specification")]
            [Asynchronous]
            public void It_should_pass_itself_as_the_sender_with_the_tick_event()
            {
                EnqueueConditional(() => _tickCallbackHasBeenCalled);
                EnqueueCallback(() => _eventSender.ShouldEqual(Sut));
                EnqueueTestComplete();
            }

            [TestMethod]
            [Tag("Specification")]
            [Asynchronous]
            public void It_should_read_less_than_default_on_tick()
            {
                EnqueueConditional(() => _tickCallbackHasBeenCalled);
                EnqueueCallback(() => _remainingTime.ShouldBeLessThan(TimeSpan.FromMinutes(25)));
                EnqueueTestComplete();
            }
        }

        [TestClass]
        public class When_the_timer_is_stopped : CountdownTimerSpecfication
        {
            private bool _tickCallbackHasBeenCalled;

            protected override void GivenThat()
            {
                _tickCallbackHasBeenCalled = false;
                Sut.Tick += (o, e) =>
                {
                    _tickCallbackHasBeenCalled = true;
                };
                Sut.Start();
            }

            [Asynchronous]
            protected override void BecauseOf()
            {
                Sut.Stop();
            }

            [TestMethod]
            [Asynchronous]
            [Tag("Specification")]
            public void It_should_stop_raising_tick_events()
            {
                EnqueueCallback(() => _tickCallbackHasBeenCalled.ShouldBeFalse());
                EnqueueTestComplete();
            }
        }

        [TestClass]
        public class When_the_timer_is_restarted : CountdownTimerSpecfication
        {
            protected override void GivenThat()
            {
                Sut.Start();
            }

            [Asynchronous]
            protected override void BecauseOf()
            {
                Sut.Stop();
                Sut.Start();
            }

            [TestMethod]
            [Tag("Specification")]
            [Asynchronous]
            public void It_should_reset_the_remaining_time_to_detault()
            {
                EnqueueDelay(TimeSpan.FromSeconds(2));
                EnqueueCallback(() => Sut.Stop());
                EnqueueCallback(() => Sut.Start());
                EnqueueCallback(() => Sut.RemainingTime.ShouldEqual(TimeSpan.FromMinutes(25)));
                EnqueueTestComplete();
            }
        }
    }
}
