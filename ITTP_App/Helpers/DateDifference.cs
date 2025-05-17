namespace ITTP_App.Helpers
{
    public struct DateDifference
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int increment = 0;
        private int[] monthDay = new int[12] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30,
31 };
        public int Year;
        public int Month;
        public int Day;

        public DateDifference(DateTime d1, DateTime d2)
        {
            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }

            increment = 0;
            if (this.fromDate.Day > this.toDate.Day)
            {
                increment = this.monthDay[this.fromDate.Month - 1];
            }

            if (increment == -1)
            {
                if (DateTime.IsLeapYear(this.fromDate.Year))
                {
                    increment = 29;
                }
                else
                {
                    increment = 28;
                }
            }

            if (increment != 0)
            {
                Day = (this.toDate.Day + increment) - this.fromDate.Day;
                increment = 1;
            }
            else
            {
                Day = this.toDate.Day - this.fromDate.Day;
            }

            if ((this.fromDate.Month + increment) > this.toDate.Month)
            {
                this.Month = (this.toDate.Month + 12) - (this.fromDate.Month + increment);
                increment = 1;
            }
            else
            {
                this.Month = (this.toDate.Month) - (this.fromDate.Month + increment);
                increment = 0;
            }

            this.Year = this.toDate.Year - (this.fromDate.Year + increment);
        }
    }
}
