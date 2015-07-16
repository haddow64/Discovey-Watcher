using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace DSW.tables
{
    internal class LocationLookup
    {
        public LocationLookup()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml"))
            {
                Table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
            }
            Table.RowChanged += TableChanged;
            Table.TableNewRow += _table_TableNewRow;
            Table.RowDeleted += TableChanged;
        }

        public DataSet.LocationLookupDataTable Table { get; } = new DataSet.LocationLookupDataTable();

        private void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
        }

        /// <summary>
        ///     Check if the player matches any entry in system search list.
        /// </summary>
        /// <param name="name">Player name, can be blank.</param>
        /// <param name="location">Current location</param>
        /// <returns>Boolean: true if the player matches criteria.</returns>
        public bool Check(string name, string location)
        {
            location = StringUtils.EscapeLikeValue(location);

            foreach (DataRow row in Table.Rows)
            {
                if ((row[0].ToString() == "") | (DBNull.Value.Equals(row[0])))
                {
                    if (
                        (StringUtils.TrimDown(location)
                            .IndexOf(StringUtils.TrimDown((string) row[1]), StringComparison.Ordinal) != -1) &
                        (row[1].ToString().Trim() != ""))
                    {
                        return true;
                    }
                }
                else
                {
                    if (
                        (StringUtils.TrimDown(name)
                            .IndexOf(StringUtils.TrimDown((string) row[0]), StringComparison.Ordinal) != -1) &
                        (StringUtils.TrimDown(location)
                            .IndexOf(StringUtils.TrimDown((string) row[1]), StringComparison.Ordinal) != -1) &
                        (row[1].ToString().Trim() != ""))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}