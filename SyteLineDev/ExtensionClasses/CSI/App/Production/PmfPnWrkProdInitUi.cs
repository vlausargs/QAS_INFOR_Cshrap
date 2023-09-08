//PROJECT NAME: Production
//CLASS NAME: PmfPnWrkProdInitUi.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPmfPnWrkProdInitUi
	{
		(int? ReturnCode, string InfoBar, DateTime? TranDate, string JobDesc, string Lot, int? LotTrack, string Loc, decimal? Qty, string Um, decimal? QtyOrd, decimal? QtyComplete, decimal? QtyScrapped, decimal? QtyRem, string ContainerNum, string DocNo, string StockUm, string UserInstructions, int? OutputEntryEnabled, string DefWipItem) PmfPnWrkProdInitUiSp(string InfoBar = null,
		                                                                                                                                                                                                                                                                                                                                                                 Guid? PnRp = null,
		                                                                                                                                                                                                                                                                                                                                                                 Guid? JobRp = null,
		                                                                                                                                                                                                                                                                                                                                                                 DateTime? TranDate = null,
		                                                                                                                                                                                                                                                                                                                                                                 string JobDesc = null,
		                                                                                                                                                                                                                                                                                                                                                                 string Lot = null,
		                                                                                                                                                                                                                                                                                                                                                                 int? LotTrack = null,
		                                                                                                                                                                                                                                                                                                                                                                 string Loc = null,
		                                                                                                                                                                                                                                                                                                                                                                 decimal? Qty = null,
		                                                                                                                                                                                                                                                                                                                                                                 string Um = null,
		                                                                                                                                                                                                                                                                                                                                                                 decimal? QtyOrd = null,
		                                                                                                                                                                                                                                                                                                                                                                 decimal? QtyComplete = null,
		                                                                                                                                                                                                                                                                                                                                                                 decimal? QtyScrapped = null,
		                                                                                                                                                                                                                                                                                                                                                                 decimal? QtyRem = null,
		                                                                                                                                                                                                                                                                                                                                                                 string ContainerNum = null,
		                                                                                                                                                                                                                                                                                                                                                                 string DocNo = null,
		                                                                                                                                                                                                                                                                                                                                                                 string StockUm = null,
		                                                                                                                                                                                                                                                                                                                                                                 string UserInstructions = null,
		                                                                                                                                                                                                                                                                                                                                                                 int? OutputEntryEnabled = null,
		                                                                                                                                                                                                                                                                                                                                                                 string DefWipItem = null);
	}
	
	public class PmfPnWrkProdInitUi : IPmfPnWrkProdInitUi
	{
		readonly IApplicationDB appDB;
		
		public PmfPnWrkProdInitUi(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar, DateTime? TranDate, string JobDesc, string Lot, int? LotTrack, string Loc, decimal? Qty, string Um, decimal? QtyOrd, decimal? QtyComplete, decimal? QtyScrapped, decimal? QtyRem, string ContainerNum, string DocNo, string StockUm, string UserInstructions, int? OutputEntryEnabled, string DefWipItem) PmfPnWrkProdInitUiSp(string InfoBar = null,
		                                                                                                                                                                                                                                                                                                                                                                        Guid? PnRp = null,
		                                                                                                                                                                                                                                                                                                                                                                        Guid? JobRp = null,
		                                                                                                                                                                                                                                                                                                                                                                        DateTime? TranDate = null,
		                                                                                                                                                                                                                                                                                                                                                                        string JobDesc = null,
		                                                                                                                                                                                                                                                                                                                                                                        string Lot = null,
		                                                                                                                                                                                                                                                                                                                                                                        int? LotTrack = null,
		                                                                                                                                                                                                                                                                                                                                                                        string Loc = null,
		                                                                                                                                                                                                                                                                                                                                                                        decimal? Qty = null,
		                                                                                                                                                                                                                                                                                                                                                                        string Um = null,
		                                                                                                                                                                                                                                                                                                                                                                        decimal? QtyOrd = null,
		                                                                                                                                                                                                                                                                                                                                                                        decimal? QtyComplete = null,
		                                                                                                                                                                                                                                                                                                                                                                        decimal? QtyScrapped = null,
		                                                                                                                                                                                                                                                                                                                                                                        decimal? QtyRem = null,
		                                                                                                                                                                                                                                                                                                                                                                        string ContainerNum = null,
		                                                                                                                                                                                                                                                                                                                                                                        string DocNo = null,
		                                                                                                                                                                                                                                                                                                                                                                        string StockUm = null,
		                                                                                                                                                                                                                                                                                                                                                                        string UserInstructions = null,
		                                                                                                                                                                                                                                                                                                                                                                        int? OutputEntryEnabled = null,
		                                                                                                                                                                                                                                                                                                                                                                        string DefWipItem = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			RowPointerType _JobRp = JobRp;
			DateTimeType _TranDate = TranDate;
			StringType _JobDesc = JobDesc;
			LotType _Lot = Lot;
			IntType _LotTrack = LotTrack;
			LocType _Loc = Loc;
			ProcessMfgQuantityType _Qty = Qty;
			UMType _Um = Um;
			ProcessMfgQuantityType _QtyOrd = QtyOrd;
			ProcessMfgQuantityType _QtyComplete = QtyComplete;
			ProcessMfgQuantityType _QtyScrapped = QtyScrapped;
			ProcessMfgQuantityType _QtyRem = QtyRem;
			ContainerType _ContainerNum = ContainerNum;
			DocumentNumType _DocNo = DocNo;
			UMType _StockUm = StockUm;
			StringType _UserInstructions = UserInstructions;
			IntType _OutputEntryEnabled = OutputEntryEnabled;
			ItemType _DefWipItem = DefWipItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfPnWrkProdInitUiSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRp", _JobRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranDate", _TranDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobDesc", _JobDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTrack", _LotTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Um", _Um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOrd", _QtyOrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyScrapped", _QtyScrapped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRem", _QtyRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocNo", _DocNo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StockUm", _StockUm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserInstructions", _UserInstructions, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutputEntryEnabled", _OutputEntryEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefWipItem", _DefWipItem, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				TranDate = _TranDate;
				JobDesc = _JobDesc;
				Lot = _Lot;
				LotTrack = _LotTrack;
				Loc = _Loc;
				Qty = _Qty;
				Um = _Um;
				QtyOrd = _QtyOrd;
				QtyComplete = _QtyComplete;
				QtyScrapped = _QtyScrapped;
				QtyRem = _QtyRem;
				ContainerNum = _ContainerNum;
				DocNo = _DocNo;
				StockUm = _StockUm;
				UserInstructions = _UserInstructions;
				OutputEntryEnabled = _OutputEntryEnabled;
				DefWipItem = _DefWipItem;
				
				return (Severity, InfoBar, TranDate, JobDesc, Lot, LotTrack, Loc, Qty, Um, QtyOrd, QtyComplete, QtyScrapped, QtyRem, ContainerNum, DocNo, StockUm, UserInstructions, OutputEntryEnabled, DefWipItem);
			}
		}
	}
}
