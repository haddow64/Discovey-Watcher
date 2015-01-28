using System;
using System.Timers;
using DSW.Properties;
using DSW.tables;

namespace DSW
{
    static class Updater
    {
        static private readonly PlayerList Pll;
        private static readonly Tags Tag = new Tags();
        private static readonly PlayerLookup LookupPl = new PlayerLookup();
        private static readonly LocationLookup LookupLo = new LocationLookup();
        private static Base _base;
        private static readonly Timer Timer = new Timer();
        static Updater()
        {
            Pll = new PlayerList("http://discoverygc.com/forums/serverinterface.php?action=players_online");

            Timer.Elapsed += _timer_Tick;
            Timer.Interval = Settings.Default.RefInterval;
            Timer.Enabled = true;
            Timer.Start();
        }

        static void _timer_Tick(object sender, EventArgs e)
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
            Pll.Tick(false);
            if (_base != null)
            {
                _base.Tick();
            }
        }

        public static void RescanPlayers()
        {
            Pll.Tick(true);
            
        }




        public static DataSet.PlayersDataTable Table
        {
            get { return Pll.Table; }
        }

        public static Tags Tags
        {
            get { return Tag; }
        }

        public static PlayerLookup PlayerWatch
        {
            
            get { return LookupPl; }
        }

        public static LocationLookup LocationWatch
        {

            get { return LookupLo; }
        }

        public static bool CheckPlayer(string name)
        {
            return LookupPl.Check(name);
        }

        public static bool CheckLoc(string name,string location)
        {
            return LookupLo.Check(name,location);
        }

        public static Base Base
        {
            get
            {
                if (_base == null)
                {
                    _base = new Base("http://discoverygc.com/forums/serverinterface.php?action=base_status");
                }
                return _base;
            }
        }

        public static PlayerList Online
        {
            get { return Pll; }
        }

    }
}
