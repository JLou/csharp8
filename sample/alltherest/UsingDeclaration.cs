using System;
using System.Collections.Generic;
using System.Text;

namespace alltherest
{

    static class AppliUsingSdp
    {
        static void Reload()
        {
            using var sdp = new SdpHelper("uno");
            Console.WriteLine(sdp.GetConfig());

            Console.WriteLine("fin");
        }

        static void Start()
        {
            using (var sdp = new SdpHelper("uno"))
            {
                Console.WriteLine(sdp.GetConfig());
            }
            Console.WriteLine("fin");
        }
    }

    public class SdpHelper : IDisposable
    {
        private readonly string _instanceName;

        public string GetConfig()
        {
            return "HASHTAG RESILIENCEEEEEEEEEEEEEEEEEEEE";
        }

        public SdpHelper(string instanceName)
        {
            _instanceName = instanceName;
            Console.WriteLine($"Starting {_instanceName}");
        }
        public void Dispose()
        {
            Console.WriteLine($"Disposing {_instanceName}");
        }
    }
}
