//PROJECT NAME: CSICodes
//CLASS NAME: GetParamTaxDiscAllow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetParamTaxDiscAllow
    {
        int GetParamTaxDiscAllowSP(TaxSystemType TaxSystem,
                                   ref ListYesNoType TaxDiscAllow);
    }

    public class GetParamTaxDiscAllow : IGetParamTaxDiscAllow
    {
        readonly IApplicationDB appDB;

        public GetParamTaxDiscAllow(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetParamTaxDiscAllowSP(TaxSystemType TaxSystem,
                                          ref ListYesNoType TaxDiscAllow)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetParamTaxDiscAllowSP";

                appDB.AddCommandParameter(cmd, "TaxSystem", TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxDiscAllow", TaxDiscAllow, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
