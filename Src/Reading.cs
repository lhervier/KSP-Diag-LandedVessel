namespace com.github.lhervier.ksp.diag.landedvessel
{
    /// <summary>
    /// One line of the table: where the vessel started the scene, where it is now, and the highest it went
    /// in between. All start unknown, and a frozen line is just one that has stopped being updated.
    /// </summary>
    internal class Reading
    {
        public double OnRailsMm = double.NaN;
        public double SettledMm = double.NaN;
        public double HighestMm = double.NaN;

        /// <summary>
        /// How far the vessel ended up from the position the save gave back, in millimetres, negative
        /// downwards. NaN as long as either of the two distances is unknown.
        /// </summary>
        public double MovedMm()
        {
            return SettledMm - OnRailsMm;
        }

        /// <summary>
        /// How far above the position the save gave back the vessel went at its highest, in millimetres.
        /// NaN as long as either of the two distances is unknown.
        /// </summary>
        public double RoseMm()
        {
            return HighestMm - OnRailsMm;
        }
    }
}
