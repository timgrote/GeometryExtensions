

namespace Gile.AutoCAD.Geometry
{
    /// <summary>
    /// Provides extension methods for the Vector2d type.
    /// </summary>
    public static class Vector3dExtension
    {
        /// <summary>
        /// Projects the point on the WCS XY plane.
        /// </summary>
        /// <param name="vector">The instance to which this method applies.</param>
        /// <returns>he projected vector.</returns>
        public static Vector3d Flatten(this Vector3d vector) => new(vector.X, vector.Y, 0.0);

        /// <summary>
        /// Returns the angle in rads from the x-axis that is used for the rotation of a block aligned with the vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static double RadsFromXAxis(this Vector3d vec)
        {
            var xAxis = new Vector3d(1, 0, 0);
            return Math.Atan2(vec.Y - xAxis.Y, vec.X - xAxis.X);
        }

        /// <summary>
        /// Returns the angle in degrees from the x-axis that is used for the rotation of a block aligned with the vector
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public static double DegreesFromXAxis(this Vector3d vec)
        {
            var xAxis = new Vector3d(1, 0, 0);
            var rads = Math.Atan2(vec.Y - xAxis.Y, vec.X - xAxis.X);
            return rads * 180 / Math.PI;
        }
    }
}
