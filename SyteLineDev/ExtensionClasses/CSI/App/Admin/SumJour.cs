//PROJECT NAME: Admin
//CLASS NAME: SumJour.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class SumJour : ISumJour
	{
		IApplicationDB appDB;
		
		
		public SumJour(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SumJourSp(string Id,
		int? Repair)
		{
			JournalIdType _Id = Id;
			ListYesNoType _Repair = Repair;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumJourSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Repair", _Repair, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
