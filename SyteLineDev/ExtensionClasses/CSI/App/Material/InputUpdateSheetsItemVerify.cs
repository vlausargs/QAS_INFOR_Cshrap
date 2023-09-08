//PROJECT NAME: Material
//CLASS NAME: InputUpdateSheetsItemVerify.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class InputUpdateSheetsItemVerify : IInputUpdateSheetsItemVerify
	{
		readonly IApplicationDB appDB;
		
		
		public InputUpdateSheetsItemVerify(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InputUpdateSheetsItemVerifySp(string Item,
		string Infobar)
		{
			ItemType _Item = Item;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InputUpdateSheetsItemVerifySp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
