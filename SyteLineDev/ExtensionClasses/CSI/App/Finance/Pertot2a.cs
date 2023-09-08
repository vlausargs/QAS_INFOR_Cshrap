//PROJECT NAME: Finance
//CLASS NAME: Pertot2a.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class Pertot2a : IPertot2a
	{
		readonly IApplicationDB appDB;
		
		public Pertot2a(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Pertot2aSp(
			int? BegSort,
			int? EndSort,
			int? ActiveOnly,
			string Infobar,
			int? ChunkSize)
		{
			SortMethodType _BegSort = BegSort;
			SortMethodType _EndSort = EndSort;
			ListYesNoType _ActiveOnly = ActiveOnly;
			InfobarType _Infobar = Infobar;
			IntType _ChunkSize = ChunkSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pertot2aSp";
				
				appDB.AddCommandParameter(cmd, "BegSort", _BegSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSort", _EndSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveOnly", _ActiveOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ChunkSize", _ChunkSize, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
