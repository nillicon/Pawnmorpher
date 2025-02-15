﻿// TimeMetrics.cs modified by Iron Wolf for Pawnmorph on 12/08/2019 9:28 AM
// last updated 12/08/2019  9:28 AM

namespace Pawnmorph.Utilities
{
    /// <summary>
    ///     static class containing time related metrics
    /// </summary>
    public static class TimeMetrics
    {
        /// <summary>
        ///     The ticks per day
        /// </summary>
        public const int TICKS_PER_DAY = 60000;

        /// <summary>
        ///     The ticks per hour
        /// </summary>
        public const int TICKS_PER_HOUR = 2500;

        /// <summary>
        ///     The ticks per real second
        /// </summary>
        /// also the tick frequency in hertz
        public const int TICKS_PER_REAL_SECOND = 60;

        /// <summary>
        ///     The tick period in (real) seconds
        /// </summary>
        public const float TICK_PERIOD = 1f / TICKS_PER_REAL_SECOND;
    }
}