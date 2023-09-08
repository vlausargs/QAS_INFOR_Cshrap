//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetProductionScheduleDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
    public interface IFTSLGetProductionScheduleDetails
    {
        (int? ReturnCode, string ItemDescription, string ItemUM, int? ItemLotTracked, int? ItemSerialTracked, string WcDescription, string Whse, string Loc, decimal? QtyExpected, decimal? QtyCompleted, decimal? QtyScrapped, decimal? QtyRemaining, string SymixJob, int? SymixSuffix, int? PSBehind, int? PSAhead, string Infobar) 
            FTSLGetProductionScheduleDetailsSp(string Item,
                                                        string PsNum,
                                                        string Wc,
                                                        int? OperNum,
                                                        DateTime? DueDate,
                                                        string ItemDescription,
                                                        string ItemUM,
                                                        int? ItemLotTracked,
                                                        int? ItemSerialTracked,
                                                        string WcDescription,
                                                        string Whse,
                                                        string Loc,
                                                        decimal? QtyExpected,
                                                        decimal? QtyCompleted,
                                                        decimal? QtyScrapped,
                                                        decimal? QtyRemaining,
                                                        string SymixJob,
                                                        int? SymixSuffix,
                                                        int? PSBehind,
                                                        int? PSAhead,
                                                        string Infobar);
    }

    public class FTSLGetProductionScheduleDetails : IFTSLGetProductionScheduleDetails
    {
        readonly IApplicationDB appDB;
        public FTSLGetProductionScheduleDetails(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string ItemDescription, string ItemUM, int? ItemLotTracked, int? ItemSerialTracked, string WcDescription, string Whse, string Loc, decimal? QtyExpected, decimal? QtyCompleted, decimal? QtyScrapped, decimal? QtyRemaining, string SymixJob, int? SymixSuffix, int? PSBehind, int? PSAhead, string Infobar) 
            FTSLGetProductionScheduleDetailsSp(string Item, string PsNum, string Wc, int? OperNum, DateTime? DueDate, string ItemDescription, string ItemUM, int? ItemLotTracked, int? ItemSerialTracked, string WcDescription, string Whse, string Loc, decimal? QtyExpected, decimal? QtyCompleted, decimal? QtyScrapped, decimal? QtyRemaining, string SymixJob, int? SymixSuffix, int? PSBehind, int? PSAhead, string Infobar)
        {
            ItemType _Item = Item;
            PsNumType _PsNum = PsNum;
            WcType _Wc = Wc;
            OperNumType _OperNum = OperNum;
            DateTimeType _DueDate = DueDate;
            DescriptionType _ItemDescription = ItemDescription;
            UMType _ItemUM = ItemUM;
            ListYesNoType _ItemLotTracked = ItemLotTracked;
            ListYesNoType _ItemSerialTracked = ItemSerialTracked;
            DescriptionType _WcDescription = WcDescription;
            WhseType _Whse = Whse;
            LocType _Loc = Loc;
            QtyTotlType _QtyExpected = QtyExpected;
            QtyTotlType _QtyCompleted = QtyCompleted;
            QtyTotlType _QtyScrapped = QtyScrapped;
            QtyTotlType _QtyRemaining = QtyRemaining;
            JobType _SymixJob = SymixJob;
            SuffixType _SymixSuffix = SymixSuffix;
            PlanFenceType _PSBehind = PSBehind;
            PlanFenceType _PSAhead = PSAhead;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FTSLGetProductionScheduleDetailsSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "WcDescription", _WcDescription, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "QtyExpected", _QtyExpected, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "QtyCompleted", _QtyCompleted, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "QtyRemaining", _QtyRemaining, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "SymixJob", _SymixJob, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "SymixSuffix", _SymixSuffix, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "PSBehind", _PSBehind, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "PSAhead", _PSAhead, ParameterDirection.Output);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Output);
                
                var Severity = appDB.ExecuteNonQuery(cmd);

                ItemDescription = _ItemDescription;
                ItemUM = _ItemUM;
                ItemLotTracked = _ItemLotTracked;
                ItemSerialTracked = _ItemSerialTracked;
                WcDescription = _WcDescription;
                Whse = _Whse;
                Loc = _Loc;
                QtyExpected = _QtyExpected;
                QtyCompleted = _QtyCompleted;
                QtyScrapped = _QtyScrapped;
                QtyRemaining = _QtyRemaining;
                SymixJob = _SymixJob;
                SymixSuffix = _SymixSuffix;
                PSBehind = _PSBehind;
                PSAhead = _PSAhead;
                Infobar = _Infobar;

                return (Severity, ItemDescription, ItemUM, ItemLotTracked, ItemSerialTracked, WcDescription, Whse, Loc, QtyExpected, QtyCompleted, QtyScrapped, QtyRemaining, SymixJob, SymixSuffix, PSBehind, PSAhead, Infobar);
            }
        }
    }
}
