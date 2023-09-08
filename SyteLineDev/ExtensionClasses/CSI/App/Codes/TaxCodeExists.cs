//PROJECT NAME: CSICodes
//CLASS NAME: TaxCodeExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface ITaxCodeExists
    {
        int TaxCodeExistsSp(byte? TaxSystem,
                            string TaxCodeType,
                            string TaxCode,
                            ref string Infobar);
    }

    public class TaxCodeExists : ITaxCodeExists
    {
        readonly IApplicationDB appDB;

        public TaxCodeExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TaxCodeExistsSp(byte? TaxSystem,
                                   string TaxCodeType,
                                   string TaxCode,
                                   ref string Infobar)
        {
            TaxSystemType _TaxSystem = TaxSystem;
            TaxCodeTypeType _TaxCodeType = TaxCodeType;
            TaxCodeType _TaxCode = TaxCode;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaxCodeExistsSp";

                appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeType", _TaxCodeType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
