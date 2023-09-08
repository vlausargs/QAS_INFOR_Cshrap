//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCustomerContact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IUpdateCustomerContact
    {
        int UpdateCustomerContactSp(string CustNum,
                                    int? CustSeq,
                                    string ContactID,
                                    ref string Infobar);
    }

    public class UpdateCustomerContact : IUpdateCustomerContact
    {
        readonly IApplicationDB appDB;

        public UpdateCustomerContact(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int UpdateCustomerContactSp(string CustNum,
                                           int? CustSeq,
                                           string ContactID,
                                           ref string Infobar)
        {
            CustNumType _CustNum = CustNum;
            CustSeqType _CustSeq = CustSeq;
            ContactIDType _ContactID = ContactID;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCustomerContactSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ContactID", _ContactID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
