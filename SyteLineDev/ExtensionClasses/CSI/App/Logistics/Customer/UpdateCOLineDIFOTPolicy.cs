//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCOLineDIFOTPolicy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IUpdateCOLineDIFOTPolicy
    {
        DataTable UpdateCOLineDIFOTPolicySp(string StartCustNum,
                                            string EndCustNum,
                                            int? StartCustSeq,
                                            int? EndCustSeq,
                                            string StartOrder,
                                            string EndOrder,
                                            short? StartLine,
                                            short? EndLine,
                                            short? StartRelease,
                                            short? EndRelease,
                                            DateTime? StartShipDate,
                                            DateTime? EndShipDate,
                                            DateTime? StartDueDate,
                                            DateTime? EndDueDate,
                                            byte? OrderedStat,
                                            byte? PlannedStat,
                                            byte? CompleteStat,
                                            byte? FilledStat,
                                            decimal? QtyOver,
                                            decimal? QtyUnder,
                                            short? DaysAfter,
                                            short? DaysBefore,
                                            string PProcess,
                                            ref string Infobar);
    }

    public class UpdateCOLineDIFOTPolicy : IUpdateCOLineDIFOTPolicy
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public UpdateCOLineDIFOTPolicy(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable UpdateCOLineDIFOTPolicySp(string StartCustNum,
                                                   string EndCustNum,
                                                   int? StartCustSeq,
                                                   int? EndCustSeq,
                                                   string StartOrder,
                                                   string EndOrder,
                                                   short? StartLine,
                                                   short? EndLine,
                                                   short? StartRelease,
                                                   short? EndRelease,
                                                   DateTime? StartShipDate,
                                                   DateTime? EndShipDate,
                                                   DateTime? StartDueDate,
                                                   DateTime? EndDueDate,
                                                   byte? OrderedStat,
                                                   byte? PlannedStat,
                                                   byte? CompleteStat,
                                                   byte? FilledStat,
                                                   decimal? QtyOver,
                                                   decimal? QtyUnder,
                                                   short? DaysAfter,
                                                   short? DaysBefore,
                                                   string PProcess,
                                                   ref string Infobar)
        {
            CustNumType _StartCustNum = StartCustNum;
            CustNumType _EndCustNum = EndCustNum;
            CustSeqType _StartCustSeq = StartCustSeq;
            CustSeqType _EndCustSeq = EndCustSeq;
            CoNumType _StartOrder = StartOrder;
            CoNumType _EndOrder = EndOrder;
            CoLineType _StartLine = StartLine;
            CoLineType _EndLine = EndLine;
            CoReleaseType _StartRelease = StartRelease;
            CoReleaseType _EndRelease = EndRelease;
            DateType _StartShipDate = StartShipDate;
            DateType _EndShipDate = EndShipDate;
            DateType _StartDueDate = StartDueDate;
            DateType _EndDueDate = EndDueDate;
            ListYesNoType _OrderedStat = OrderedStat;
            ListYesNoType _PlannedStat = PlannedStat;
            ListYesNoType _CompleteStat = CompleteStat;
            ListYesNoType _FilledStat = FilledStat;
            TolerancePercentType _QtyOver = QtyOver;
            TolerancePercentType _QtyUnder = QtyUnder;
            ToleranceDaysType _DaysAfter = DaysAfter;
            ToleranceDaysType _DaysBefore = DaysBefore;
            LongListType _PProcess = PProcess;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCOLineDIFOTPolicySp";

                appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartCustSeq", _StartCustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndCustSeq", _EndCustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartOrder", _StartOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndOrder", _EndOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartRelease", _StartRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndRelease", _EndRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartShipDate", _StartShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndShipDate", _EndShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDueDate", _StartDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDueDate", _EndDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderedStat", _OrderedStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlannedStat", _PlannedStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CompleteStat", _CompleteStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FilledStat", _FilledStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyOver", _QtyOver, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyUnder", _QtyUnder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DaysAfter", _DaysAfter, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;

                return dtReturn;
            }
        }
    }
}
