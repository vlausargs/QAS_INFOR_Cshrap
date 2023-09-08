//PROJECT NAME: Adapters
//CLASS NAME: GetCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Adapters
{
    public class GetCode : IGetCode
    {
        readonly IApplicationDB appDB;


        public GetCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string PDesc,
        string PAltDesc,
        string PLocCode,
        string PBaseCode) GetCodeSp(string PClass,
        string PCode,
        string PDesc = null,
        string PAltDesc = null,
        string PLocCode = null,
        string PBaseCode = null)
        {
            ComboClassType _PClass = PClass;
            ComboValueType _PCode = PCode;
            InfobarType _PDesc = PDesc;
            InfobarType _PAltDesc = PAltDesc;
            ComboLabelType _PLocCode = PLocCode;
            ComboValueType _PBaseCode = PBaseCode;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetCodeSp";

                appDB.AddCommandParameter(cmd, "PClass", _PClass, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCode", _PCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDesc", _PDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PAltDesc", _PAltDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PLocCode", _PLocCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PBaseCode", _PBaseCode, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PDesc = _PDesc;
                PAltDesc = _PAltDesc;
                PLocCode = _PLocCode;
                PBaseCode = _PBaseCode;

                return (Severity, PDesc, PAltDesc, PLocCode, PBaseCode);
            }
        }
    }
}
