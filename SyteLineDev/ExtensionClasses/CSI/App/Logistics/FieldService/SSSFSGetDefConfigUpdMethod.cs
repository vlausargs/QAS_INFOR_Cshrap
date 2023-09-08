//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetDefConfigUpdMethod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSGetDefConfigUpdMethod
    {
        int SSSFSGetDefConfigUpdMethodSp(ref FSConfigUpdateMethodType ConfigUpdateMethod);
    }

    public class SSSFSGetDefConfigUpdMethod : ISSSFSGetDefConfigUpdMethod
    {
        readonly IApplicationDB appDB;

        public SSSFSGetDefConfigUpdMethod(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSGetDefConfigUpdMethodSp(ref FSConfigUpdateMethodType ConfigUpdateMethod)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSGetDefConfigUpdMethodSp";

                appDB.AddCommandParameter(cmd, "ConfigUpdateMethod", ConfigUpdateMethod, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
