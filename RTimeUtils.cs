using System;
using Terraria;

namespace ReallyifsUtils
{
    public static class RTimeUtils
    {
        private const double TimeMax = 54000;

        /// <summary>
        /// 检查现在所在时间在以下哪个时间段，如果所有参为false则返回false
        /// </summary>
        /// <param name="morning">早晨</param>
        /// <param name="midday">中午</param>
        /// <param name="afternoon">下午</param>
        /// <param name="eve">前夜</param>
        /// <param name="midnight">午夜</param>
        /// <param name="earlyMorning">凌晨</param>
        /// <returns></returns>
        public static bool InThisTime(bool morning = false, bool midday = false, bool afternoon = false, bool eve = false,
            bool midnight = false, bool earlyMorning = false)
        {
            if (morning && Main.dayTime && Main.time < TimeMax / 3d)
                return true;
            if (midday && Main.dayTime && Main.time > TimeMax / 3d && Main.time < TimeMax / (2d / 3d))
                return true;
            if (afternoon && Main.dayTime && Main.time > TimeMax / (2d / 3d))
                return true;
            if (eve && !Main.dayTime && Main.time < TimeMax / 3d)
                return true;
            if (midnight && !Main.dayTime && Main.time > TimeMax / 3d && Main.time < TimeMax / (2d / 3d))
                return true;
            if (earlyMorning && !Main.dayTime && Main.time > TimeMax / (2d / 3d))
                return true;
            return false;
        }

        public static TimeSpan FromDays(this int number) => TimeSpan.FromDays(number);
        public static TimeSpan FromDays(this float number) => TimeSpan.FromDays(number);
        public static TimeSpan FromDays(this double number) => TimeSpan.FromDays(number);
        public static TimeSpan FromHours(this int number) => TimeSpan.FromHours(number);
        public static TimeSpan FromHours(this float number) => TimeSpan.FromHours(number);
        public static TimeSpan FromHours(this double number) => TimeSpan.FromHours(number);
        public static TimeSpan FromMinutes(this int number) => TimeSpan.FromMinutes(number);
        public static TimeSpan FromMinutes(this float number) => TimeSpan.FromMinutes(number);
        public static TimeSpan FromMinutes(this double number) => TimeSpan.FromMinutes(number);
        public static TimeSpan FromSeconds(this int number) => TimeSpan.FromSeconds(number);
        public static TimeSpan FromSeconds(this float number) => TimeSpan.FromSeconds(number);
        public static TimeSpan FromSeconds(this double number) => TimeSpan.FromSeconds(number);
        public static TimeSpan FromMilliseconds(this int number) => TimeSpan.FromMilliseconds(number);
        public static TimeSpan FromMilliseconds(this float number) => TimeSpan.FromMilliseconds(number);
        public static TimeSpan FromMilliseconds(this double number) => TimeSpan.FromMilliseconds(number);
        public static TimeSpan FromTicks(this int number) => TimeSpan.FromTicks(number);
        public static TimeSpan FromTicks(this long number) => TimeSpan.FromTicks(number);
        public static TimeSpan FromTicks(this float number) => TimeSpan.FromTicks((int)number);
        public static TimeSpan FromTicks(this double number) => TimeSpan.FromTicks((int)number);
    }
}