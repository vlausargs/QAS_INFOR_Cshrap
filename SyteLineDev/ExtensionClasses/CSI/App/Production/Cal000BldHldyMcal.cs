//PROJECT NAME: Production
//CLASS NAME: Cal000BldHldyMcal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Cal000BldHldyMcal : ICal000BldHldyMcal
	{
		readonly IApplicationDB appDB;
		
		
		public Cal000BldHldyMcal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) Cal000BldHldyMcalSp(int? PTSfcFlag,
		DateTime? PTMdayDate,
		int? AltNo,
		string Infobar)
		{
			ListYesNoType _PTSfcFlag = PTSfcFlag;
			DateType _PTMdayDate = PTMdayDate;
			ApsAltNoType _AltNo = AltNo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Cal000BldHldyMcalSp";
				
				appDB.AddCommandParameter(cmd, "PTSfcFlag", _PTSfcFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTMdayDate", _PTMdayDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
