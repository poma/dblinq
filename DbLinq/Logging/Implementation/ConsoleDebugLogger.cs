﻿#region MIT license
////////////////////////////////////////////////////////////////////
// MIT license:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//
// Authors:
//        Jiri George Moudry
////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Diagnostics;

namespace DbLinq.Logging.Implementation
{
    class ConsoleDebugLogger : Logger
    {
        public override void Write(Level level, string text)
        {
            switch (level)
            {
            case Level.Debug:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case Level.Information:
                Console.ResetColor();
                break;
            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            default:
                throw new ArgumentOutOfRangeException("level");
            }
            Console.WriteLine(text);
            Debug.WriteLine(string.Format("{0:u} {1}", DateTime.Now, text));
        }
    }
}
