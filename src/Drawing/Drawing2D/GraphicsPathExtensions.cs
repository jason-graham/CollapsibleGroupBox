//---------------------------------------------------------------------------- 
//
//  Copyright (C) Jason Graham.  All rights reserved.
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
// 
// Adapted from
//  http://tech.pro/tutorial/656/csharp-creating-rounded-rectangles-using-a-graphics-path
// History
//  08/29/13    Converted to extension method, cleaned code, added comments.
//
//---------------------------------------------------------------------------

namespace System.Drawing.Drawing2D
{
    public static class GraphicsPathExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="layout"></param>
        /// <param name="radius"></param>
        /// <param name="corners"></param>
        public static void AddRoundedRectangle(this GraphicsPath path, Rectangle layout, int radius, RectangleCorners corners)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            if (radius < 0)
                throw new ArgumentOutOfRangeException("radius");

            //map the structure
            int xw = layout.Right,
                yh = layout.Bottom,
                xwr = xw - radius,
                yhr = yh - radius,
                xr = layout.X + radius,
                yr = layout.Y + radius,
                r2 = radius * 2,
                xwr2 = xw - r2,
                yhr2 = yh - r2;

            //create new figure
            path.StartFigure();

            //draw top left corner
            if (corners.HasFlag(RectangleCorners.TopLeft))
                path.AddArc(layout.X, layout.Y, r2, r2, 180, 90);
            else
            {
                path.AddLine(layout.X, yr, layout.X, layout.Y);
                path.AddLine(layout.X, layout.Y, xr, layout.Y);
            }

            //draw top line
            path.AddLine(xr, layout.Y, xwr, layout.Y);

            //draw top right corner
            if (corners.HasFlag(RectangleCorners.TopRight))
                path.AddArc(xwr2, layout.Y, r2, r2, 270, 90);
            else
            {
                path.AddLine(xwr, layout.Y, xw, layout.Y);
                path.AddLine(xw, layout.Y, xw, yr);
            }

            //draw right line
            path.AddLine(xw, yr, xw, yhr);

            //draw bottom right corner
            if (corners.HasFlag(RectangleCorners.BottomRight))
                path.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            else
            {
                path.AddLine(xw, yhr, xw, yh);
                path.AddLine(xw, yh, xwr, yh);
            }

            //draw bottom line
            path.AddLine(xwr, yh, xr, yh);

            //draw bottom left corner
            if (corners.HasFlag(RectangleCorners.BottomLeft))
                path.AddArc(layout.X, yhr2, r2, r2, 90, 90);
            else
            {
                path.AddLine(xr, yh, layout.X, yh);
                path.AddLine(layout.X, yh, layout.X, yhr);
            }

            //draw left line
            path.AddLine(layout.X, yhr, layout.X, yr);

            //complete figure
            path.CloseFigure();
        }
    }
}
