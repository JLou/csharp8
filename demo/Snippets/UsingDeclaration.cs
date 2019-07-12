using System;

namespace Snippets
{
    static class AppliUsingSdp
    {
        public static void Reload()
        {
            #region using-new
            using var sdp = new SdpHelper("uno");
            Console.WriteLine(sdp.GetConfig());

            Console.WriteLine("fin");
            #endregion
        }

        public static void Start()
        {
            #region using-old
            using (var sdp = new SdpHelper("uno"))
            {
                Console.WriteLine(sdp.GetConfig());
            }
            Console.WriteLine("fin");
            #endregion
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