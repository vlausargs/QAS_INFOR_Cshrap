//PROJECT NAME: Data
//CLASS NAME: THAApptcvdb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcvdb : ITHAApptcvdb
	{
		readonly IApplicationDB appDB;
		
		public THAApptcvdb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) THAApptcvdbSp(
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
				cmd.CommandText = "THAApptcvdbSp";
				
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
