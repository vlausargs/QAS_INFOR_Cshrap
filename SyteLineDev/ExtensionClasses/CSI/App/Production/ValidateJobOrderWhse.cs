//PROJECT NAME: Production
//CLASS NAME: ValidateJobOrderWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateJobOrderWhse : IValidateJobOrderWhse
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateJobOrderWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateJobOrderWhseSp(string PItem,
		string PWhse,
		int? PMultiWhse,
		string PDefWhse,
		string Infobar)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			ListYesNoType _PMultiWhse = PMultiWhse;
			WhseType _PDefWhse = PDefWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateJobOrderWhseSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMultiWhse", _PMultiWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDefWhse", _PDefWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
