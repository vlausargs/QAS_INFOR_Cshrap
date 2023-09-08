using System;
using System.Data;
using System.Globalization;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Utilities
{
    public class DataTableUtil : IDataTableUtil
    {
        private readonly ISQLExpressionExecutor expressionExecutor;

        public DataTableUtil(ISQLExpressionExecutor expressionExecutor)
        {
            this.expressionExecutor = expressionExecutor;
        }

        public void CloneDataTableIntoDB(DataTable dataTable)
        {
            string tableName = dataTable.TableName;
            CreateDbTable(dataTable);
            string cmdText = string.Empty;
            string insertLineText = string.Empty;
            foreach (DataRow dr in dataTable.Rows)
            {
                string rowValueList = string.Empty;
                foreach (DataColumn dc in dataTable.Columns)
                {
                    string cellValue;
                    bool isCellNull = Convert.IsDBNull(dr[dc.ColumnName]);
                    if (isCellNull)
                    {
                        cellValue = "NULL";
                    }
                    else if (!isCellNull && "string-datetime".Contains(dc.DataType.Name.ToLower()))
                    {
                        cellValue = $"'{dr[dc.ColumnName].ToString()}'";
                    }
                    else
                    {
                        cellValue = $"{dr[dc.ColumnName].ToString()}";
                    }
                    rowValueList += $"{cellValue}, ";
                }
                rowValueList = rowValueList.TrimEnd(new char[] { ' ', ',' });
                insertLineText += $"INSERT INTO {tableName} VALUES({rowValueList})\r\n";
            }
            cmdText += insertLineText;
            if (!string.IsNullOrEmpty(cmdText.Trim()))
            {
                expressionExecutor.Execute(cmdText);
            }
        }

        private void CreateDbTable(DataTable dataTable)
        {
            string cmdText = $"IF OBJECT_ID('tempdb..{dataTable.TableName}') IS NOT NULL DROP TABLE {dataTable.TableName}\r\n";
            string columnList = string.Empty;

            foreach(DataColumn dc in dataTable.Columns)
            {
                string dbDataType = GetMappedDbDataType(dc.DataType.Name, dc.MaxLength);
                columnList += $"{dc.ColumnName} {dbDataType},\r\n";
            }

            columnList = columnList.TrimEnd(new char[] { ' ', ',', '\r', '\n' });
            if (!string.IsNullOrEmpty(columnList.Trim()))
            {
                cmdText += $"CREATE TABLE {dataTable.TableName} ({columnList})";
                expressionExecutor.Execute(cmdText);
            }
        }

        private string GetMappedDbDataType(string nativeType, int maxLength)
        {
            string dbType = nativeType;
            string len;

            if (maxLength == -1 || maxLength == 2147483647)
            {   
                len = "max";    
            }
            else 
            {  
                len = Convert.ToString(maxLength);  
            } 

            if (nativeType.ToLower().Contains("string"))
            {
                dbType = $"nvarchar({len})";
            }
            else if (nativeType.ToLower().Contains("int"))
            {
                dbType = $"int";
            }
            else if(nativeType.ToLower().Contains("datetime"))
            {
                dbType = "DateTime";
            }
            else if(nativeType.ToLower().Contains("decimal"))
            {
                dbType = "Decimal(38, 10)";
            }
            else if(nativeType.ToLower().Contains("bool"))
            {
                dbType = "bit";
            }
            else if(nativeType.ToLower().Contains("guid"))
            {
                dbType = "uniqueidentifier";
            }
            else if(nativeType.ToLower().Contains("xml"))
            {
                dbType = "xml";
            }
            else if(nativeType.ToLower().Contains("byte"))
            {
                dbType = "tinyint";
            }

            return dbType;
        }
    }
}
