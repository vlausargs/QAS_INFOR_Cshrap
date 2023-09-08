//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDrpGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSDrpGen : ISSSFSDrpGen
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSDrpGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSDrpGenSp(string FormCaption,
		int? BgTaskID,
		string Infobar,
		int? kDebugLevel = 0,
		int? kDebugQty = 0,
		string StartingItem = null,
		string EndingItem = null)
		{
			LongListType _FormCaption = FormCaption;
			GenericNoType _BgTaskID = BgTaskID;
			Infobar _Infobar = Infobar;
			ShortType _kDebugLevel = kDebugLevel;
			ShortType _kDebugQty = kDebugQty;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDrpGenSp";
				
				appDB.AddCommandParameter(cmd, "FormCaption", _FormCaption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "kDebugLevel", _kDebugLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "kDebugQty", _kDebugQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
