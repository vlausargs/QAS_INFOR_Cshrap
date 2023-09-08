//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGetSROType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSGetSROType
    {
        int SSSPOSGetSROTypeSp(string CashDrawer,
                               ref byte? IsValid,
                               ref string Description,
                               ref string ProductCode,
                               ref string BillCode,
                               ref string BillType,
                               ref string Whse,
                               ref decimal? Disc);
    }

    public class SSSPOSGetSROType : ISSSPOSGetSROType
    {
        readonly IApplicationDB appDB;

        public SSSPOSGetSROType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSGetSROTypeSp(string CashDrawer,
                                      ref byte? IsValid,
                                      ref string Description,
                                      ref string ProductCode,
                                      ref string BillCode,
                                      ref string BillType,
                                      ref string Whse,
                                      ref decimal? Disc)
        {
            POSMDrawerType _CashDrawer = CashDrawer;
            ListYesNoType _IsValid = IsValid;
            DescriptionType _Description = Description;
            ProductCodeType _ProductCode = ProductCode;
            FSSROBillCodeType _BillCode = BillCode;
            FSSROBillTypeType _BillType = BillType;
            WhseType _Whse = Whse;
            OrderDiscType _Disc = Disc;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSGetSROTypeSp";

                appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsValid", _IsValid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                IsValid = _IsValid;
                Description = _Description;
                ProductCode = _ProductCode;
                BillCode = _BillCode;
                BillType = _BillType;
                Whse = _Whse;
                Disc = _Disc;

                return Severity;
            }
        }
    }
}
