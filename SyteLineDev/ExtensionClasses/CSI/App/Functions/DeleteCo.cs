//PROJECT NAME: Data
//CLASS NAME: DeleteCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteCo : IDeleteCo
	{
		readonly IApplicationDB appDB;
		
		public DeleteCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteCoSp(
			string CoNum,
			int? RepFromTrigger = 0,
			string RepFromSite = null)
		{
			CoNumType _CoNum = CoNum;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteCoSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
