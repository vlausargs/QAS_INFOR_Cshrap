//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessReqLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessReqLine : ILoadProcessReqLine
	{
		readonly IApplicationDB appDB;
		
		
		public LoadProcessReqLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadProcessReqLineSp(string LineReqNum,
		int? ReqLine,
		string ActionCode,
		string Item,
		string Description,
		decimal? QtyOrderedConv,
		string UM,
		decimal? UnitMatCostConv,
		string CurrCode,
		DateTime? DueDate,
		string Whse,
		string VendNum,
		string Infobar)
		{
			ReqNumType _LineReqNum = LineReqNum;
			PoLineType _ReqLine = ReqLine;
			StringType _ActionCode = ActionCode;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			UMType _UM = UM;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CurrCodeType _CurrCode = CurrCode;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			VendNumType _VendNum = VendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessReqLineSp";
				
				appDB.AddCommandParameter(cmd, "LineReqNum", _LineReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReqLine", _ReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
