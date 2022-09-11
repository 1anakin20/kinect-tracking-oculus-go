using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Tracking;
using UnityEngine;

namespace Network
{
    public class KinectTransmissionProtocolReceiver
    {
        private readonly int _port;
        private Thread _listenThread;
        private UdpClient _listenClient;
        public Player LastPlayer { get; internal set; }
        public event EventHandler<PlayerDataArrivedArgs> PlayerDataArrived;

        public KinectTransmissionProtocolReceiver(int port)
        {
            _port = port;
            _listenThread = new Thread(new ThreadStart(SimplestReceiver));
            _listenThread.Start();
        }

        private void SimplestReceiver()
        {
            IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, _port);
            _listenClient = new UdpClient(listenEndPoint);

            while (true)
            {
                try
                {
                    var data = _listenClient.Receive(ref listenEndPoint);
                    var skeletonData = Encoding.ASCII.GetString(data);
                    var player = Decoder.GetPlayer(skeletonData);
                    // OnPlayerDataArrived(new PlayerDataArrivedArgs(player));
                    LastPlayer = player;
                }
                catch (SocketException ex)
                {
                    if (ex.ErrorCode != 10060)
                        Debug.Log("a more serious error " + ex.ErrorCode);
                    else
                        Debug.Log("expected timeout error");
                }
            }
        }

        protected virtual void OnPlayerDataArrived(PlayerDataArrivedArgs e)
        {
            PlayerDataArrived?.Invoke(this, e);
        }
    }
}
