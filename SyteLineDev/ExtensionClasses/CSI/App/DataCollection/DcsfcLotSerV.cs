//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcLotSerV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcsfcLotSerV : IDcsfcLotSerV
	{
		readonly IApplicationDB appDB;
		
		public DcsfcLotSerV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar,
			string NewLot) DcsfcLotSerVSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			decimal? PQty,
			int? PIssue,
			int? PItemLotTracked,
			int? PItemSerialTracked,
			int? POverride,
			int? CanOverride,
			string Infobar,
			string NewLot = null)
		{
			WhseType _PWhse = PWhse;
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			QtyUnitType _PQty = PQty;
			ListYesNoType _PIssue = PIssue;
			ListYesNoType _PItemLotTracked = PItemLotTracked;
			ListYesNoType _PItemSerialTracked = PItemSerialTracked;
			ListYesNoType _POverride = POverride;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			LotType _NewLot = NewLot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcLotSerVSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIssue", _PIssue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemLotTracked", _PItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemSerialTracked", _PItemSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POverride", _POverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanOverride", _CanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewLot", _NewLot, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanOverride = _CanOverride;
				Infobar = _Infobar;
				NewLot = _NewLot;
				
				return (Severity, CanOverride, Infobar, NewLot);
			}
		}
	}
}
