//PROJECT NAME: CSIVendor
//CLASS NAME: APVoucherandAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAPVoucherandAdjustment
    {
        (int? ReturnCode, string RTaxCode1, string RTaxCode1Desc, string RTaxCode2, string RTaxCode2Desc, string RCurrCode, decimal? RExchRate, int? RProxCode, int? RProxDay, decimal? RDiscPct, int? RDiscDays, DateTime? RDiscDate, int? RDueDays, DateTime? RDueDate, string RApAcct, string RApAcctUnit1, string RApAcctUnit2, string RApAcctUnit3, string RApAcctUnit4, string RApAcctDesc, string rChartType, string rAccessUnit1, string rAccessUnit2, string rAccessUnit3, string rAccessUnit4, int? PPartOfEuro, int? POIncludeCost, string Infobar, int? RApAcctIsControl) APVoucherandAdjustmentSp(string PVendNum,
        DateTime? PInvoiceDate,
        string pChartAcct,
        string Site = null,
        string RTaxCode1 = null,
        string RTaxCode1Desc = null,
        string RTaxCode2 = null,
        string RTaxCode2Desc = null,
        string RCurrCode = null,
        decimal? RExchRate = null,
        int? RProxCode = null,
        int? RProxDay = null,
        decimal? RDiscPct = null,
        int? RDiscDays = null,
        DateTime? RDiscDate = null,
        int? RDueDays = null,
        DateTime? RDueDate = null,
        string RApAcct = null,
        string RApAcctUnit1 = null,
        string RApAcctUnit2 = null,
        string RApAcctUnit3 = null,
        string RApAcctUnit4 = null,
        string RApAcctDesc = null,
        string rChartType = null,
        string rAccessUnit1 = null,
        string rAccessUnit2 = null,
        string rAccessUnit3 = null,
        string rAccessUnit4 = null,
        int? PPartOfEuro = null,
        int? POIncludeCost = null,
        string Infobar = null,
        int? RApAcctIsControl = null);
    }

    public class APVoucherandAdjustment : IAPVoucherandAdjustment
    {
        readonly IApplicationDB appDB;

        public APVoucherandAdjustment(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string RTaxCode1, string RTaxCode1Desc, string RTaxCode2, string RTaxCode2Desc, string RCurrCode, decimal? RExchRate, int? RProxCode, int? RProxDay, decimal? RDiscPct, int? RDiscDays, DateTime? RDiscDate, int? RDueDays, DateTime? RDueDate, string RApAcct, string RApAcctUnit1, string RApAcctUnit2, string RApAcctUnit3, string RApAcctUnit4, string RApAcctDesc, string rChartType, string rAccessUnit1, string rAccessUnit2, string rAccessUnit3, string rAccessUnit4, int? PPartOfEuro, int? POIncludeCost, string Infobar, int? RApAcctIsControl) APVoucherandAdjustmentSp(string PVendNum,
        DateTime? PInvoiceDate,
        string pChartAcct,
        string Site = null,
        string RTaxCode1 = null,
        string RTaxCode1Desc = null,
        string RTaxCode2 = null,
        string RTaxCode2Desc = null,
        string RCurrCode = null,
        decimal? RExchRate = null,
        int? RProxCode = null,
        int? RProxDay = null,
        decimal? RDiscPct = null,
        int? RDiscDays = null,
        DateTime? RDiscDate = null,
        int? RDueDays = null,
        DateTime? RDueDate = null,
        string RApAcct = null,
        string RApAcctUnit1 = null,
        string RApAcctUnit2 = null,
        string RApAcctUnit3 = null,
        string RApAcctUnit4 = null,
        string RApAcctDesc = null,
        string rChartType = null,
        string rAccessUnit1 = null,
        string rAccessUnit2 = null,
        string rAccessUnit3 = null,
        string rAccessUnit4 = null,
        int? PPartOfEuro = null,
        int? POIncludeCost = null,
        string Infobar = null,
        int? RApAcctIsControl = null)
        {
            VendNumType _PVendNum = PVendNum;
            DateType _PInvoiceDate = PInvoiceDate;
            AcctType _pChartAcct = pChartAcct;
            SiteType _Site = Site;
            TaxCodeType _RTaxCode1 = RTaxCode1;
            DescriptionType _RTaxCode1Desc = RTaxCode1Desc;
            TaxCodeType _RTaxCode2 = RTaxCode2;
            DescriptionType _RTaxCode2Desc = RTaxCode2Desc;
            CurrCodeType _RCurrCode = RCurrCode;
            ExchRateType _RExchRate = RExchRate;
            ProxCodeType _RProxCode = RProxCode;
            ProxDayType _RProxDay = RProxDay;
            ApDiscType _RDiscPct = RDiscPct;
            DiscDaysType _RDiscDays = RDiscDays;
            DateType _RDiscDate = RDiscDate;
            DueDaysType _RDueDays = RDueDays;
            DateType _RDueDate = RDueDate;
            AcctType _RApAcct = RApAcct;
            UnitCode1Type _RApAcctUnit1 = RApAcctUnit1;
            UnitCode2Type _RApAcctUnit2 = RApAcctUnit2;
            UnitCode3Type _RApAcctUnit3 = RApAcctUnit3;
            UnitCode4Type _RApAcctUnit4 = RApAcctUnit4;
            DescriptionType _RApAcctDesc = RApAcctDesc;
            ChartTypeType _rChartType = rChartType;
            UnitCodeAccessType _rAccessUnit1 = rAccessUnit1;
            UnitCodeAccessType _rAccessUnit2 = rAccessUnit2;
            UnitCodeAccessType _rAccessUnit3 = rAccessUnit3;
            UnitCodeAccessType _rAccessUnit4 = rAccessUnit4;
            FlagNyType _PPartOfEuro = PPartOfEuro;
            ListYesNoType _POIncludeCost = POIncludeCost;
            InfobarType _Infobar = Infobar;
            ListYesNoType _RApAcctIsControl = RApAcctIsControl;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APVoucherandAdjustmentSp";

                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvoiceDate", _PInvoiceDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartAcct", _pChartAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RTaxCode1", _RTaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RTaxCode1Desc", _RTaxCode1Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RTaxCode2", _RTaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RTaxCode2Desc", _RTaxCode2Desc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RCurrCode", _RCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RExchRate", _RExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RProxCode", _RProxCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RProxDay", _RProxDay, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RDiscPct", _RDiscPct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RDiscDays", _RDiscDays, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RDiscDate", _RDiscDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RDueDays", _RDueDays, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RDueDate", _RDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcct", _RApAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctUnit1", _RApAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctUnit2", _RApAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctUnit3", _RApAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctUnit4", _RApAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctDesc", _RApAcctDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rChartType", _rChartType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rAccessUnit1", _rAccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rAccessUnit2", _rAccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rAccessUnit3", _rAccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "rAccessUnit4", _rAccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PPartOfEuro", _PPartOfEuro, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POIncludeCost", _POIncludeCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RApAcctIsControl", _RApAcctIsControl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                RTaxCode1 = _RTaxCode1;
                RTaxCode1Desc = _RTaxCode1Desc;
                RTaxCode2 = _RTaxCode2;
                RTaxCode2Desc = _RTaxCode2Desc;
                RCurrCode = _RCurrCode;
                RExchRate = _RExchRate;
                RProxCode = _RProxCode;
                RProxDay = _RProxDay;
                RDiscPct = _RDiscPct;
                RDiscDays = _RDiscDays;
                RDiscDate = _RDiscDate;
                RDueDays = _RDueDays;
                RDueDate = _RDueDate;
                RApAcct = _RApAcct;
                RApAcctUnit1 = _RApAcctUnit1;
                RApAcctUnit2 = _RApAcctUnit2;
                RApAcctUnit3 = _RApAcctUnit3;
                RApAcctUnit4 = _RApAcctUnit4;
                RApAcctDesc = _RApAcctDesc;
                rChartType = _rChartType;
                rAccessUnit1 = _rAccessUnit1;
                rAccessUnit2 = _rAccessUnit2;
                rAccessUnit3 = _rAccessUnit3;
                rAccessUnit4 = _rAccessUnit4;
                PPartOfEuro = _PPartOfEuro;
                POIncludeCost = _POIncludeCost;
                Infobar = _Infobar;
                RApAcctIsControl = _RApAcctIsControl;

                return (Severity, RTaxCode1, RTaxCode1Desc, RTaxCode2, RTaxCode2Desc, RCurrCode, RExchRate, RProxCode, RProxDay, RDiscPct, RDiscDays, RDiscDate, RDueDays, RDueDate, RApAcct, RApAcctUnit1, RApAcctUnit2, RApAcctUnit3, RApAcctUnit4, RApAcctDesc, rChartType, rAccessUnit1, rAccessUnit2, rAccessUnit3, rAccessUnit4, PPartOfEuro, POIncludeCost, Infobar, RApAcctIsControl);
            }
        }
    }
}
