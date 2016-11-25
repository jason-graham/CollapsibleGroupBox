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
//  08/29/13    Added FlagsAttribute, comments.
//
//---------------------------------------------------------------------------

namespace System.Drawing.Drawing2D
{
    /// <summary>
    /// Specifies rectangle corners.
    /// </summary>
    [Flags]
    public enum RectangleCorners
    {
        /// <summary>
        /// No corners.
        /// </summary>
        None = 0,
        /// <summary>
        /// The top left corner.
        /// </summary>
        TopLeft = 1,
        /// <summary>
        /// The top right corner.
        /// </summary>
        TopRight = 2,
        /// <summary>
        /// The bottom left corner.
        /// </summary>
        BottomLeft = 4,
        /// <summary>
        /// The bottom right corner.
        /// </summary>
        BottomRight = 8,
        /// <summary>
        /// All corners.
        /// </summary>
        All = TopLeft | TopRight | BottomLeft | BottomRight
    }
}
