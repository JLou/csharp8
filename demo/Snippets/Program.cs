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
                    await AsyncStreams.RunAsync();
                    break;
                case "using-old":
                    AppliUsingSdp.Start();
                    break;
                case "using-new":
                    AppliUsingSdp.Reload();
                    break;
                case "local-static":
                    LocalStatic.ConvertStuff();
                    break;
                case "readonly-struct":
                    ReadonlyStruct.DescribePeople();
                    break;
                case "index-and-range":
                    IndexAndRanges.PullMyIndex();
                    break;
                case "nullable":
                    NullableRefType.Main();
                    break;
                default:
                    break;
            }
        }
#endregion
    }
}