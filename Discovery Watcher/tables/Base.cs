using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using DSW.popup;
using HtmlAgilityPack;

namespace DSW.tables
{
    class Base
    {
        private readonly string _uri;
        private List<List<string>> _list;
        private object[] _basenames;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        public delegate void TickHandler(Base m, EventArgs e);
        public event TickHandler Refreshed;
        public Base(string baseuri)
        {
            _uri = baseuri;
            _bw.DoWork += Bw_DoWork;
            _bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }

        void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Notifier.Pop("Can't reach the base list!");
                return;
            }
            var data = (object[]) e.Result;
            _list = (List<List<string>>)data[0];
            _basenames = (string[]) data[1];
            if (Refreshed != null)
            {
                Refreshed(this, e);
            }
        }

        void Bw_DoWork(object sender, DoWorkEventArgs e)
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
            .Select(tr => tr.Elements("td").Select(td => td.InnerHtml.Trim()).ToList())
            .ToList();
            _basenames = new string[_list.Count];
            foreach (var item in _list)
            {
                _basenames[Array.IndexOf(_basenames, null)] = item[0].Substring(19, item[0].IndexOf("&nbsp;&nbsp;", StringComparison.Ordinal)-19);
            }

            e.Result = new object[] {_list, _basenames};
        }


        /// <summary>
        /// Refreshes info if the worker is available.
        /// </summary>
        public void Tick()
        {
            if (!_bw.IsBusy)
            {
                _bw.RunWorkerAsync();
            }
        }


        public string[] GetStatus(int index)
        {
            if (index < _list.Count)
            {
                return _list[index].ToArray();
            }

            return new[] { "Unknown", "Base not found!"};

        }

        public object[] GetNames
        {
            get
            {
                if (_basenames == null)
                {
                    Tick();
                }
                return _basenames;
            }
        } 

    }
}
