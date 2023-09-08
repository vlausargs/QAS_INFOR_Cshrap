//PROJECT NAME: MG.MGCore
//CLASS NAME: BuildXMLFilterString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class BuildXMLFilterString : IBuildXMLFilterString
    {
        IApplicationDB appDB;


        public BuildXMLFilterString(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string XmlFilterString) BuildXMLFilterStringSp(string PropertyName,
        string Operator = "=",
        string Value = null,
        string DataType = "VeryLongListType",
        string NameInParmList = null,
        int? IsPropertyInWhereClause = 1,
        int? UseSpecifiedDataType = 1,
        int? DataLength = 0,
        string XmlFilterString = null)
        {
            VeryLongListType _PropertyName = PropertyName;
            VeryLongListType _Operator = Operator;
            VeryLongListType _Value = Value;
            VeryLongListType _DataType = DataType;
            VeryLongListType _NameInParmList = NameInParmList;
            ListYesNoType _IsPropertyInWhereClause = IsPropertyInWhereClause;
            ListYesNoType _UseSpecifiedDataType = UseSpecifiedDataType;
            IntType _DataLength = DataLength;
            VeryLongListType _XmlFilterString = XmlFilterString;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "BuildXMLFilterStringSp";

                appDB.AddCommandParameter(cmd, "PropertyName", _PropertyName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Operator", _Operator, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NameInParmList", _NameInParmList, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsPropertyInWhereClause", _IsPropertyInWhereClause, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseSpecifiedDataType", _UseSpecifiedDataType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DataLength", _DataLength, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "XmlFilterString", _XmlFilterString, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                XmlFilterString = _XmlFilterString;

                return (Severity, XmlFilterString);
            }
        }
    }
}
