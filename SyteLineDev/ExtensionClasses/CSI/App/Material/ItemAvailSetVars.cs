//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemAvailSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemAvailSetVars
	{
		(int? ReturnCode, string Infobar) ItemAvailSetVarsSp(string SET = null,
		string SiteRef = null,
		string Infobar = null);
	}
	
	public class ItemAvailSetVars : IItemAvailSetVars
	{
		readonly IApplicationDB appDB;
		
		public ItemAvailSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemAvailSetVarsSp(string SET = null,
		string SiteRef = null,
		string Infobar = null)
		{
			ProcessIndType _SET = SET;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemAvailSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
