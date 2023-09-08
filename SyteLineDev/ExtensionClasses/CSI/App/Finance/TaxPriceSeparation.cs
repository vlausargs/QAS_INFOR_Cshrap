//PROJECT NAME: Finance
//CLASS NAME: TaxPriceSeparation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
    public class TaxPriceSeparation : ITaxPriceSeparation
    {
        readonly IApplicationDB appDB;

        public TaxPriceSeparation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            decimal? AmountWithoutTax,
            decimal? UndiscAmountWithoutTax,
            decimal? Tax1OnAmount,
            decimal? Tax2OnAmount,
            decimal? Tax1OnUndiscAmount,
            decimal? Tax2OnUndiscAmount,
            string Infobar) TaxPriceSeparationSp(
            string InvType = "R",
            string Type = "I",
            string TaxCode1 = null,
            string TaxCode2 = null,
            string HdrTaxCode1 = null,
            string HdrTaxCode2 = null,
            decimal? Amount = null,
            decimal? UndiscAmount = null,
            string CurrCode = null,
            decimal? ExchRate = null,
            int? UseExchRate = null,
            int? Places = 2,
            DateTime? InvDate = null,
            string TermsCode = null,
            decimal? AmountWithoutTax = null,
            decimal? UndiscAmountWithoutTax = null,
            decimal? Tax1OnAmount = null,
            decimal? Tax2OnAmount = null,
            decimal? Tax1OnUndiscAmount = null,
            decimal? Tax2OnUndiscAmount = null,
            string Infobar = null,
            decimal? WholesalePrice = null,
            string Site = null,
            string DomCurrCode = null,
            int? IsTaxInterfaceAvailable = null,
            int? vrtx_parm_Exists = null,
            int? IsJapanInterfaceAvailable = null)
        {
            StringType _InvType = InvType;
            StringType _Type = Type;
            TaxCodeType _TaxCode1 = TaxCode1;
            TaxCodeType _TaxCode2 = TaxCode2;
            TaxCodeType _HdrTaxCode1 = HdrTaxCode1;
            TaxCodeType _HdrTaxCode2 = HdrTaxCode2;
            AmountType _Amount = Amount;
            AmountType _UndiscAmount = UndiscAmount;
            CurrCodeType _CurrCode = CurrCode;
            ExchRateType _ExchRate = ExchRate;
            ListYesNoType _UseExchRate = UseExchRate;
            DecimalPlacesType _Places = Places;
            DateType _InvDate = InvDate;
            TermsCodeType _TermsCode = TermsCode;
            AmountType _AmountWithoutTax = AmountWithoutTax;
            AmountType _UndiscAmountWithoutTax = UndiscAmountWithoutTax;
            AmountType _Tax1OnAmount = Tax1OnAmount;
            AmountType _Tax2OnAmount = Tax2OnAmount;
            AmountType _Tax1OnUndiscAmount = Tax1OnUndiscAmount;
            AmountType _Tax2OnUndiscAmount = Tax2OnUndiscAmount;
            InfobarType _Infobar = Infobar;
            AmountType _WholesalePrice = WholesalePrice;
            SiteType _Site = Site;
            CurrCodeType _DomCurrCode = DomCurrCode;
            ListYesNoType _IsTaxInterfaceAvailable = IsTaxInterfaceAvailable;
            ListYesNoType _vrtx_parm_Exists = vrtx_parm_Exists;
            ListYesNoType _IsJapanInterfaceAvailable = IsJapanInterfaceAvailable;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TaxPriceSeparationSp";

                appDB.AddCommandParameter(cmd, "InvType", _InvType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HdrTaxCode1", _HdrTaxCode1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HdrTaxCode2", _HdrTaxCode2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UndiscAmount", _UndiscAmount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Places", _Places, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AmountWithoutTax", _AmountWithoutTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UndiscAmountWithoutTax", _UndiscAmountWithoutTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Tax1OnAmount", _Tax1OnAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Tax2OnAmount", _Tax2OnAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Tax1OnUndiscAmount", _Tax1OnUndiscAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Tax2OnUndiscAmount", _Tax2OnUndiscAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WholesalePrice", _WholesalePrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsTaxInterfaceAvailable", _IsTaxInterfaceAvailable, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "vrtx_parm_Exists", _vrtx_parm_Exists, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IsJapanInterfaceAvailable", _IsJapanInterfaceAvailable, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                AmountWithoutTax = _AmountWithoutTax;
                UndiscAmountWithoutTax = _UndiscAmountWithoutTax;
                Tax1OnAmount = _Tax1OnAmount;
                Tax2OnAmount = _Tax2OnAmount;
                Tax1OnUndiscAmount = _Tax1OnUndiscAmount;
                Tax2OnUndiscAmount = _Tax2OnUndiscAmount;
                Infobar = _Infobar;

                return (Severity, AmountWithoutTax, UndiscAmountWithoutTax, Tax1OnAmount, Tax2OnAmount, Tax1OnUndiscAmount, Tax2OnUndiscAmount, Infobar);
            }
        }
    }
}
