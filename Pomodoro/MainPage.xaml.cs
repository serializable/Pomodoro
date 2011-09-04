using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Pomodoro.Timer;

namespace Pomodoro
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly CountdownTimer _timer;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            _timer = new CountdownTimer();

            SetButtonsState(TimerStatus.Stopped);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            _timer.Tick += Timer_Tick;
            UpdateTimerText();
            butStartTimer.IsEnabled = true;
        }

        void Timer_Tick(object sender, CountdownTimerEventArgs e)
        {
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            txtTimer.Text = string.Format("{0:00}:{1:00}", _timer.RemainingTime.Minutes, _timer.RemainingTime.Seconds);
        }

        private void butStartTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            SetButtonsState(TimerStatus.Started);
        }

        private void butStopTimer_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            SetButtonsState(TimerStatus.Stopped);
        }

        private void SetButtonsState(TimerStatus status)
        {
            if (status == TimerStatus.Started)
            {
                butStartTimer.IsEnabled = false;
                butStopTimer.IsEnabled = true;
            }
            else
            {
                butStartTimer.IsEnabled = true;
                butStopTimer.IsEnabled = false;
            }
        }

        enum TimerStatus
        {
            Stopped = 0,
            Started
        }
    }
}