//PROJECT NAME: Finance
//CLASS NAME: CalcBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
    public class CalcBal : ICalcBal
    {
        readonly IApplicationDB appDB;


        public CalcBal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, decimal? Balance,
        string Infobar) CalcBalSp(string TMethod,
        int? TUse,
        DateTime? SDate,
        DateTime? EDate,
        string PHierarchy,
        string PAcct,
        string PAcctUnit1,
        string PAcctUnit2,
        string PAcctUnit3,
        string PAcctUnit4,
        string PSort,
        string PType,
        int? PIncome,
        string PBalType,
        string PCurrCode,
        int? PSortMethod,
        decimal? Balance,
        string Infobar,
        string pSite = null,
        DateTime? PeriodDateForStart = null,
        DateTime? PeriodDateForEnd = null,
        string CallFrom = null,
        DateTime? Today = null,
        DateTime? FirstPeriodPerStart = null,
        DateTime? LastPeriodPerEnd = null)
        {
            CurrTransMethodType _TMethod = TMethod;
            ListBuySellType _TUse = TUse;
            CurrentDateType _SDate = SDate;
            CurrentDateType _EDate = EDate;
            HierarchyType _PHierarchy = PHierarchy;
            AcctType _PAcct = PAcct;
            UnitCode1Type _PAcctUnit1 = PAcctUnit1;
            UnitCode2Type _PAcctUnit2 = PAcctUnit2;
            UnitCode3Type _PAcctUnit3 = PAcctUnit3;
            UnitCode4Type _PAcctUnit4 = PAcctUnit4;
            LongListType _PSort = PSort;
            ChartTypeType _PType = PType;
            FlagNyType _PIncome = PIncome;
            GlrptlBalTypeType _PBalType = PBalType;
            CurrCodeType _PCurrCode = PCurrCode;
            SortMethodType _PSortMethod = PSortMethod;
            GenericDecimalType _Balance = Balance;
            InfobarType _Infobar = Infobar;
            SiteType _pSite = pSite;
            DateType _PeriodDateForStart = PeriodDateForStart;
            DateType _PeriodDateForEnd = PeriodDateForEnd;
            LongListType _CallFrom = CallFrom;
            DateType _Today = Today;
            DateType _FirstPeriodPerStart = FirstPeriodPerStart;
            DateType _LastPeriodPerEnd = LastPeriodPerEnd;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CalcBalSp";

                appDB.AddCommandParameter(cmd, "TMethod", _TMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TUse", _TUse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SDate", _SDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EDate", _EDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSort", _PSort, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIncome", _PIncome, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBalType", _PBalType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSortMethod", _PSortMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PeriodDateForStart", _PeriodDateForStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PeriodDateForEnd", _PeriodDateForEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CallFrom", _CallFrom, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Today", _Today, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FirstPeriodPerStart", _FirstPeriodPerStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastPeriodPerEnd", _LastPeriodPerEnd, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Balance = _Balance;
                Infobar = _Infobar;

                return (Severity, Balance, Infobar);
            }
        }
    }
}
