//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSReverseLookUpCL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSReverseLookUpCL
    {
        DataTable SSSPOSReverseLookUpCLSp(string CustNum,
                                          int? CustSeq,
                                          string SerNum,
                                          string POSNum,
                                          string CashDrawer,
                                          string PartnerID,
                                          string UserName);
    }

    public class SSSPOSReverseLookUpCL : ISSSPOSReverseLookUpCL
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSPOSReverseLookUpCL(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSPOSReverseLookUpCLSp(string CustNum,
                                                 int? CustSeq,
                                                 string SerNum,
                                                 string POSNum,
                                                 string CashDrawer,
                                                 string PartnerID,
                                                 string UserName)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                CustNumType _CustNum = CustNum;
                CustSeqType _CustSeq = CustSeq;
                SerNumType _SerNum = SerNum;
                POSMNumType _POSNum = POSNum;
                POSMDrawerType _CashDrawer = CashDrawer;
                FSPartnerType _PartnerID = PartnerID;
                UsernameType _UserName = UserName;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSSPOSReverseLookUpCLSp";

                    appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
