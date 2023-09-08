//PROJECT NAME: Production
//CLASS NAME: ProcessBatchedJobMatlTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ProcessBatchedJobMatlTrans : IProcessBatchedJobMatlTrans
	{
		readonly IApplicationDB appDB;
		
		
		public ProcessBatchedJobMatlTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProcessBatchedJobMatlTransSp(string Site,
		Guid? RowPointer,
		int? ProdBatchId,
		string JobmatlItem,
		int? SerialTracked,
		int? ExtScrap,
		string CurWhse,
		int? ShowBFlushMatls,
		string ContainerNum,
		decimal? ItemQty,
		string Loc,
		string Lot,
		string UM,
		DateTime? TransDate,
		DateTime? RecordDate = null,
		string EmpNum = null,
		string Infobar = null,
		string DocumentNum = null)
		{
			SiteType _Site = Site;
			RowPointerType _RowPointer = RowPointer;
			ApsBatchNumberType _ProdBatchId = ProdBatchId;
			ItemType _JobmatlItem = JobmatlItem;
			ListYesNoType _SerialTracked = SerialTracked;
			ListYesNoType _ExtScrap = ExtScrap;
			WhseType _CurWhse = CurWhse;
			ListYesNoType _ShowBFlushMatls = ShowBFlushMatls;
			ContainerNumType _ContainerNum = ContainerNum;
			QtyPerType _ItemQty = ItemQty;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			UMType _UM = UM;
			DateType _TransDate = TransDate;
			CurrentDateType _RecordDate = RecordDate;
			EmpNumType _EmpNum = EmpNum;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessBatchedJobMatlTransSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdBatchId", _ProdBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlItem", _JobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtScrap", _ExtScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowBFlushMatls", _ShowBFlushMatls, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQty", _ItemQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
