﻿#if BRX_APP
using Teigha.Geometry;

#elif ACAD_APP
using Autodesk.AutoCAD.Geometry;
#endif

namespace AID.GeometryExtensions
{
	/// <summary>
	/// Provides extension methods for the Vector2d type.
	/// </summary>
	public static class Vector2dExtension
	{
		/// <summary>
		/// Converts a Vector2d into a Vector3d with a Z coordinate equal to 0.
		/// </summary>
		/// <param name="pt">The instance to which this method applies.</param>
		/// <returns>The corresponding Vector..</returns>
		public static Vector3d Convert3d(this Vector2d pt) =>
			new Vector3d(pt.X, pt.Y, 0.0);

		/// <summary>
		/// Converts a Vector2d into a Vector3d according to the specified plane.
		/// </summary>
		/// <param name="vector">The instance to which this method applies.</param>
		/// <param name="plane">The plane the Point2d lies on.</param>
		/// <returns>The corresponding Vector3d.</returns>
		public static Vector3d Convert3d(this Vector2d vector, Plane plane) =>
			vector.Convert3d().TransformBy(Matrix3d.PlaneToWorld(plane));
	}
}