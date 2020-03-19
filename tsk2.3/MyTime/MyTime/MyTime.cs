using System;
namespace MyTime
{
    public class MyTime
    {
        private int hour = 0, minute =0, second =0;
        
        public MyTime(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        //Accessor Methods
        public int GetHour() => hour;
        public int GetMinute() => minute;
        public int GetSecond() => second;

        //Mutator methods
        public void SetHour(int hour)
        {
            if(hour==24)
            {
                this.hour = 0;
            }
            else if (hour >24 | hour <0)
            {
                throw new ArgumentException("{0} is not a valid number", hour.ToString());
            }
            else this.hour = hour;
        }
        public void SetMinute(int minute)
        {
            if (minute == 60)
            {
                this.minute = 0;
            }
            else if (minute > 60 | minute < 0)
            {
                throw new ArgumentException("{0} is not a valid number", minute.ToString());
            }
            else this.minute = minute;
        }
        public void SetSecond(int second)
        {
            if (second == 60)
            {
                this.second = 0;
            }
            else if (second > 60 | second < 0)
            {
                throw new ArgumentException("{0} is not a valid number", second.ToString());
            }
            else this.second = second;
        }

        //Convert time to String
        public String TimeToString()
        {
            String Time = "{0}:{1}:{2}";
            String FormattedTime = String.Format(Time, this.hour.ToString("D2"), this.minute.ToString("D2"), this.second.ToString("D2"));
            return FormattedTime;
        }

        //Clock
        public MyTime NextHour()
        {
            this.hour += 1;

            if (this.hour >=24)
            {
                this.hour = 0;
            }
            //Somehow it works
            return this;
        }
        public MyTime NextMinute()
        {
            this.minute += 1;
            if (this.minute >=60)
            {
                NextHour();
                this.minute = 0;
            }
            return this;
        }
        public MyTime NextSecond()
        {
            this.second += 1;
            if(this.second >=60)
            {
                NextMinute();
                this.second = 0;
            }
            return this;
        }

        public MyTime PreviousHour()
        {
            this.hour -= 1;
            if(this.hour <=0)
            {
                this.hour = 23;
            }
            return this;
        }
        public MyTime PreviousMinute()
        {
            this.minute -= 1;
            if(this.minute <=0)
            {
                PreviousHour();
                this.minute = 59;
            }
            return this;
        }
        public MyTime PreviousSecond()
        {
            this.second -= 1;
            if(this.second <=0)
            {
                PreviousMinute();
                this.second = 59;
            }
            return this;
        }
        
    }
}
