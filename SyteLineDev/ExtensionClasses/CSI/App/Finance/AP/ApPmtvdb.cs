//PROJECT NAME: Finance
//CLASS NAME: ApPmtvdb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class ApPmtvdb : IApPmtvdb
	{
		readonly IApplicationDB appDB;
		
		public ApPmtvdb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ApPmtvdbSp(
			string PFromSite,
			string PToSite,
			Guid? PAppmtdRowPointer,
			string Infobar)
		{
			SiteType _PFromSite = PFromSite;
			SiteType _PToSite = PToSite;
			RowPointerType _PAppmtdRowPointer = PAppmtdRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApPmtvdbSp";
				
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtdRowPointer", _PAppmtdRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
