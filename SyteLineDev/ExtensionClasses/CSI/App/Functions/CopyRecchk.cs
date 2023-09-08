//PROJECT NAME: Data
//CLASS NAME: CopyRecchk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyRecchk : ICopyRecchk
	{
		readonly IApplicationDB appDB;
		
		public CopyRecchk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CopyRecchkSp(
			string FromItem,
			string ToItem,
			int? FromSuffix,
			string Infobar)
		{
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			SuffixType _FromSuffix = FromSuffix;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyRecchkSp";
				
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
