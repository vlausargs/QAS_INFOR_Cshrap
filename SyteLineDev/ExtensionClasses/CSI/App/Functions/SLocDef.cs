//PROJECT NAME: Data
//CLASS NAME: SLocDef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SLocDef : ISLocDef
	{
		readonly IApplicationDB appDB;
		
		public SLocDef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Lot,
			string Loc,
			string InfoBar,
			string ImportDocId) SLocDefSp(
			string Item,
			string Whse,
			string Lot,
			string Loc,
			string InfoBar,
			string ExportType,
			string ImportDocId)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			InfobarType _InfoBar = InfoBar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			ImportDocIdType _ImportDocId = ImportDocId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SLocDefSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Lot = _Lot;
				Loc = _Loc;
				InfoBar = _InfoBar;
				ImportDocId = _ImportDocId;
				
				return (Severity, Lot, Loc, InfoBar, ImportDocId);
			}
		}
	}
}
