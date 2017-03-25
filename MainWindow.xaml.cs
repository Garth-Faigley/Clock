using System;
using System.Windows;
using System.Windows.Threading;

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Time _clock;

        public MainWindow()
        {
            InitializeComponent();
            _clock = new Time();
            var timer = new DispatcherTimer();
            DataContext = _clock;

            timer.Tick += TimerTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }


        //timer event handler
        private void TimerTick(object sender, EventArgs e)
        {
            // get current time
            var hour = DateTime.Now.Hour;
            var minute = DateTime.Now.Minute;
            var second = DateTime.Now.Second;
            var amPm = "AM";

            //time
            var time = "";

            //padding leading zero
            if (hour > 12)
            {
                time += (hour - 12);
                amPm = "PM";
            }
            else
            {
                time += hour;
            }

            time += ":";

            if (minute < 10)
            {
                time += "0" + minute;
            }
            else
            {
                time += minute;
            }
            time += ":";

            if (second < 10)
            {
                time += "0" + second;
            }
            else
            {
                time += second;
            }

            time += " " + amPm;

            //update label
            _clock.CurrentTime = time;
        }

    }
}
