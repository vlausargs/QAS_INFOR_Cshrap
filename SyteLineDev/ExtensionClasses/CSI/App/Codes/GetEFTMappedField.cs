//PROJECT NAME: Codes
//CLASS NAME: GetEFTMappedField.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetEFTMappedField
    {
        (int? ReturnCode, string FieldValue,
        string InfoBar) GetEFTMappedFieldSp(string FileName,
        string AppFieldName,
        int? Sequence,
        string FieldValue,
        string InfoBar);
    }

    public class GetEFTMappedField : IGetEFTMappedField
    {
        readonly IApplicationDB appDB;

        public GetEFTMappedField(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string FieldValue,
        string InfoBar) GetEFTMappedFieldSp(string FileName,
        string AppFieldName,
        int? Sequence,
        string FieldValue,
        string InfoBar)
        {
            OSLocationType _FileName = FileName;
            EFTImportFieldNameType _AppFieldName = AppFieldName;
            IntType _Sequence = Sequence;
            EFTValueType _FieldValue = FieldValue;
            InfobarType _InfoBar = InfoBar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEFTMappedFieldSp";

                appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AppFieldName", _AppFieldName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FieldValue", _FieldValue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                FieldValue = _FieldValue;
                InfoBar = _InfoBar;

                return (Severity, FieldValue, InfoBar);
            }
        }
    }
}
