using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System.Globalization;

namespace CSI.Data
{
    public class CSIRemoteMethodCall : ICSIRemoteMethodCall
    {
        readonly IApplicationDB appDB;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IConvertToUtil convertToUtil;

        public CSIRemoteMethodCall(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IConvertToUtil convertToUtil)
        {
            this.appDB = appDB;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.convertToUtil = convertToUtil;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RemoteMethodCallSp(
            string Site,
            string IdoName,
            string MethodName,
            string StoredProcName,
            string Infobar,
            Guid? RefRowPointer,
            params object[] parms)
        {
            SiteType _site = Site;
            StringType _idoName = DBNull.Value;
            StringType _methodName = MethodName;
            StringType _storedProcName = DBNull.Value;
            InfobarType _infobar = Infobar;
            GuidType _refRowPointer = RefRowPointer;

            if (!string.IsNullOrEmpty(IdoName))
                _idoName = IdoName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RemoteMethodCallSp";

                appDB.AddCommandParameter(cmd, "Site", _site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IdoName", _idoName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MethodName", _methodName, ParameterDirection.Input);
                if (StoredProcName != null)
                    appDB.AddCommandParameter(cmd, "StoredProcName", _storedProcName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _infobar, ParameterDirection.InputOutput);

                int idx = 0;
                foreach (var parm in parms)
                {
                    StringType _parm = DBNull.Value;
                    if (parm != null)
                        _parm = EvaluateParameter(parm);

                    appDB.AddCommandParameter(cmd, $"Parm{++idx}Value", _parm, ParameterDirection.Input);
                }

                if (RefRowPointer != null)
                    appDB.AddCommandParameter(cmd, "RefRowPointer", _refRowPointer, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _infobar;

                return (dataTableToCollectionLoadResponse.Process(dtReturn), returnVal, Infobar);
            }
        }

        private string EvaluateParameter(object parm)
        {
            DateTime? dateTime = convertToUtil.ToDateTime(parm);

            if (dateTime != null)
                return dateTime.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            else 
                return Convert.ToString(parm);
        }
    }
}