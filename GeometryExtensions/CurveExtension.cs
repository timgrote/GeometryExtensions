#if BRX_APP
using Teigha.Geometry;
using Teigha.DatabaseServices;

#elif ACAD_APP
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
# endif

namespace Gile.AutoCAD.Geometry
{
	/// <summary>
	/// Provides extension methods for the Curve type.
	/// </summary>
	public static class CurveExtension
	{
		/// <summary>
		/// Checks if <paramref name="point"/> is within the distance Tolerance.EqualPoint from this curve.
		/// </summary>
		/// <param name="curve">The instance of Curve to which this method applies.</param>
		/// <param name="point">Point to check against.</param>
		/// <param name="tolerance">Tolerance value.</param>
		/// <returns>true, if the condition is met; otherwise, false.</returns>
		public static bool IsPointOnCurve(this Curve curve, Point3d point, Tolerance tolerance) =>
			point.IsEqualTo(curve.GetClosestPointTo(point, false), tolerance);

		/// <summary>
		/// Calls curve.IsPointOnCurve(Point3d point, Tolerance tolerance) with tolerance set to Global.
		/// </summary>
		/// <param name="curve">The instance of Curve to which this method applies.</param>
		/// <param name="point">Point to check against.</param>
		/// <returns>true, if the condition is met; otherwise, false.</returns>
		public static bool IsPointOnCurve(this Curve curve, Point3d point) =>
			curve.IsPointOnCurve(point, Tolerance.Global);
	}
}