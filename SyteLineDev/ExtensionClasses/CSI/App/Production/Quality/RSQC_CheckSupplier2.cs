//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckSupplier2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckSupplier2 : IRSQC_CheckSupplier2
	{
		readonly IApplicationDB appDB;
		
		public RSQC_CheckSupplier2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? AutoAccept,
			int? NeedsQC,
			string EndingLoc,
			string Infobar) RSQC_CheckSupplier2Sp(
			string Item,
			string VendNum,
			string Function,
			decimal? Qty,
			string StartingLoc,
			string Whse,
			int? AutoAccept,
			int? NeedsQC,
			string EndingLoc,
			string Infobar)
		{
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			DescriptionType _Function = Function;
			QtyUnitType _Qty = Qty;
			LocType _StartingLoc = StartingLoc;
			WhseType _Whse = Whse;
			ListYesNoType _AutoAccept = AutoAccept;
			ListYesNoType _NeedsQC = NeedsQC;
			LocType _EndingLoc = EndingLoc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CheckSupplier2Sp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Function", _Function, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLoc", _StartingLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoAccept", _AutoAccept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NeedsQC", _NeedsQC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndingLoc", _EndingLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AutoAccept = _AutoAccept;
				NeedsQC = _NeedsQC;
				EndingLoc = _EndingLoc;
				Infobar = _Infobar;
				
				return (Severity, AutoAccept, NeedsQC, EndingLoc, Infobar);
			}
		}
	}
}
