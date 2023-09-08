//PROJECT NAME: Data
//CLASS NAME: EXTSSSOPMSkipClrXrefCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSOPMSkipClrXrefCheck : IEXTSSSOPMSkipClrXrefCheck
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSOPMSkipClrXrefCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SkipClrXref,
			string Infobar) EXTSSSOPMSkipClrXrefCheckSp(
			int? SkipClrXref,
			string Infobar)
		{
			ListYesNoType _SkipClrXref = SkipClrXref;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSOPMSkipClrXrefCheckSp";
				
				appDB.AddCommandParameter(cmd, "SkipClrXref", _SkipClrXref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SkipClrXref = _SkipClrXref;
				Infobar = _Infobar;
				
				return (Severity, SkipClrXref, Infobar);
			}
		}
	}
}
