//PROJECT NAME: Logistics
//CLASS NAME: UomConvQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.Customer
{
    public class UomConvQty : IUomConvQty
    {
        readonly IApplicationDB appDB;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;

        public UomConvQty(IApplicationDB appDB,
        IMathUtil mathUtil,
        ISQLValueComparerUtil sQLUtil)
        {
            this.appDB = appDB;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
        }

        public (int? ReturnCode, decimal? ConvertedQty,
        string Infobar) UomConvQtySp(decimal? QtyToBeConverted,
        decimal? UomConvFactor,
        string FROMBase,
        decimal? ConvertedQty,
        string Infobar)
        {
            QtyUnitType _QtyToBeConverted = QtyToBeConverted;
            UMConvFactorType _UomConvFactor = UomConvFactor;
            StringType _FROMBase = FROMBase;
            QtyUnitType _ConvertedQty = ConvertedQty;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UomConvQtySp";

                appDB.AddCommandParameter(cmd, "QtyToBeConverted", _QtyToBeConverted, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FROMBase", _FROMBase, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConvertedQty", _ConvertedQty, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ConvertedQty = _ConvertedQty;
                Infobar = _Infobar;

                return (Severity, ConvertedQty, Infobar);
            }
        }

        public decimal? UomConvQtyFn(decimal? QtyToBeConverted, decimal? UomConvFactor, string FromBase)
        {
            #region Refactored - Converted from Bounce to C#
            //QtyUnitType _QtyToBeConverted = QtyToBeConverted;
            //         UMConvFactorType _UomConvFactor = UomConvFactor;
            //         StringType _FromBase = FromBase;

            //         using (IDbCommand cmd = appDB.CreateCommand())
            //         {

            //             cmd.CommandType = CommandType.Text;
            //             cmd.CommandText = "SELECT  dbo.[UomConvQty](@QtyToBeConverted, @UomConvFactor, @FromBase)";

            //             appDB.AddCommandParameter(cmd, "QtyToBeConverted", _QtyToBeConverted, ParameterDirection.Input);
            //             appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.Input);
            //             appDB.AddCommandParameter(cmd, "FromBase", _FromBase, ParameterDirection.Input);

            //             var Output = appDB.ExecuteScalar<decimal?>(cmd);

            //             return Output;
            //         }
            #endregion

            decimal? ConvertedQty = QtyToBeConverted;
            if (sQLUtil.SQLNotEqual(UomConvFactor, 0) == true && sQLUtil.SQLNotEqual(UomConvFactor, 1) == true)
            {
                if (sQLUtil.SQLEqual(FromBase, "From Base") == true)
                {
                    ConvertedQty = mathUtil.Round<decimal?>(QtyToBeConverted * UomConvFactor, 10);

                }
                if (sQLUtil.SQLEqual(FromBase, "To Base") == true)
                {
                    ConvertedQty = mathUtil.Round<decimal?>(QtyToBeConverted / UomConvFactor, 10);

                }

            }

            return ConvertedQty;
        }
    }
}
