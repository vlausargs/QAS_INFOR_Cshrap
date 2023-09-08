//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROLaborDCCheck
	{
		(int? ReturnCode, string SroNum, int? SroLine, int? SroOper, DateTime? StartDate, string Infobar) SSSFSSROLaborDCCheckSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		DateTime? StartDate,
		string Infobar = null);
	}
	
	public class SSSFSSROLaborDCCheck : ISSSFSSROLaborDCCheck
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROLaborDCCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SroNum, int? SroLine, int? SroOper, DateTime? StartDate, string Infobar) SSSFSSROLaborDCCheckSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		DateTime? StartDate,
		string Infobar = null)
		{
			FSPartnerType _PartnerId = PartnerId;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateType _StartDate = StartDate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROLaborDCCheckSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SroNum = _SroNum;
				SroLine = _SroLine;
				SroOper = _SroOper;
				StartDate = _StartDate;
				Infobar = _Infobar;
				
				return (Severity, SroNum, SroLine, SroOper, StartDate, Infobar);
			}
		}
	}
}
