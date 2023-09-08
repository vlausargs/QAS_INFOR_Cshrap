//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedPartnerFilterDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedPartnerFilterDelete
	{
		(int? ReturnCode, string Infobar) SSSFSSchedPartnerFilterDeleteSp(string FilterName,
		string Username,
		string Infobar);
	}
	
	public class SSSFSSchedPartnerFilterDelete : ISSSFSSchedPartnerFilterDelete
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedPartnerFilterDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSchedPartnerFilterDeleteSp(string FilterName,
		string Username,
		string Infobar)
		{
			StringType _FilterName = FilterName;
			UsernameType _Username = Username;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedPartnerFilterDeleteSp";
				
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
