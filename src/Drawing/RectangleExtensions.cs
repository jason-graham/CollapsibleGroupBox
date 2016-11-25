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
// History
//  08/29/13    Created
//
//---------------------------------------------------------------------------

namespace System.Drawing
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Determines if a <see cref="System.Drawing.Rectangle"/> overlaps another.
        /// </summary>
        /// <param name="rec">A rectangle.</param>
        /// <param name="other">Another rectangle.</param>
        /// <returns>true if the rectangles overlap; otherwise false.</returns>
        public static bool Overlaps(this Rectangle rec, Rectangle other)
        {
            return !(rec.Left > other.Right || other.Left > rec.Right || rec.Top > other.Bottom || other.Top > rec.Bottom);
        }

        /// <summary>
        /// Converts the specified <see cref="System.Drawing.Rectangle"/> location to a screen point.
        /// </summary>
        /// <param name="rec">The rectangle to convert to.</param>
        /// <returns>A rectangle offset by the screen location.</returns>
        public static Rectangle ToScreenPoint(this Rectangle rec)
        {
            return new Rectangle(rec.Location.ToScreenPoint(), rec.Size);
        }

        /// <summary>
        /// Converts the specified <see cref="System.Drawing.Rectangle"/> from a screen point.
        /// </summary>
        /// <param name="rec">The rectangle to convert.</param>
        /// <returns>A rectangle that is no longer offset by the screen point.</returns>
        public static Rectangle FromScreenPoint(this Rectangle rec)
        {
            return new Rectangle(rec.Location.FromScreenPoint(), rec.Size);
        }

        /// <summary>
        /// Constrains a <see cref="System.Drawing.Rectangle"/> inside a maximum boundary.
        /// </summary>
        /// <param name="rec">The rectangle to constrain.</param>
        /// <param name="maxbounds">The maximum boundary.</param>
        /// <returns>A rectangle that fits inside the maximum rectangle.</returns>
        public static Rectangle Constrain(this Rectangle rec, Rectangle maxbounds)
        {
            rec = rec.Normalize();
            maxbounds = maxbounds.Normalize();

            if (rec.X < maxbounds.X)
            {
                int new_w = rec.Width - (maxbounds.X - rec.X);
                if (new_w < 0)
                    new_w = 0;

                rec.Width = new_w;
                rec.X = maxbounds.X;
            }

            if (rec.Y < maxbounds.Y)
            {
                int new_h = rec.Height - (maxbounds.Y - rec.Y);
                if (new_h < 0)
                    new_h = 0;

                rec.Height = new_h;
                rec.Y = maxbounds.Y;
            }

            if (rec.X > maxbounds.Right)
                rec.X = maxbounds.Right;
            if (rec.Y > maxbounds.Bottom)
                rec.Y = maxbounds.Bottom;

            if (rec.Right > maxbounds.Right)
                rec.Width = maxbounds.Right - rec.X;
            if (rec.Bottom > maxbounds.Bottom)
                rec.Height = maxbounds.Bottom - rec.Y;

            return rec;
        }

        /// <summary>
        /// Determines if the specified <see cref="System.Drawing.Rectangle"/> has a size with both the Width and Height greater than 0.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to check.</param>
        /// <returns>true if the both the width and height are greater than 0; otherwise, false.</returns>
        public static bool HasSize(this Rectangle rec)
        {
            return rec.Size.HasSize();
        }

        /// <summary>
        /// Resizes a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to resize.</param>
        /// <param name="width_offset">A value to offset the width by.</param>
        /// <param name="height_offset">A value to offset the height by.</param>
        /// <returns>A new <see cref="System.Drawing.Rectangle"/> structure with it's width and height changed by the specified values.</returns>
        public static Rectangle Resize(this Rectangle rec, int width_offset, int height_offset)
        {
            return new Rectangle(rec.Location, new Size(rec.Width + width_offset, rec.Height + height_offset));
        }

        /// <summary>
        /// Repositions a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to move.</param>
        /// <param name="xOffset">A value to offset the x coordinate.</param>
        /// <param name="yOffset">A value to offset the y coordinate.</param>
        /// <returns>A new <see cref="System.Drawing.Rectangle"/> structure with it's position changed by the specified values.</returns>
        public static Rectangle Move(this Rectangle rec, int xOffset, int yOffset)
        {
            return new Rectangle(rec.Location.Move(xOffset, yOffset), rec.Size);
        }

        /// <summary>
        /// Resizes a <see cref="System.Drawing.Rectangle"/> from the center by moving in each direction.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to resize.</param>
        /// <param name="sz">A <see cref="System.Drawing.Size"/> structure to offset the x and y coordinates from.</param>
        /// <returns>A new <see cref="System.Drawing.Rectangle"/> structure with it's width and height changed by the 
        /// specified values and centered relative to the original position.</returns>
        public static Rectangle ResizeFromCenter(this Rectangle rec, Size sz)
        {
            return rec.ResizeFromCenter(sz.Width, sz.Height);
        }

        /// <summary>
        /// Resizes a <see cref="System.Drawing.Rectangle"/> from the center by moving in each direction.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to resize.</param>
        /// <param name="width_offset">A value to offset the width by.</param>
        /// <param name="height_offset">A value to offset the height by.</param>
        /// <returns>A new <see cref="System.Drawing.Rectangle"/> structure with it's width and height changed by the 
        /// specified values and centered relative to the original position.</returns>
        public static Rectangle ResizeFromCenter(this Rectangle rec, int width_offset, int height_offset)
        {
            return new Rectangle(rec.X - (width_offset / 2), rec.Y - (height_offset / 2), rec.Width + width_offset, rec.Height + height_offset);
        }

        /// <summary>
        /// Calculates the center.
        /// </summary>
        /// <param name="rec">A <see cref="System.Drawing.Rectangle"/>.</param>
        /// <returns>The center point of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point Center(this Rectangle rec)
        {
            return new Point(rec.X + (rec.Width / 2), rec.Y + (rec.Height / 2));
        }

        /// <summary>
        /// Calculates the horizontal center.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the horizontal center of.</param>
        /// <returns>The horizontal center of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static int HorizontalCenter(this Rectangle rec)
        {
            return rec.X + (rec.Width / 2);
        }

        /// <summary>
        /// Calculates the vertical center.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the vertical center of.</param>
        /// <returns>The vertical center of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static int VerticalCenter(this Rectangle rec)
        {
            return rec.Y + (rec.Height / 2);
        }

        /// <summary>
        /// Returns the bottom left of a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the bottom left of.</param>
        /// <returns>The bottom left of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point BottomLeft(this Rectangle rec)
        {
            return new Point(rec.X, rec.Y + rec.Height);
        }

        /// <summary>
        /// Returns the bottom right of a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the bottom right of.</param>
        /// <returns>The bottom right of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point BottomRight(this Rectangle rec)
        {
            return new Point(rec.Right, rec.Bottom);
        }

        /// <summary>
        /// Returns the bottom center of a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the bottom center of.</param>
        /// <returns>The bottom center of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point BottomCenter(this Rectangle rec)
        {
            return new Point(rec.X + (rec.Width / 2), rec.Y + rec.Height);
        }

        /// <summary>
        /// Returns the top right of a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the top right of.</param>
        /// <returns>The top right of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point TopRight(this Rectangle rec)
        {
            return new Point(rec.Right, rec.Top);
        }

        /// <summary>
        /// Returns the top left corner of a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to calculate the top left of.</param>
        /// <returns>The top left of a <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Point TopLeft(this Rectangle rec)
        {
            return new Point(rec.Left, rec.Top);
        }

        /// <summary>
        /// Scales the specified size to fit inside the specified bounds.
        /// </summary>
        /// <param name="sz">A <see cref="System.Drawing.Size"/> to fit inside the bounds.</param>
        /// <param name="bounds">The maximum <see cref="System.Drawing.Rectangle"/> bounds for the size to fit in.</param>
        /// <returns>The scaled <see cref="System.Drawing.Size"/> in the specified <see cref="System.Drawing.Rectangle"/>.</returns>
        public static Rectangle ScaleCenter(this Size sz, Rectangle bounds)
        {
            if (sz.Width > bounds.Width)
            {
                float scale = (float)bounds.Width / (float)sz.Width;
                sz = new Size(bounds.Width, (int)(sz.Height * scale));
            }

            if (sz.Height > bounds.Height)
            {
                float scale = (float)bounds.Height / (float)sz.Height;
                sz = new Size((int)(sz.Width * scale), bounds.Height);
            }

            Rectangle rec = new Rectangle(Point.Empty, sz);

            rec.X = bounds.X + (bounds.Width / 2) - (sz.Width / 2);
            rec.Y = bounds.Y + (bounds.Height / 2) - (sz.Height / 2);

            return rec;
        }

        /// <summary>
        /// Determines if the specified <see cref="System.Drawing.Point"/> intersects or is contained by the <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> the <see cref="System.Drawing.Point"/> should be tested against.</param>
        /// <param name="p">The <see cref="System.Drawing.Point"/> to test against the <see cref="System.Drawing.Rectangle"/>.</param>
        /// <returns>true if the <see cref="System.Drawing.Point"/> intersects or is contained by the <see cref="System.Drawing.Rectangle"/>; otherwise false.</returns>
        public static bool IntersectsOrContains(this Rectangle rec, Point p)
        {
            return rec.X <= p.X && rec.X + rec.Width >= p.X && rec.Y <= p.Y && rec.Y + rec.Height >= p.Y;
        }

        /// <summary>
        /// Normalizes a <see cref="System.Drawing.Rectangle"/>, -width and/or -height is negated and x/y offsets updated.
        /// </summary>
        /// <param name="rec">The <see cref="System.Drawing.Rectangle"/> to normalize.</param>
        /// <returns>A <see cref="System.Drawing.Rectangle"/> without a negative width or height but at the same location with the same area.</returns>
        public static Rectangle Normalize(this Rectangle rec)
        {
            Rectangle recFixed = rec;

            if (recFixed.Width < 0)
            {
                recFixed.X += recFixed.Width;
                recFixed.Width *= -1;
            }

            if (recFixed.Height < 0)
            {
                recFixed.Y += recFixed.Height;
                recFixed.Height *= -1;
            }

            return recFixed;
        }
    }
}