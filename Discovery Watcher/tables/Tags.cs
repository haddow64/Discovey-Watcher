using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace DSW.tables
{
    class Tags
    {
        private readonly DSW.DataSet.TagTableDataTable _table = new DSW.DataSet.TagTableDataTable();
        public Tags()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml"))
            {
                _table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
            }
            _table.RowChanged += TableChanged;
            _table.TableNewRow += _table_TableNewRow;
            _table.RowDeleted += TableChanged;
        }

        void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            _table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
        }

        public string GetTag(string tag)
        {
            foreach (DataRow row in _table.Rows)
            {
                if (tag.IndexOf((string)row[0], StringComparison.Ordinal) != -1)
                {
                    return (string)row[1];
                }
            }
            return "---";
        }

        public DSW.DataSet.TagTableDataTable Table
        {
            get { return _table; }
        }

    }
}
