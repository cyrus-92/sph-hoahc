using System;

namespace SPH.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToStartTimeOfDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public static DateTime ToEndTimeOfDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        public static DateTime ToStartTimeOfHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
        }

        public static DateTime ToEndTimeOfHour(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, 59, 59);
        }

        public static DateTime ToStartDateOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime ToEndDateOfMonth(this DateTime date)
        {
            return date.ToStartDateOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime ToStartDateOfYear(this DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        public static DateTime ToEndDateOfYear(this DateTime date)
        {
            return date.ToStartDateOfYear().AddYears(1).AddDays(-1);
        }

        public static DateTime ToStartTimeOfMinute(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
        }

        public static DateTime ToUTCTime(this DateTime date)
        {
            return DateTime.SpecifyKind(date, DateTimeKind.Utc);
        }

        public static long ToUnixTime(this DateTime date)
        {
            return (long)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static long ToDifference(this DateTime issuedTime, DateTime expiredTime)
        {
            return (long)(expiredTime.Subtract(issuedTime)).TotalMinutes;
        }

        public static DateTime ToDateTime(this long timestamp)
        {
            return new DateTime(1970, 1, 1).AddSeconds(timestamp);
        }

        public static DateTime RoundUp(this DateTime dateTime, TimeSpan timeSpan)
        {
            return new DateTime((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks * timeSpan.Ticks, dateTime.Kind);
        }

        public static string GetString(this TimeSpan timeSpan)
        {
            if (timeSpan.Days > 0)
                return timeSpan.ToString(@"dd\.hh\:mm\:ss");

            if (timeSpan.Hours > 0)
                return timeSpan.ToString(@"hh\:mm\:ss");

            if (timeSpan.Minutes > 0)
                return timeSpan.ToString(@"mm\:ss");

            return timeSpan.ToString(@"ss");
        }

        public static DateTime ToClientTime(this DateTime value, int tzOffset)
        {
            value = value.AddMinutes(tzOffset);
            value = DateTime.SpecifyKind(value, DateTimeKind.Local);
            return value;
        }

        public static TimeSpan GetTimeSpan(this int timezoneOffset)
            => TimeSpan.FromMinutes(timezoneOffset);
    }
}
