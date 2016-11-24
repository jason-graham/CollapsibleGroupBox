//---------------------------------------------------------------------------- 
//
//  Copyright (C) CSharp Labs.  All rights reserved.
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
// History
//  08/29/13    Created
//
//---------------------------------------------------------------------------

namespace System.Drawing
{
    using System.Windows.Forms;

    public static class PointExtensions
    {
        /// <summary>
        /// Constrains a <see cref="System.Drawing.Point"/> to a maximum size.
        /// </summary>
        /// <param name="value">The <see cref="System.Drawing.Point"/> value.</param>
        /// <param name="max">The maximum boundary.</param>
        /// <returns>A <see cref="System.Drawing.Point"/> that is less-than or equal to <paramref name="max"/>.</returns>
        public static Point Max(this Point value, Point max)
        {
            if (value.X > max.X)
                value.X = max.X;

            if (value.Y > max.Y)
                value.Y = max.Y;

            return value;
        }

        /// <summary>
        /// Constrains a point into a specified rectangle.
        /// </summary>
        /// <param name="p">The point to constrain.</param>
        /// <param name="bounds">The rectangle bounds.</param>
        /// <returns>A point constrained inside the bounds.</returns>
        public static Point Constrain(this Point p, Rectangle bounds)
        {
            bounds = bounds.Normalize();

            if (p.X < bounds.Left)
                p.X = bounds.Left;

            if (p.Y < bounds.Top)
                p.Y = bounds.Top;

            if (p.X > bounds.Right)
                p.X = bounds.Right;

            if (p.Y > bounds.Bottom)
                p.Y = bounds.Bottom;

            return p;
        }

        /// <summary>
        /// Moves a <see cref="System.Drawing.Point"/> by 
        /// adding horizontal and vertical offsets.
        /// </summary>
        /// <param name="p">The <see cref="System.Drawing.Point"/> to reposition.</param>
        /// <param name="x">The horizontal offset.</param>
        /// <param name="y">The vertical offset.</param>
        /// <returns>A new <see cref="System.Drawing.Point"/> offset by the specified values.</returns>
        public static Point Move(this Point p, int x, int y)
        {
            return new Point(p.X + x, p.Y + y);
        }

        /// <summary>
        /// Creates a <see cref="System.Drawing.Rectangle"/> centered at the specified location.
        /// </summary>
        /// <param name="p">The center location.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>A centered <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Rectangle CreateCenteredRectangle(this Point p, int width, int height)
        {
            return new Rectangle(p.X - (width / 2), p.Y - (height / 2), width, height);
        }

        /// <summary>
        /// Creates a <see cref="System.Drawing.Rectangle"/> centered at the specified location.
        /// </summary>
        /// <param name="p">The center location.</param>
        /// <param name="sz">The size.</param>
        /// <returns>A centered <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Rectangle CreateCenteredRectangle(this Point p, Size sz)
        {
            return p.CreateCenteredRectangle(sz.Width, sz.Height);
        }

        /// <summary>
        /// Converts the specified <see cref="System.Drawing.Point"/> 
        /// to a screen <see cref="System.Drawing.Point"/>.
        /// </summary>
        /// <param name="p">The <see cref="System.Drawing.Point"/> to convert.</param>
        /// <returns>A <see cref="System.Drawing.Point"/> offset by the screen location.</returns>
        public static Point ToScreenPoint(this Point p)
        {
            if (SystemInformation.VirtualScreen.X < 0)
                p.X += SystemInformation.VirtualScreen.X;
            if (SystemInformation.VirtualScreen.Y < 0)
                p.Y += SystemInformation.VirtualScreen.Y;

            return p;
        }

        /// <summary>
        /// Converts the specified <see cref="System.Drawing.Point"/> 
        /// from a screen <see cref="System.Drawing.Point"/>.
        /// </summary>
        /// <param name="p">The <see cref="System.Drawing.Point"/> to convert.</param>
        /// <returns>A <see cref="System.Drawing.Point"/> that is no longer 
        /// offset by the screen point.</returns>
        public static Point FromScreenPoint(this Point p)
        {
            if (SystemInformation.VirtualScreen.X < 0)
                p.X -= SystemInformation.VirtualScreen.X;
            if (SystemInformation.VirtualScreen.Y < 0)
                p.Y -= SystemInformation.VirtualScreen.Y;

            return p;
        }

        /// <summary>
        /// Adds the specified <see cref="System.Drawing.Point"/>s together.
        /// </summary>
        /// <param name="p">The first <see cref="System.Drawing.Point"/>.</param>
        /// <param name="p2">The second<see cref="System.Drawing.Point"/>.</param>
        /// <returns>The sum of both <see cref="System.Drawing.Point"/>s.</returns>
        public static Point Add(this Point p, Point p2)
        {
            return new Point(p.X + p2.X, p.Y + p2.Y);
        }

        /// <summary>
        /// Subtracts a <see cref="System.Drawing.Point"/> from another.
        /// </summary>
        /// <param name="minuend">The minuend <see cref="System.Drawing.Point"/> value.</param>
        /// <param name="subtrahend">The subtrahend <see cref="System.Drawing.Point"/> value.</param>
        /// <returns>The first <see cref="System.Drawing.Point"/> minus the second <see cref="System.Drawing.Point"/>.</returns>
        public static Point Subtract(this Point minuend, Point subtrahend)
        {
            return new Point(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);
        }
    }
}