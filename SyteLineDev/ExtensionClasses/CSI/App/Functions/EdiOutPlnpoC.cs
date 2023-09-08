//PROJECT NAME: Data
//CLASS NAME: EdiOutPlnpoC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutPlnpoC : IEdiOutPlnpoC
	{
		readonly IApplicationDB appDB;
		
		public EdiOutPlnpoC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? RecCount,
			string Infobar) EdiOutPlnpoCSp(
			Guid? PItemVendRecid,
			int? RecCount,
			string Infobar)
		{
			RowPointerType _PItemVendRecid = PItemVendRecid;
			IntType _RecCount = RecCount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutPlnpoCSp";
				
				appDB.AddCommandParameter(cmd, "PItemVendRecid", _PItemVendRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecCount", _RecCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RecCount = _RecCount;
				Infobar = _Infobar;
				
				return (Severity, RecCount, Infobar);
			}
		}
	}
}
