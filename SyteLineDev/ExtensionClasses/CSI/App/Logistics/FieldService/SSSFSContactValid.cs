//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSContactValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSContactValid
    {
        int SSSFSContactValidSp(ref CustNumType CustNum,
                                ref CustSeqType CustSeq,
                                FSUsrNumType UsrNum,
                                FSUsrSeqType UsrSeq,
                                NameType Contact,
                                ref PhoneType Phone,
                                ref PhoneType FaxNum,
                                ref EmailType Email,
                                ref Infobar Infobar,
                                ref EmailType PagerAddr,
                                ref EmailType TxtMsgAddr,
                                ref Infobar ContactPromptMsg,
                                ref Infobar ContactPromptButtons);
    }

    public class SSSFSContactValid : ISSSFSContactValid
    {
        readonly IApplicationDB appDB;

        public SSSFSContactValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSContactValidSp(ref CustNumType CustNum,
                                       ref CustSeqType CustSeq,
                                       FSUsrNumType UsrNum,
                                       FSUsrSeqType UsrSeq,
                                       NameType Contact,
                                       ref PhoneType Phone,
                                       ref PhoneType FaxNum,
                                       ref EmailType Email,
                                       ref Infobar Infobar,
                                       ref EmailType PagerAddr,
                                       ref EmailType TxtMsgAddr,
                                       ref Infobar ContactPromptMsg,
                                       ref Infobar ContactPromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSContactValidSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UsrNum", UsrNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UsrSeq", UsrSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Contact", Contact, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Phone", Phone, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FaxNum", FaxNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Email", Email, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PagerAddr", PagerAddr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TxtMsgAddr", TxtMsgAddr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ContactPromptMsg", ContactPromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ContactPromptButtons", ContactPromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

