// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace Snippets
{
    public class Program
    {
        static async Task Main(
            string region = null,
            string session = null,
            string package = null,
            string project = null,
            string[] args = null)
        {    
#region Main
            switch (region)
            {
                case "pattern-complex":
                    Patterns.Complex();
                    break;
                case "pattern-simple":
                    Patterns.Simple();
                    break;
                case "async-stream":
                default:
                    await AsyncStreams.RunAsync();
                    break;
            }
        }
#endregion
    }
}