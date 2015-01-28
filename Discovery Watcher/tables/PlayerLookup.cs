using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DSW.tables
{
    class PlayerLookup
    {
        private readonly DataSet.PlayerLookupDataTable _table = new DataSet.PlayerLookupDataTable();
        public PlayerLookup()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml"))
            {
                _table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
            }
            _table.RowChanged += TableChanged;
            _table.TableNewRow += _table_TableNewRow;
            _table.RowDeleted += TableChanged;
        }

        void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
        }

        /// <summary>
        /// Check if the player matches any entry in search list.
        /// </summary>
        /// <param name="name">Name of player to check.</param>
        /// <returns>Boolean: if player triggered any entry.</returns>
        public bool Check(string name)
        {
            return _table.Rows.Cast<DataRow>().Any(row => (StringUtils.TrimDown(name).IndexOf(StringUtils.TrimDown((string) row[0]), StringComparison.Ordinal) != -1) & (row[0].ToString().Trim() != ""));
        }

        public DataSet.PlayerLookupDataTable Table
        {
            get { return _table; }
        }
    }
}