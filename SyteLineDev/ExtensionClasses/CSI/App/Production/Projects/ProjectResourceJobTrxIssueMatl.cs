//PROJECT NAME: Production
//CLASS NAME: ProjectResourceJobTrxIssueMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjectResourceJobTrxIssueMatl : IProjectResourceJobTrxIssueMatl
	{
		readonly IApplicationDB appDB;
		
		public ProjectResourceJobTrxIssueMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjectResourceJobTrxIssueMatlSp(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSequence,
			string PItem,
			decimal? PQty,
			string CurWhse,
			string PLoc1,
			string PLot1,
			DateTime? PTransDate,
			string PTranType,
			string PRefType,
			string CallArg = "",
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			string PImportDocId1 = null,
			string DocumentNum = null)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSequence = PSequence;
			ItemType _PItem = PItem;
			QtyUnitType _PQty = PQty;
			WhseType _CurWhse = CurWhse;
			LocType _PLoc1 = PLoc1;
			LotType _PLot1 = PLot1;
			DateType _PTransDate = PTransDate;
			MatlTransTypeType _PTranType = PTranType;
			RefTypeIJKOTType _PRefType = PRefType;
			InfobarType _CallArg = CallArg;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId1 = PImportDocId1;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjectResourceJobTrxIssueMatlSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSequence", _PSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc1", _PLoc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot1", _PLot1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTranType", _PTranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallArg", _CallArg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId1", _PImportDocId1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
