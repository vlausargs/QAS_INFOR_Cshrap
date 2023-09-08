//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSCustContactValidCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSCustContactValidCust
    {
        int SSSFSCustContactValidCustSp(CustNumType CustNum,
                                        ref CustSeqType CustSeq,
                                        StringType Level,
                                        ref NameType Name,
                                        ref FSContactNumType NextContact,
                                        ref ListYesNoType DefaultContact,
                                        ref InfobarType Infobar);
    }

    public class SSSFSCustContactValidCust : ISSSFSCustContactValidCust
    {
        readonly IApplicationDB appDB;

        public SSSFSCustContactValidCust(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSCustContactValidCustSp(CustNumType CustNum,
                                               ref CustSeqType CustSeq,
                                               StringType Level,
                                               ref NameType Name,
                                               ref FSContactNumType NextContact,
                                               ref ListYesNoType DefaultContact,
                                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSCustContactValidCustSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Level", Level, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Name", Name, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NextContact", NextContact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DefaultContact", DefaultContact, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

