//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetConsumerCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSGetConsumerCust
    {
        int SSSFSGetConsumerCustSp(FSUsrNumType iUsrNum,
                                   ref CustNumType oCustNum);
    }

    public class SSSFSGetConsumerCust : ISSSFSGetConsumerCust
    {
        readonly IApplicationDB appDB;

        public SSSFSGetConsumerCust(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSGetConsumerCustSp(FSUsrNumType iUsrNum,
                                          ref CustNumType oCustNum)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSGetConsumerCustSp";

                appDB.AddCommandParameter(cmd, "iUsrNum", iUsrNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oCustNum", oCustNum, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
