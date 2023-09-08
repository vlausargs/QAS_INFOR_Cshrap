using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLColumnSchema : ISQLColumnSchema
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
        public Type ColumnType { get; }
        bool isBlob;
        bool isStringBlob;
        int dataLength;

        public SQLColumnSchema(
            string columnName,
            string sqlDataType,
            int? characterMaximumLength,
            bool isFilestream,
            bool isCaseInsensitive,
            int? codePage,
            bool isIdentity,
            object initialValue,
            bool sizedByCharacterMaximumLength,
            Type columnType,
            bool isBlob,
            bool isStringBlob,
            int dataLength)
        {
            this.columnName = columnName;
            this.sqlDataType = sqlDataType;
            this.characterMaximumLength = characterMaximumLength;
            this.isFilestream = isFilestream;
            this.isCaseInsensitive = isCaseInsensitive;
            this.codePage = codePage;
            this.isIdentity = isIdentity;
            this.initialValue = initialValue;
            this.sizedByCharacterMaximumLength = sizedByCharacterMaximumLength;
            this.ColumnType = columnType;
            this.isBlob = isBlob;
            this.isStringBlob = isStringBlob;
            this.dataLength = dataLength;
        }
    }
}
