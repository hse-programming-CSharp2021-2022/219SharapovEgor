using System;
using System.Data;
using System.Text;
using Microsoft.Data.Sqlite;


namespace Task01
{
    public class Tools
    {
        public static int GenerateProductId()
        {
            var productIdString = new StringBuilder();
            for (var i = 0; i < 5; i++)
                productIdString.Append((char) new Random().Next(48, 58));
            int.TryParse(productIdString.ToString(), out var resultProductId);
            return resultProductId;
        }

        public static string GenerateGuidNumber()
        {
            var guid = new StringBuilder();
            for (var i = 0; i < 5; i++) 
                guid.Append((char) new Random().Next(97, 123));
            return guid.ToString();
        }
        
        public static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            var dt = new DataTable();
            using var con = new SqliteConnection(connectionString);
            using var cmd = new SqliteCommand(SQL, con);
            cmd.CommandType = CommandType.Text;
            foreach (var tuple in parameters)
                cmd.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));
            con.Open();
            var reader = cmd.ExecuteReader();
            for (var i = 0; i < reader.FieldCount; i++)
                dt.Columns.Add(new DataColumn(reader.GetName(i)));
            var rowIndex = 0;
            while (reader.Read())
            {
                var row = dt.NewRow();
                dt.Rows.Add(row);
                for (var i = 0; i < reader.FieldCount; i++)
                    dt.Rows[rowIndex][i] = (reader.GetValue(i));
                rowIndex++;
            }
            return dt;
        }
    }
}