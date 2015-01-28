﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using DSW.popup;
using HtmlAgilityPack;
namespace DSW
{
    class PlayerList
    {
        private readonly string _uri;
        private List<List<string>> _list;
        private DataSet.PlayersDataTable _table = new DataSet.PlayersDataTable();

        public delegate void TickHandler(PlayerList m, EventArgs e);
        public event TickHandler Refreshed;
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        public PlayerList(string playeruri)
        {
            _uri = playeruri;
            _bw.DoWork += _bw_DoWork;
            _bw.RunWorkerCompleted += _bw_RunWorkerCompleted;
        }

        void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                Notifier.Pop("Can't reach the player list!");
                return;
            }

            _table = (DataSet.PlayersDataTable) e.Result;

            if (Refreshed != null)
            {
                Refreshed(this, e);
            }
        }

        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {

            var web = new HtmlWeb();
            HtmlDocument doc;
            //HAP
            try
            {
                doc = web.Load(_uri);
            }
            catch
            {
                e.Cancel = true;
                return;
            }
            

            if ((web.StatusCode != HttpStatusCode.OK) | (doc.DocumentNode.InnerHtml.Contains("List unavailable")) | (doc.DocumentNode.InnerHtml.Contains("The maximum server load limit has been reached")))
            {
                e.Cancel = true;
                return;
            }

            _list = doc.DocumentNode.SelectSingleNode("//table[@class='tborder']")
            .Descendants("tr")
            .Skip(2)
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
            .ToList();

            //remove table header - done with skip(2)
            //_list.RemoveAt(0);
            var temptable = new DataSet.PlayersDataTable();

            foreach (var lrow in _list)
            {
                DataRow crow = _table.Rows.Find(lrow[0]);

                lrow.Insert(1, Updater.Tags.GetTag(lrow[0]));
                lrow.Add("New");

                lrow[0] = lrow[0].Replace("&#60;", "<").Replace("&#62;",">");

                lrow[6] = SetRowAttr(crow, lrow);
                lrow[6] = ScanRow(lrow);

                // ReSharper disable CoVariantArrayConversion
                temptable.Rows.Add(lrow.ToArray());
                // ReSharper restore CoVariantArrayConversion


            }

            e.Result = temptable;
            //GetList ends
        }

        public void Tick(bool isPurge)
        {
            if (isPurge)
            {
                RescanPlayers();
            }
            else
            {
                if (!_bw.IsBusy)
                {
                    _bw.RunWorkerAsync();
                }
                
            }
            
        }


        private void RescanPlayers()
        {
            foreach (DataRow row in _table.Rows)
            {
                bool doNotif = false;
                if (Updater.CheckPlayer((string) row[0]))
                {
                    if ((string) row[6] != "FoundPlayer")
                    {
                        row[6] = "FoundPlayer";
                        doNotif = true;
                    }
                } else
                {
                    if ((string) row[6] == "FoundPlayer")
                    {
                        row[6] = "New";
                    }
                }

                if (Updater.CheckLoc((string)row[0], (string)row[2]))
                {
                    if ((string)row[6] != "FoundLocation")
                    {
                        row[6] = "FoundLocation";
                        doNotif = true;
                    }
                }
                else
                {
                    if ((string)row[6] == "FoundLocation")
                    {
                        row[6] = "New";
                    }
                }

                if (doNotif)
                {
                    Notifier.Pop(string.Format("Found {0} in {1}", row[0], row[2]));
                }

            }
        }

        private string SetRowAttr(DataRow crow,List<string> lrow)
        {
            if (crow != null)
            {
                if (crow[2].ToString() != lrow[2])
                {
                    lrow[6] = "Moved";
                }
                else
                {
                    lrow[6] = "Unchanged";
                }
                if ((crow[6].ToString() == "FoundPlayer") | (crow[6].ToString() == "FoundLocation"))
                {
                    lrow[6] = crow[6].ToString();
                }
            }

            return lrow[6];
        }

        private string ScanRow(List<string> lrow)
        {
            bool doNotif = false;
            if (lrow[6] == "New")
            {
                if (Updater.CheckPlayer(lrow[0]))
                {
                    lrow[6] = "FoundPlayer";
                    doNotif = true;
                    
                }

                if (Updater.CheckLoc(lrow[0], lrow[2]))
                {
                    lrow[6] = "FoundLocation";
                    doNotif = true;
                }

            }

            if (lrow[6] == "Moved")
            {
                if (Updater.CheckLoc(lrow[0], lrow[2]))
                {
                    lrow[6] = "FoundLocation";
                    doNotif = true;
                }
            }

            if (doNotif)
            {
                Notifier.Pop(string.Format("Found {0} in {1}", lrow[0], lrow[2]));
            }

            return lrow[6];
        } 


        public DataSet.PlayersDataTable Table
        {
            get { return _table; }
        }

        public string GetSystem(string sys)
        {
            var rows = _table.Select("System like '%{0}%'");
            if (!rows.Any())
            {
                return "nobody";
            }

            return rows.Aggregate("", (current, row) => current + string.Format("{0}, ", row[0]));
        }

    }
}
