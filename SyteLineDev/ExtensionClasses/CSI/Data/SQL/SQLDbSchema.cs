using CSI.Data.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLDbSchema : IAppDbSchema
    {
        readonly ICommandProvider cp;
        readonly IParameterProvider parameterProvider;
        readonly ITablePrimaryKeyCache tablePrimaryKeyCache;
        readonly ITableSchemaCache tableSchemaCache;
        readonly ISQLParameterizedCommandFactory parameterizedCommandFactory;

        public SQLDbSchema(ICommandProvider cp, IParameterProvider parameterProvider, ITablePrimaryKeyCache tablePrimaryKeyCache, ITableSchemaCache tableSchemaCache, ISQLParameterizedCommandFactory parameterizedCommandFactory)
        {
            this.cp = cp;
            this.parameterProvider = parameterProvider;
            this.tablePrimaryKeyCache = tablePrimaryKeyCache;
            this.tableSchemaCache = tableSchemaCache;
            this.parameterizedCommandFactory = parameterizedCommandFactory;
        }

        public IEnumerable<string> GetPrimaryKeyColumns(string tableName)
        {
            var cacheHit = tablePrimaryKeyCache.Get(tableName);
            if (cacheHit != null) return cacheHit;

            var primaryKey = new List<string>();
            string statement = string.Empty;
            var statementParms = new List<IDataParameter>();

            if (tableName.Substring(0, 1) == "#")
            {
                statement = " SELECT col.[name] AS PRIMARYKEYCOLUMN ";
                statement += "FROM tempdb.sys.objects obj WITH (READUNCOMMITTED) ";
                statement += "INNER JOIN tempdb.sys.tables tab WITH (READUNCOMMITTED) ON obj.name = tab.name ";
                statement += "INNER JOIN tempdb.sys.indexes pk WITH (READUNCOMMITTED) ON tab.object_id = pk.object_id AND pk.is_primary_key = 1 ";
                statement += "INNER JOIN tempdb.sys.index_columns ic WITH (READUNCOMMITTED) ON ic.object_id = pk.object_id AND ic.index_id = pk.index_id ";
                statement += "INNER JOIN tempdb.sys.columns col WITH (READUNCOMMITTED) ON pk.object_id = col.object_id AND col.column_id = ic.column_id ";
                statement += "WHERE obj.object_id = object_id('tempdb..' + @tempTable) ";
                statement += "UNION ";
                statement += "SELECT ";
                statement += "tempColumns.name ";
                statement += "FROM tempdb.sys.objects tempTable WITH (READUNCOMMITTED) ";
                statement += "INNER JOIN ";
                statement += "tempdb.sys.all_columns tempColumns WITH (READUNCOMMITTED) ON tempTable.object_id = tempColumns.object_id ";
                statement += "WHERE TYPE = 'U' AND ";
                statement += "tempTable.object_id = object_id('tempdb..' + @tempTable) AND ";
                statement += "tempColumns.is_identity = 1 ";
                statementParms.Add(parameterProvider.CreateParameter("@tempTable", tableName));
            }
            else
            {
                statement = "SELECT col.[name] ";
                statement += "FROM AppTable WITH (READUNCOMMITTED) ";
                statement += "INNER JOIN sys.tables AS tab WITH (READUNCOMMITTED) ON tab.name = AppTable.TableName ";
                statement += "INNER JOIN sys.indexes pk WITH (READUNCOMMITTED) ON tab.object_id = pk.object_id AND pk.is_primary_key = 1 ";
                statement += "INNER JOIN sys.index_columns ic WITH (READUNCOMMITTED) ON ic.object_id = pk.object_id AND ic.index_id = pk.index_id ";
                statement += "INNER JOIN sys.columns col WITH (READUNCOMMITTED) ON pk.object_id = col.object_id AND col.column_id = ic.column_id AND col.name <> 'site_ref' ";
                statement += "WHERE AppTable.AppViewName = @TableName ";
                statement += "UNION ";
                statement += "SELECT col.[name] ";
                statement += "FROM sys.tables tab WITH (READUNCOMMITTED) ";
                statement += "INNER JOIN sys.indexes pk WITH (READUNCOMMITTED) ON tab.object_id = pk.object_id AND pk.is_primary_key = 1 ";
                statement += "INNER JOIN sys.index_columns ic WITH (READUNCOMMITTED) ON ic.object_id = pk.object_id AND ic.index_id = pk.index_id ";
                statement += "INNER JOIN sys.columns col WITH (READUNCOMMITTED) ON pk.object_id = col.object_id AND col.column_id = ic.column_id ";
                statement += "WHERE tab.name = @TableName";
                statementParms.Add(parameterProvider.CreateParameter("@TableSchema", "dbo"));
                statementParms.Add(parameterProvider.CreateParameter("@TableName", tableName));
            }

            var pcommand = parameterizedCommandFactory.Create(statement, statementParms);

            using (var command = cp.CreateCommand())
            {
                command.CommandText = pcommand.Statement;
                foreach (var parameter in pcommand.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                using (var reader = command.ExecuteReader())
                {
                    //get list of all keys
                    while (reader.Read())
                    {
                        string key = (string)reader[0];
                        primaryKey.Add(key);
                    }
                }
            }

            tablePrimaryKeyCache.Put(tableName, primaryKey);

            return primaryKey;
        }

        public ISQLTableSchema GetTableSchema(string tableName)
        {
            var cacheHit = tableSchemaCache.Get(tableName);
            if (cacheHit != null) return cacheHit;

            string statement = string.Empty;
            var statementParms = new List<IDataParameter>();

            statement = "select ";
            statement += "  isc.COLUMN_NAME"; int COLUMN_NAMEpos = 0;
            statement += ", isc.DATA_TYPE"; int DATA_TYPEpos = 1;
            statement += ", isc.CHARACTER_MAXIMUM_LENGTH"; int CHARACTER_MAXIMUM_LENGTHpos = 2;
            statement += ", case when sc.is_filestream is null then cast(0 as bit) else sc.is_filestream end"; int is_filestream_pos = 3;
            statement += ", isc.COLLATION_NAME"; int COLLATION_NAMEpos = 4;
            statement += ", convert(int, COLLATIONPROPERTY(isc.COLLATION_NAME, 'CodePage'))"; int CodePagePos = 5;
            statement += ", case when st.object_id is null then 0 else columnproperty(st.object_id, isc.COLUMN_NAME, 'isIdentity') end"; int isIdentityPos = 6;
            statement += ", isc.COLUMN_DEFAULT"; int COLUMN_DEFAULTpos = 7;
            statement += " from INFORMATION_SCHEMA.COLUMNS isc WITH (READUNCOMMITTED)";
            statement += " left join sys.schemas ss WITH (READUNCOMMITTED) on ss.name = TABLE_SCHEMA";
            statement += " left join sys.tables st WITH (READUNCOMMITTED) on st.schema_id = ss.schema_id and st.name = isc.TABLE_NAME";
            statement += " left join sys.columns sc WITH (READUNCOMMITTED) on sc.object_id = st.object_id and sc.name = isc.COLUMN_NAME";
            statement += " where isc.TABLE_SCHEMA = @TableSchema and isc.TABLE_NAME = @TableName";
            statement += " order by isc.COLUMN_NAME";
            statementParms.Add(parameterProvider.CreateParameter("@TableSchema", "dbo"));
            statementParms.Add(parameterProvider.CreateParameter("@TableName", tableName));

            var pcommand = parameterizedCommandFactory.Create(statement, statementParms);

            var tableSchema = new SQLTableSchema();

            using (var command = cp.CreateCommand())
            {
                command.CommandText = pcommand.Statement;
                foreach (var parameter in pcommand.Parameters)
                {
                    command.Parameters.Add(parameter);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName;
                        string sqlDataType;
                        int? characterMaximumLength;
                        bool isFilestream;
                        bool isCaseInsensitive;
                        int? codePage;
                        bool isIdentity;
                        object initialValue;
                        bool sizedByCharacterMaximumLength;
                        Type columnType;
                        bool isBlob = false;
                        bool isStringBlob = false;
                        int dataLength = 0;

                        try
                        {
                            columnName = reader[COLUMN_NAMEpos] as string;

                            sqlDataType = (string)reader[DATA_TYPEpos];

                            characterMaximumLength = reader[CHARACTER_MAXIMUM_LENGTHpos] == DBNull.Value
                                ? null
                                : (int?)reader[CHARACTER_MAXIMUM_LENGTHpos];

                            isFilestream = reader[is_filestream_pos] != DBNull.Value ? (bool)reader[is_filestream_pos] : false;

                            isCaseInsensitive = reader[COLLATION_NAMEpos] != DBNull.Value ? IsCaseInsensitiveCollation((string)reader[COLLATION_NAMEpos]) : true;

                            if (sqlDataType == "nvarchar" || sqlDataType == "nchar")
                                codePage = Encoding.Unicode.CodePage;
                            else if (reader[CodePagePos] != DBNull.Value)
                                codePage = (int)reader[CodePagePos];
                            else
                                codePage = null;

                            isIdentity = (int)reader[isIdentityPos] == 1;

                            if (reader[COLUMN_DEFAULTpos] != DBNull.Value)
                                initialValue = RemoveExcessParenthesis(reader[COLUMN_DEFAULTpos]);
                            else
                                initialValue = null;

                            columnType = MapInformationSchemaDataTypeToDotNetType(sqlDataType, out sizedByCharacterMaximumLength);

                            if (sizedByCharacterMaximumLength)
                            {
                                if (characterMaximumLength == -1)
                                {
                                    isBlob = true;

                                    if (columnType == typeof(string))
                                        isStringBlob = true;
                                }

                                dataLength = (int)characterMaximumLength;
                            }
                        }
                        catch
                        {
                            //something is wrong with this column - skip it
                            continue;
                        }

                        var columnSchema = new SQLColumnSchema(
                            columnName,
                            sqlDataType,
                            characterMaximumLength,
                            isFilestream,
                            isCaseInsensitive,
                            codePage,
                            isIdentity,
                            initialValue,
                            sizedByCharacterMaximumLength,
                            columnType,
                            isBlob,
                            isStringBlob,
                            dataLength);

                        tableSchema.AddColumn(columnName, columnSchema);
                    }
                }

                tableSchemaCache.Put(tableName, tableSchema);

                return tableSchema;
            }

            bool IsCaseInsensitiveCollation(string collationName) { return collationName.Contains("_CI_"); }

            object RemoveExcessParenthesis(object columnDefault)
            {
                if (!(columnDefault is string)) return columnDefault;

                string s = (string)columnDefault;
                s.Trim();

                while (s.StartsWith("(") && s.EndsWith(")"))
                {
                    s = s.Substring(1, s.Length - 2);
                    s.Trim();
                }

                return s;
            }

            Type MapInformationSchemaDataTypeToDotNetType(string sqlDataType, out bool sizedByCharacterMaximumLength)
            {
                Type columnType;
                sizedByCharacterMaximumLength = false;

                switch (sqlDataType)
                {
                    case "bigint":
                        columnType = typeof(Int64);
                        break;
                    case "binary":
                        columnType = typeof(byte[]);
                        break;
                    case "bit":
                        columnType = typeof(Boolean);
                        break;
                    case "char":
                        columnType = typeof(String);
                        sizedByCharacterMaximumLength = true;
                        break;
                    case "datetime":
                        columnType = typeof(DateTime);
                        break;
                    case "decimal":
                    case "numeric":
                        columnType = typeof(Decimal);
                        break;
                    case "float":
                        columnType = typeof(Double);
                        break;
                    case "int":
                        columnType = typeof(Int32);
                        break;
                    case "money":
                        columnType = typeof(Decimal);
                        break;
                    case "nchar":
                        columnType = typeof(String);
                        sizedByCharacterMaximumLength = true;
                        break;
                    case "nvarchar":
                        columnType = typeof(String);
                        sizedByCharacterMaximumLength = true;
                        break;
                    case "real":
                        columnType = typeof(Single);
                        break;
                    case "smalldatetime":
                        columnType = typeof(DateTime);
                        break;
                    case "smallint":
                        columnType = typeof(Int16);
                        break;
                    case "smallmoney":
                        columnType = typeof(Decimal);
                        break;
                    case "timestamp":
                        columnType = typeof(string);
                        break;
                    case "tinyint":
                        columnType = typeof(Byte);
                        break;
                    case "uniqueidentifier":
                        columnType = typeof(Guid);
                        break;
                    case "varbinary":
                        columnType = typeof(byte[]);
                        sizedByCharacterMaximumLength = true;
                        break;
                    case "varchar":
                        columnType = typeof(String);
                        sizedByCharacterMaximumLength = true;
                        break;
                    default:
                        throw new Exception(); // unsupported column type
                }

                return columnType;
            }
        }
    }
}
