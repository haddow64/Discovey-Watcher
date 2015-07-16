using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DSW.tables
{
    internal class PlayerLookup
    {
        public PlayerLookup()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml"))
            {
                Table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
            }
            Table.RowChanged += TableChanged;
            Table.TableNewRow += _table_TableNewRow;
            Table.RowDeleted += TableChanged;
        }

        public DataSet.PlayerLookupDataTable Table { get; } = new DataSet.PlayerLookupDataTable();

        private void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookplayers.xml");
        }

        /// <summary>
        ///     Check if the player matches any entry in search list.
        /// </summary>
        /// <param name="name">Name of player to check.</param>
        /// <returns>Boolean: if player triggered any entry.</returns>
        public bool Check(string name)
        {
            return
                Table.Rows.Cast<DataRow>()
                    .Any(
                        row =>
                            (StringUtils.TrimDown(name)
                                .IndexOf(StringUtils.TrimDown((string) row[0]), StringComparison.Ordinal) != -1) &
                            (row[0].ToString().Trim() != ""));
        }
    }
}