//PROJECT NAME: CSIMaterial
//CLASS NAME: DefaultInventoryTags.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IDefaultInventoryTags
	{
		int DefaultInventoryTagsSp(string PWhse,
		                           ref int? PStartingTagNum,
		                           ref int? PEndingTagNum,
		                           ref string Infobar);
	}
	
	public class DefaultInventoryTags : IDefaultInventoryTags
	{
		readonly IApplicationDB appDB;
		
		public DefaultInventoryTags(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DefaultInventoryTagsSp(string PWhse,
		                                  ref int? PStartingTagNum,
		                                  ref int? PEndingTagNum,
		                                  ref string Infobar)
		{
			WhseType _PWhse = PWhse;
			SheetTagNumType _PStartingTagNum = PStartingTagNum;
			SheetTagNumType _PEndingTagNum = PEndingTagNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DefaultInventoryTagsSp";
				
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingTagNum", _PStartingTagNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndingTagNum", _PEndingTagNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartingTagNum = _PStartingTagNum;
				PEndingTagNum = _PEndingTagNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
