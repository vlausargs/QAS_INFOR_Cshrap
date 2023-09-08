//PROJECT NAME: Data
//CLASS NAME: TransDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TransDelete : ITransDelete
	{
		readonly IApplicationDB appDB;
		
		public TransDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TransDeleteSp(
			string PTrnNum,
			string FromSite,
			string ToSite,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null)
		{
			TrnNumType _PTrnNum = PTrnNum;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransDeleteSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
