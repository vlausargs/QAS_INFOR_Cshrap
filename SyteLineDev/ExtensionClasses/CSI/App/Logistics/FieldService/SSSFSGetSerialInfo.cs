//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetSerialInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSGetSerialInfo
    {
        int SSSFSGetSerialInfoSp(ref SerNumType iSerNum,
                                 ref ItemType oItem);
    }

    public class SSSFSGetSerialInfo : ISSSFSGetSerialInfo
    {
        readonly IApplicationDB appDB;

        public SSSFSGetSerialInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSGetSerialInfoSp(ref SerNumType iSerNum,
                                        ref ItemType oItem)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSGetSerialInfoSp";

                appDB.AddCommandParameter(cmd, "iSerNum", iSerNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oItem", oItem, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
