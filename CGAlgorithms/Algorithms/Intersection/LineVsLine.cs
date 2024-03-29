﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;

namespace CGAlgorithms.Algorithms.Intersection
{
    class LineVsLine : Algorithm
    {
        public override void Run(List<CGUtilities.Point> points, List<CGUtilities.Line> lines, List<CGUtilities.Polygon> polygons, ref List<CGUtilities.Point> outPoints, ref List<CGUtilities.Line> outLines, ref List<CGUtilities.Polygon> outPolygons)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = i + 1; j < lines.Count; j++)
                {
                    double m1 = (lines[i].Start.Y - lines[i].End.Y) / (lines[i].Start.X - lines[i].End.X);
                    double m2 = (lines[j].Start.Y - lines[j].End.Y) / (lines[j].Start.X - lines[j].End.X);

                    if (Math.Abs(m1 - m2) < CGUtilities.Constants.Epsilon)
                    {
                        outLines.Add(new CGUtilities.Line(lines[i].Start, lines[i].End));
                        outLines.Add(new CGUtilities.Line(lines[j].Start, lines[j].End));
                        continue;
                    }
                    Point Intersection = HelperMethods.GetIntersection(lines[i], lines[j]);
                    if (Intersection != null) outPoints.Add(Intersection);
                }
            }
        }

        public override string ToString()
        {
            return "Line Vs Line Intersection";
        }
    }
}
