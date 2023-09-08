//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransPostUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransPostUtil : ISSSFSSROTransPostUtil
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransPostUtil(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) SSSFSSROTransPostUtilSp(int? Commit = 0,
		int? Background = 0,
		string Type = "A",
		string StartSRONum = null,
		string EndSRONum = null,
		int? StartSROLine = null,
		int? EndSROLine = null,
		int? StartSROOper = null,
		int? EndSROOper = null,
		string StartSROType = null,
		string EndSROType = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null,
		int? StartTransDateOffset = null,
		int? EndTransDateOffset = null,
		string StartDept = null,
		string EndDept = null,
		string StartPartnerId = null,
		string EndPartnerId = null,
		string StartOperCode = null,
		string EndOperCode = null,
		string StartOperWhse = null,
		string EndOperWhse = null,
		string StartTransWhse = null,
		string EndTransWhse = null,
		string StartLoc = null,
		string EndLoc = null,
		int? InclMatl = 1,
		int? InclLabor = 1,
		int? InclMisc = 1,
		int? InclLineMatl = 1,
		string BillCodesList = "CNWRLU",
		string GenerateReport = "N",
		string ReportOrderBy = "S",
		string RequestingUser = null,
		string InfoBar = null,
		string StartDocumentNum = null,
		string EndDocumentNum = null)
		{
			ListYesNoType _Commit = Commit;
			ListYesNoType _Background = Background;
			FSSROTransTypeType _Type = Type;
			FSSRONumType _StartSRONum = StartSRONum;
			FSSRONumType _EndSRONum = EndSRONum;
			FSSROLineType _StartSROLine = StartSROLine;
			FSSROLineType _EndSROLine = EndSROLine;
			FSSROOperType _StartSROOper = StartSROOper;
			FSSROOperType _EndSROOper = EndSROOper;
			FSSROTypeType _StartSROType = StartSROType;
			FSSROTypeType _EndSROType = EndSROType;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			DateOffsetType _StartTransDateOffset = StartTransDateOffset;
			DateOffsetType _EndTransDateOffset = EndTransDateOffset;
			DeptType _StartDept = StartDept;
			DeptType _EndDept = EndDept;
			FSPartnerType _StartPartnerId = StartPartnerId;
			FSPartnerType _EndPartnerId = EndPartnerId;
			FSOperCodeType _StartOperCode = StartOperCode;
			FSOperCodeType _EndOperCode = EndOperCode;
			WhseType _StartOperWhse = StartOperWhse;
			WhseType _EndOperWhse = EndOperWhse;
			WhseType _StartTransWhse = StartTransWhse;
			WhseType _EndTransWhse = EndTransWhse;
			LocType _StartLoc = StartLoc;
			LocType _EndLoc = EndLoc;
			ListYesNoType _InclMatl = InclMatl;
			ListYesNoType _InclLabor = InclLabor;
			ListYesNoType _InclMisc = InclMisc;
			ListYesNoType _InclLineMatl = InclLineMatl;
			StringType _BillCodesList = BillCodesList;
			StringType _GenerateReport = GenerateReport;
			StringType _ReportOrderBy = ReportOrderBy;
			StringType _RequestingUser = RequestingUser;
			InfobarType _InfoBar = InfoBar;
			DocumentNumType _StartDocumentNum = StartDocumentNum;
			DocumentNumType _EndDocumentNum = EndDocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransPostUtilSp";
				
				appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Background", _Background, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSRONum", _StartSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSRONum", _EndSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROLine", _StartSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROLine", _EndSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROOper", _StartSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROOper", _EndSROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSROType", _StartSROType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSROType", _EndSROType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDateOffset", _StartTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDateOffset", _EndTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDept", _StartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDept", _EndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartPartnerId", _StartPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPartnerId", _EndPartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOperCode", _StartOperCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOperCode", _EndOperCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOperWhse", _StartOperWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOperWhse", _EndOperWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransWhse", _StartTransWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransWhse", _EndTransWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLoc", _StartLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLoc", _EndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclMatl", _InclMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclLabor", _InclLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclMisc", _InclMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclLineMatl", _InclLineMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillCodesList", _BillCodesList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateReport", _GenerateReport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportOrderBy", _ReportOrderBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequestingUser", _RequestingUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartDocumentNum", _StartDocumentNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDocumentNum", _EndDocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
