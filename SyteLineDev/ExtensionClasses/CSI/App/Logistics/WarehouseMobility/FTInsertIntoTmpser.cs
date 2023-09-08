//PROJECT NAME: Logistics
//CLASS NAME: FTInsertIntoTmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTInsertIntoTmpser : IFTInsertIntoTmpser
	{
		readonly IApplicationDB appDB;
		
		
		public FTInsertIntoTmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTInsertIntoTmpserSp(Guid? SessionID,
		string Ser_num,
		string RefStr,
		string Item,
		int? FlagInvCheck,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			SerNumType _Ser_num = Ser_num;
			NameType _RefStr = RefStr;
			ItemType _Item = Item;
			ListYesNoType _FlagInvCheck = FlagInvCheck;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTInsertIntoTmpserSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ser_num", _Ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagInvCheck", _FlagInvCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
