//PROJECT NAME: CSICustomer
//CLASS NAME: GetTaxInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGetTaxInfo
    {
        int GetTaxInfoSp(ref ListYesNoType EnableTax1,
                         ref ListYesNoType EnableTax2);
    }

    public class GetTaxInfo : IGetTaxInfo
    {
        readonly IApplicationDB appDB;

        public GetTaxInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTaxInfoSp(ref ListYesNoType EnableTax1,
                                ref ListYesNoType EnableTax2)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTaxInfoSp";

                appDB.AddCommandParameter(cmd, "EnableTax1", EnableTax1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EnableTax2", EnableTax2, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
