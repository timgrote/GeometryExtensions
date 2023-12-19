﻿using System;

#if BRX_APP
using Teigha.Geometry;
using Teigha.DatabaseServices;

#elif ACAD_APP
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
#endif

namespace Gile.AutoCAD.Geometry
{
	/// <summary>
	/// Provides extension methods for the Ellipse type. 
	/// </summary>
	public static class EllipseExtension
	{
		/// <summary>
		/// Generates a polyline to approximate an ellipse. 
		/// </summary>
		/// <param name="ellipse">The instance to which this method applies.</param>
		/// <returns>A new Polyline instance.</returns>
		public static Polyline ToPolyline(this Ellipse ellipse)
		{
			Polyline pline = new PolylineSegmentCollection(ellipse).ToPolyline();
			pline.Closed = ellipse.Closed;
			pline.Normal = ellipse.Normal;
			pline.Elevation = ellipse.Center.TransformBy(Matrix3d.WorldToPlane(new Plane(Point3d.Origin, ellipse.Normal))).Z;
			return pline;
		}

		/// <summary>
		/// Gets the ellipse parameter corresponding to the specified angle.
		/// </summary>
		/// <param name="ellipse">The instance to which this method applies.</param>
		/// <param name="angle">Angle.</param>
		/// <returns>The parameter corresponding to the angle.</returns>
		public static double GetParamAtAngle(this Ellipse ellipse, double angle) =>
			Math.Atan2(ellipse.MajorRadius * Math.Sin(angle), ellipse.MinorRadius * Math.Cos(angle));

		/// <summary>
		/// Gets the ellipse angle corresponding to the specified parameter.
		/// </summary>
		/// <param name="ellipse">The instance to which this method applies.</param>
		/// <param name="param">Parameter.</param>
		/// <returns>The angle corresponding to the parameter.</returns>
		public static double GetAngleAtParam(this Ellipse ellipse, double param) =>
			Math.Atan2(ellipse.MinorRadius * Math.Sin(param), ellipse.MajorRadius * Math.Cos(param));
	}
}