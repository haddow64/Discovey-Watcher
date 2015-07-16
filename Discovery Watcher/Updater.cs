using System;
using System.Timers;
using DSW.Properties;
using DSW.tables;

namespace DSW
{
    internal static class Updater
    {
        //private static Base _base;
        private static readonly Timer Timer = new Timer();

        static Updater()
        {
            Online = new PlayerList("http://discoverygc.com/forums/serverinterface.php?action=players_online");

            Timer.Elapsed += _timer_Tick;
            Timer.Interval = Settings.Default.RefInterval;
            Timer.Enabled = true;
            Timer.Start();
        }

        public static DataSet.PlayersDataTable Table => Online.Table;
        public static Tags Tags { get; } = new Tags();
        public static PlayerLookup PlayerWatch { get; } = new PlayerLookup();
        public static LocationLookup LocationWatch { get; } = new LocationLookup();

        //public static Base Base
        //    => _base ?? (_base = new Base("http://discoverygc.com/forums/serverinterface.php?action=base_status"));

        public static PlayerList Online { get; }

        private static void _timer_Tick(object sender, EventArgs e)
        {
            Tick();
        }

        public static void SetInterval()
        {
            Timer.Stop();
            Timer.Interval = Settings.Default.RefInterval;
            Timer.Start();
        }

        public static void Tick()
        {
            Online.Tick(false);
            //_base?.Tick();
        }

        public static void RescanPlayers()
        {
            Online.Tick(true);
        }

        public static bool CheckPlayer(string name)
        {
            return PlayerWatch.Check(name);
        }

        public static bool CheckLoc(string name, string location)
        {
            return LocationWatch.Check(name, location);
        }
    }
}