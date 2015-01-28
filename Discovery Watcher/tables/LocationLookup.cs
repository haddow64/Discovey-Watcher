using System;
using System.Data;
using System.IO;
using System.Reflection;
namespace DSW.tables
{
    class LocationLookup
    {
        private readonly DataSet.LocationLookupDataTable _table = new DataSet.LocationLookupDataTable();
        public LocationLookup()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +"\\lookloc.xml"))
            {
                _table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
            }
            _table.RowChanged += TableChanged;
            _table.TableNewRow += _table_TableNewRow;
            _table.RowDeleted += TableChanged;
        }

        void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\lookloc.xml");
        }

        /// <summary>
        /// Check if the player matches any entry in system search list.
        /// </summary>
        /// <param name="name">Player name, can be blank.</param>
        /// <param name="location">Current location</param>
        /// <returns>Boolean: true if the player matches criteria.</returns>
        public bool Check(string name,string location)
        {
            location = StringUtils.EscapeLikeValue(location);

                foreach (DataRow row in _table.Rows)
                {
                    if ((row[0].ToString() == "") | (DBNull.Value.Equals(row[0])))
                    {
                        if ((StringUtils.TrimDown(location).IndexOf(StringUtils.TrimDown((string)row[1]), StringComparison.Ordinal) != -1) & (row[1].ToString().Trim() != ""))
                        {
                        return true;
                        }
                    } 
                    else
                    {
                        if ((StringUtils.TrimDown(name).IndexOf(StringUtils.TrimDown((string)row[0]), StringComparison.Ordinal) != -1) & (StringUtils.TrimDown(location).IndexOf(StringUtils.TrimDown((string)row[1]), StringComparison.Ordinal) != -1) & (row[1].ToString().Trim() != ""))
                        {
                        return true;
                        }
                    }
                }
            return false;
        }

        public DataSet.LocationLookupDataTable Table
        {
            get { return _table; }
        }
    }
}