//PROJECT NAME: Finance
//CLASS NAME: EXTCHSPertot2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSPertot2 : IEXTCHSPertot2
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSPertot2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSPertot2Sp(
			int? BegSort,
			int? EndSort,
			int? ActiveOnly,
			string Infobar)
		{
			SortMethodType _BegSort = BegSort;
			SortMethodType _EndSort = EndSort;
			IntType _ActiveOnly = ActiveOnly;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSPertot2Sp";
				
				appDB.AddCommandParameter(cmd, "BegSort", _BegSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSort", _EndSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveOnly", _ActiveOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
