//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToP : IChangeReportsToP
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeReportsToPSp(
			int? PRecover,
			int? PWasBlank,
			DateTime? PEffectiveDate,
			DateTime? PCtaDate,
			int? PSummaryOrDetail,
			string PSiteName,
			string Infobar)
		{
			FlagNyType _PRecover = PRecover;
			FlagNyType _PWasBlank = PWasBlank;
			CurrentDateType _PEffectiveDate = PEffectiveDate;
			CurrentDateType _PCtaDate = PCtaDate;
			FlagNyType _PSummaryOrDetail = PSummaryOrDetail;
			NameType _PSiteName = PSiteName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToPSp";
				
				appDB.AddCommandParameter(cmd, "PRecover", _PRecover, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWasBlank", _PWasBlank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEffectiveDate", _PEffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCtaDate", _PCtaDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSummaryOrDetail", _PSummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteName", _PSiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
