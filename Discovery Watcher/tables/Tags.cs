using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DSW.tables
{
    internal class Tags
    {
        public Tags()
        {
            if (File.Exists(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml"))
            {
                Table.ReadXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
            }
            Table.RowChanged += TableChanged;
            Table.TableNewRow += _table_TableNewRow;
            Table.RowDeleted += TableChanged;
        }

        public DataSet.TagTableDataTable Table { get; } = new DataSet.TagTableDataTable();

        private void _table_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
        }

        private void TableChanged(object sender, DataRowChangeEventArgs e)
        {
            Table.WriteXml(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\tags.xml");
        }

        public string GetTag(string tag)
        {
            foreach (
                var row in
                    Table.Rows.Cast<DataRow>()
                        .Where(row => tag.IndexOf((string) row[0], StringComparison.Ordinal) != -1))
            {
                return (string) row[1];
            }
            return "---";
        }
    }
}