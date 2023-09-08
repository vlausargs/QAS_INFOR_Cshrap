//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPeriodsCompare.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBPeriodsCompare : IMultiFSBPeriodsCompare
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBPeriodsCompare(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) MultiFSBPeriodsCompareSp(
			string PeriodName = null,
			string Site = null,
			string CutOffDateLabel = null,
			DateTime? CutOffDate = null,
			string CtaDateLabel = null,
			DateTime? CtaDate = null,
			string Function = null,
			string PromptMsg = null,
			string PromptButtons = null,
			string Infobar = null)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			SiteType _Site = Site;
			LongListType _CutOffDateLabel = CutOffDateLabel;
			DateType _CutOffDate = CutOffDate;
			LongListType _CtaDateLabel = CtaDateLabel;
			DateType _CtaDate = CtaDate;
			LongListType _Function = Function;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBPeriodsCompareSp";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDateLabel", _CutOffDateLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CtaDateLabel", _CtaDateLabel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CtaDate", _CtaDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Function", _Function, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
