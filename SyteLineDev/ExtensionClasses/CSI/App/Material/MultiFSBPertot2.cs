//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPertot2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBPertot2 : IMultiFSBPertot2
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBPertot2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MultiFSBPertot2Sp(
			int? BegSort,
			int? EndSort,
			int? Activeonly,
			string FSBName,
			string Infobar)
		{
			SortMethodType _BegSort = BegSort;
			SortMethodType _EndSort = EndSort;
			ListYesNoType _Activeonly = Activeonly;
			FSBNameType _FSBName = FSBName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBPertot2Sp";
				
				appDB.AddCommandParameter(cmd, "BegSort", _BegSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSort", _EndSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Activeonly", _Activeonly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
