//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROInv : ISSSFSSROInv
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string StartInvNum,
		string EndInvNum,
		string Infobar) SSSFSSROInvSp(string PMode,
		string PBegSroNum,
		string PEndSroNum,
		int? PBegSroLine,
		int? PEndSroLine,
		int? PBegSroOper,
		int? PEndSroOper,
		string PBegBillMgr,
		string PEndBillMgr,
		string PBegCustNum,
		string PEndCustNum,
		string PBegRegion,
		string PEndRegion,
		DateTime? PBegTransDate,
		DateTime? PEndTransDate,
		DateTime? PBegCloseDate,
		DateTime? PEndCloseDate,
		int? PInclCalculated,
		int? PInclProject,
		string PInvCred,
		DateTime? PInvDate,
		int? PTransDom,
		string SortBy = "S",
		int? InclBillHold = 0,
		string OperationStatus = "I",
		string StartInvNum = null,
		string EndInvNum = null,
		string Infobar = null)
		{
			StringType _PMode = PMode;
			FSSRONumType _PBegSroNum = PBegSroNum;
			FSSRONumType _PEndSroNum = PEndSroNum;
			FSSROLineType _PBegSroLine = PBegSroLine;
			FSSROLineType _PEndSroLine = PEndSroLine;
			FSSROOperType _PBegSroOper = PBegSroOper;
			FSSROOperType _PEndSroOper = PEndSroOper;
			FSPartnerType _PBegBillMgr = PBegBillMgr;
			FSPartnerType _PEndBillMgr = PEndBillMgr;
			CustNumType _PBegCustNum = PBegCustNum;
			CustNumType _PEndCustNum = PEndCustNum;
			FSRegionType _PBegRegion = PBegRegion;
			FSRegionType _PEndRegion = PEndRegion;
			DateType _PBegTransDate = PBegTransDate;
			DateType _PEndTransDate = PEndTransDate;
			CurrentDateType _PBegCloseDate = PBegCloseDate;
			CurrentDateType _PEndCloseDate = PEndCloseDate;
			ListYesNoType _PInclCalculated = PInclCalculated;
			ListYesNoType _PInclProject = PInclProject;
			LongListType _PInvCred = PInvCred;
			DateType _PInvDate = PInvDate;
			ListYesNoType _PTransDom = PTransDom;
			StringType _SortBy = SortBy;
			ListYesNoType _InclBillHold = InclBillHold;
			StringType _OperationStatus = OperationStatus;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSp";
				
				appDB.AddCommandParameter(cmd, "PMode", _PMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroNum", _PBegSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroNum", _PEndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroLine", _PBegSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroLine", _PEndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegSroOper", _PBegSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndSroOper", _PEndSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegBillMgr", _PBegBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndBillMgr", _PEndBillMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegCustNum", _PBegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustNum", _PEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegRegion", _PBegRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndRegion", _PEndRegion, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegTransDate", _PBegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTransDate", _PEndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBegCloseDate", _PBegCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCloseDate", _PEndCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclCalculated", _PInclCalculated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInclProject", _PInclProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvCred", _PInvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDom", _PTransDom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationStatus", _OperationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartInvNum = _StartInvNum;
				EndInvNum = _EndInvNum;
				Infobar = _Infobar;
				
				return (Severity, StartInvNum, EndInvNum, Infobar);
			}
		}
	}
}
