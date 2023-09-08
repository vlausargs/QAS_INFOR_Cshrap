//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetTaxAmount
    {
        int GetTaxAmountSp(byte? TaxSystem,
                           string TaxCode,
                           string TaxCodeType,
                           decimal? TaxBasis,
                           string CurrCode,
                           ref decimal? TaxAmount,
                           ref string Infobar);
    }

    public class GetTaxAmount : IGetTaxAmount
    {
        readonly IApplicationDB appDB;

        public GetTaxAmount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTaxAmountSp(byte? TaxSystem,
                                  string TaxCode,
                                  string TaxCodeType,
                                  decimal? TaxBasis,
                                  string CurrCode,
                                  ref decimal? TaxAmount,
                                  ref string Infobar)
        {
            TaxSystemType _TaxSystem = TaxSystem;
            TaxCodeType _TaxCode = TaxCode;
            TaxCodeTypeType _TaxCodeType = TaxCodeType;
            AmountType _TaxBasis = TaxBasis;
            CurrCodeType _CurrCode = CurrCode;
            AmountType _TaxAmount = TaxAmount;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTaxAmountSp";

                appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeType", _TaxCodeType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxBasis", _TaxBasis, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxAmount", _TaxAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TaxAmount = _TaxAmount;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
