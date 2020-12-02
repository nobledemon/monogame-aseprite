﻿/* ------------------------------------------------------------------------------
    Copyright (c) 2020 Christopher Whitley

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:
    
    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
------------------------------------------------------------------------------ */

using Microsoft.Xna.Framework;

namespace MonoGame.Aseprite
{
    /// <summary>
    ///     Represents the definition of a frame
    /// </summary>
    public struct Frame
    {
        /// <summary>
        ///     Defines the area within the spritesheet that the frame is in
        /// </summary>
        public Rectangle frame;

        /// <summary>
        ///     The amount of time in secondss the frame should be displayed
        /// </summary>
        public float duration;

        /// <summary>
        ///     Creates a new <see cref="Frame"/> structure
        /// </summary>
        /// <param name="x">The x-coordinate position of the frame</param>
        /// <param name="y">The y-coordinate position of the frame</param>
        /// <param name="width">The width of the frame</param>
        /// <param name="height">The height of the frame</param>
        /// <param name="duration">The amount of time in seconds the frame should be displayed</param>
        public Frame(int x, int y, int width, int height, float duration)
        {
            this.frame = new Rectangle(x, y, width, height);
            this.duration = duration;
        }

        /// <summary>
        ///     Creates a new <see cref="Frame"/> structure
        /// </summary>
        /// <param name="frame">The <see cref="Rectangle"/> definition of the frame, defining the xy-coordinate and the width and height</param>
        /// <param name="duration">The amount of time in seconds the frame should be displayed</param>
        public Frame(Rectangle frame, float duration)
        {
            this.frame = frame;
            this.duration = duration;
        }
    }
}
