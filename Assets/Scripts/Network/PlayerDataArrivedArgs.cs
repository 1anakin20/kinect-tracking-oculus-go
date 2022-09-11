using Tracking;

namespace Network
{
    public class PlayerDataArrivedArgs
    {
        public Player Player { get; }

        public PlayerDataArrivedArgs(Player player)
        {
            Player = player;
        }
    }
}
