using Timers;
namespace Bar
{
    public class TimeBar : Bar
    {
        private Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;
            if (_timer != null)
            {
                _timer.HasBeenUpdated += OnValueChanged;
                _timer.TimeIsOver += TimerOver;
            }
        }
        
        private void OnDisable()
        {
            if (_timer != null)
            {
                _timer.HasBeenUpdated -= OnValueChanged;
                _timer.TimeIsOver -= TimerOver;
            }
        }
    }
    
}