//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgReplaceSheet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IChgReplaceSheet
	{
		int ChgReplaceSheetSp(string Whse,
		                      int? SheetNum,
		                      short? Increment,
		                      ref string Infobar);
	}
	
	public class ChgReplaceSheet : IChgReplaceSheet
	{
		readonly IApplicationDB appDB;
		
		public ChgReplaceSheet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ChgReplaceSheetSp(string Whse,
		                             int? SheetNum,
		                             short? Increment,
		                             ref string Infobar)
		{
			WhseType _Whse = Whse;
			SheetTagNumType _SheetNum = SheetNum;
			SheetTagIncrementType _Increment = Increment;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChgReplaceSheetSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SheetNum", _SheetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Increment", _Increment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
