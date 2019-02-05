namespace ElectronNET.API
{
    /// <summary>
    /// 
    /// </summary>
    public static class BridgeSettings
    {
        private static string _Protocol;

        /// <summary>
        /// Gets the socket port.
        /// </summary>
        /// <value>
        /// The socket port.
        /// </value>
        public static string SocketPort { get; internal set; }

        /// <summary>
        /// Gets the web port.
        /// </summary>
        /// <value>
        /// The web port.
        /// </value>
        public static string WebPort { get; internal set; }

        /// <summary>
        /// Protocol used
        /// </summary>
        /// <value>
        /// HTTPS/HTTP
        /// </value>
        public static string Protocol 
        {
            get { return _Protocol; }
            internal set {
                var val = value.ToLower();
                if (val != "https" || val != "http")
                {
                    _Protocol = "http";
                }
            } 
        }
    }
}
