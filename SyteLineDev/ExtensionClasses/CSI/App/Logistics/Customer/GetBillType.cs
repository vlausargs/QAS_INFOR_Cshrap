//PROJECT NAME: CSICustomer
//CLASS NAME: GetBillType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGetBillType
    {
        int GetBillTypeSp(string Invnum,
                          ref string BillType);
    }

    public class GetBillType : IGetBillType
    {
        readonly IApplicationDB appDB;

        public GetBillType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetBillTypeSp(string Invnum,
                                 ref string BillType)
        {
            InvNumType _Invnum = Invnum;
            BillingTypeType _BillType = BillType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetBillTypeSp";

                appDB.AddCommandParameter(cmd, "Invnum", _Invnum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                BillType = _BillType;

                return Severity;
            }
        }
    }
}
