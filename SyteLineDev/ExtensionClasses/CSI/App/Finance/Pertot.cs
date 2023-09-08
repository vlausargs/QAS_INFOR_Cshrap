//PROJECT NAME: Finance
//CLASS NAME: Pertot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class Pertot : IPertot
	{
		readonly IApplicationDB appDB;
		
		
		public Pertot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PertotSp(int? BegSort,
		int? EndSort,
		int? ActiveOnly,
		string Infobar,
		int? ChunkSize = null)
		{
			SortMethodType _BegSort = BegSort;
			SortMethodType _EndSort = EndSort;
			ListYesNoType _ActiveOnly = ActiveOnly;
			InfobarType _Infobar = Infobar;
			IntType _ChunkSize = ChunkSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PertotSp";
				
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
