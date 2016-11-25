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
    public static class SizeExtensions
    {
        /// <summary>
        /// Restricts a value to be less-than the specified maximum. 
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The constrained value.</returns>
        public static Size Max(this Size value, Size max)
        {
            if (value.Width > max.Width)
                value.Width = max.Width;

            if (value.Height > max.Height)
                value.Height = max.Height;

            return value;
        }

        /// <summary>
        /// Restricts a value to be within a specified range. 
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static Size Clamp(this Size value, Size min, Size max)
        {
            if (value.Width < min.Width)
                value.Width = min.Width;

            if (value.Width > max.Width)
                value.Width = max.Width;

            if (value.Height < min.Height)
                value.Height = min.Height;

            if (value.Height > max.Height)
                value.Height = max.Height;

            return value;
        }

        /// <summary>
        /// Determines if the specified size has a valid size with both the Width and Height greater than 0.
        /// </summary>
        /// <param name="value">The size to check.</param>
        /// <returns>true if the both the width and height are greater than 0.</returns>
        public static bool HasSize(this Size value)
        {
            return value.Width != 0 && value.Height != 0;
        }

        /// <summary>
        /// Scales a size by using the specified maximum width and height.
        /// </summary>
        /// <param name="value">The size to scale.</param>
        /// <param name="max">The maximum size.</param>
        /// <returns>A new size which is equal to or less then the specified maximum size.</returns>
        public static Size MaxScale(this Size value, Size max)
        {
            if (value.Width > max.Width)
            {
                value.Height = (int)((float)max.Width / value.Width * value.Height);
                value.Width = max.Width;
            }

            if (value.Height > max.Height)
            {
                value.Width = (int)((float)max.Height / value.Height * value.Width);
                value.Height = max.Height;
            }

            return value;
        }

        /// <summary>
        /// Scales the specified value.
        /// </summary>
        /// <param name="value">The value to scale</param>
        /// <param name="scale">The factor to scale the value by.</param>
        /// <returns>The scaled value.</returns>
        public static Size CeilingScale(this Size value, float scale)
        {
            return new Size((int)Math.Ceiling(value.Width * scale), (int)(Math.Ceiling(value.Height * scale)));
        }
    }
}
