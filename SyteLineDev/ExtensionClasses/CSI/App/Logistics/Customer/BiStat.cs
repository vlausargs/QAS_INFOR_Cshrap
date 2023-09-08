//PROJECT NAME: Logistics
//CLASS NAME: BiStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class BiStat : IBiStat
	{
		readonly IApplicationDB appDB;
		
		
		public BiStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BiStatSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string OldStat,
		string NewStat,
		string EdiCoStat,
		string EdiCoblnStat,
		string Item,
		string Whse,
		string RefType,
		decimal? QtyOrdered,
		decimal? OldQtyOrdered,
		decimal? QtyShipped,
		decimal? QtyInvoiced,
		int? UpdateFlag,
		string Infobar,
		int? SkipEdiStatusError = 0)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			EdiCoitemStatusType _OldStat = OldStat;
			EdiCoitemStatusType _NewStat = NewStat;
			EdiCoStatusType _EdiCoStat = EdiCoStat;
			CoBlnStatusType _EdiCoblnStat = EdiCoblnStat;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			RefTypeIJKPRTType _RefType = RefType;
			QtyUnitType _QtyOrdered = QtyOrdered;
			QtyUnitType _OldQtyOrdered = OldQtyOrdered;
			QtyUnitType _QtyShipped = QtyShipped;
			QtyUnitType _QtyInvoiced = QtyInvoiced;
			ListYesNoType _UpdateFlag = UpdateFlag;
			InfobarType _Infobar = Infobar;
			ListYesNoType _SkipEdiStatusError = SkipEdiStatusError;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BiStatSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStat", _OldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStat", _NewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiCoStat", _EdiCoStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EdiCoblnStat", _EdiCoblnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldQtyOrdered", _OldQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyInvoiced", _QtyInvoiced, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateFlag", _UpdateFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SkipEdiStatusError", _SkipEdiStatusError, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
