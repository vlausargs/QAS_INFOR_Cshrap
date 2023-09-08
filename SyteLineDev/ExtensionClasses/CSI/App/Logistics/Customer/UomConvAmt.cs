//PROJECT NAME: Logistics
//CLASS NAME: UomConvAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.Customer
{
    public class UomConvAmt : IUomConvAmt
    {
        readonly IApplicationDB appDB;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public UomConvAmt(IApplicationDB appDB,
        IMathUtil mathUtil,
        ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
        }

        public (int? ReturnCode, decimal? ConvertedAmt,
        string Infobar) UomConvAmtSp(decimal? AmtToBeConverted,
        decimal? UomConvFactor,
        string FROMBase,
        decimal? ConvertedAmt,
        string Infobar)
        {
            AmountType _AmtToBeConverted = AmtToBeConverted;
            UMConvFactorType _UomConvFactor = UomConvFactor;
            StringType _FROMBase = FROMBase;
            AmountType _ConvertedAmt = ConvertedAmt;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UomConvAmtSp";

                appDB.AddCommandParameter(cmd, "AmtToBeConverted", _AmtToBeConverted, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FROMBase", _FROMBase, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConvertedAmt", _ConvertedAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ConvertedAmt = _ConvertedAmt;
                Infobar = _Infobar;

                return (Severity, ConvertedAmt, Infobar);
            }
        }

        public decimal? UomConvAmtFn(decimal? AmtToBeConverted,
        decimal? UomConvFactor,
        string FromBase)
        {
            #region Refactored - Converted from Bounce to C#
            //AmountType _AmtToBeConverted = AmtToBeConverted;
            //         UMConvFactorType _UomConvFactor = UomConvFactor;
            //         StringType _FromBase = FromBase;

            //         using (IDbCommand cmd = appDB.CreateCommand())
            //         {

            //             cmd.CommandType = CommandType.Text;
            //             cmd.CommandText = "SELECT  dbo.[UomConvAmt](@AmtToBeConverted, @UomConvFactor, @FromBase)";

            //             appDB.AddCommandParameter(cmd, "AmtToBeConverted", _AmtToBeConverted, ParameterDirection.Input);
            //             appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
            //             appDB.AddCommandParameter(cmd, "FromBase", _FromBase, ParameterDirection.Input);

            //             var Output = appDB.ExecuteScalar<decimal?>(cmd);

            //             return Output;
            //         }
            #endregion

            decimal? ConvertedAmt = null;
            if (sQLUtil.SQLEqual(UomConvFactor, 0) == true)
            {
                UomConvFactor = 1M;

            }
            if (sQLUtil.SQLEqual(FromBase, "From Base") == true)
            {
                ConvertedAmt = mathUtil.Round<decimal?>(AmtToBeConverted / UomConvFactor, 10);

            }
            if (sQLUtil.SQLEqual(FromBase, "To Base") == true)
            {
                ConvertedAmt = mathUtil.Round<decimal?>(AmtToBeConverted * UomConvFactor, 10);

            }
            return ConvertedAmt;
        }
    }
}
