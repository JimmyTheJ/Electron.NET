﻿using Quobject.SocketIoClientDotNet.Client;
using System;

namespace ElectronNET.API
{
    internal static class BridgeConnector
    {
        private static Socket _socket;
        private static object _syncRoot = new Object();

        public static Socket Socket
        {
            get
            {
                if(_socket == null && HybridSupport.IsElectronActive)
                {
                    lock (_syncRoot)
                    {
                        if (_socket == null && HybridSupport.IsElectronActive)
                        {
                            _socket = IO.Socket(BridgeSettings.Protocol + "://localhost:" + BridgeSettings.SocketPort);
                            _socket.On(Socket.EVENT_CONNECT, () =>
                            {
                                Console.WriteLine("BridgeConnector connected!");
                            });
                        }
                    }
                }
                else if(_socket == null && !HybridSupport.IsElectronActive)
                {
                    lock (_syncRoot)
                    {
                        if (_socket == null && !HybridSupport.IsElectronActive)
                        {
                            _socket = IO.Socket(new Uri(BridgeSettings.Protocol + "://localhost"), new IO.Options { AutoConnect = false });
                        }
                    }
                }

                return _socket;
            }
        }
    }
}
