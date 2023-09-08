//PROJECT NAME: Finance
//CLASS NAME: FRFecValidateParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FRFecValidateParms : IFRFecValidateParms
	{
		readonly IApplicationDB appDB;
		
		
		public FRFecValidateParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PPrintFinal,
		DateTime? PEndDate,
		int? PPeriod,
		int? PPromptFlag,
		string Infobar) FRFecValidateParmsSp(int? PYear,
		int? PPrintFinal,
		DateTime? PEndDate,
		int? PPeriod,
		int? PPromptFlag,
		string Infobar)
		{
			ShortType _PYear = PYear;
			ListYesNoType _PPrintFinal = PPrintFinal;
			DateType _PEndDate = PEndDate;
			ByteType _PPeriod = PPeriod;
			ListYesNoType _PPromptFlag = PPromptFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FRFecValidateParmsSp";
				
				appDB.AddCommandParameter(cmd, "PYear", _PYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintFinal", _PPrintFinal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPromptFlag", _PPromptFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPrintFinal = _PPrintFinal;
				PEndDate = _PEndDate;
				PPeriod = _PPeriod;
				PPromptFlag = _PPromptFlag;
				Infobar = _Infobar;
				
				return (Severity, PPrintFinal, PEndDate, PPeriod, PPromptFlag, Infobar);
			}
		}
	}
}
