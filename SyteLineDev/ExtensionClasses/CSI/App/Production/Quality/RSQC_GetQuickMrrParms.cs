//PROJECT NAME: Production
//CLASS NAME: RSQC_GetQuickMrrParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetQuickMrrParms : IRSQC_GetQuickMrrParms
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetQuickMrrParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? QuickQCSAllow,
		string QuickAutoCreateMrr,
		string QuickMrrReasonCode,
		int? QuickCreateItem,
		string QuickItemInspFreqId,
		string QuickItemAlert,
		int? QuickQCSAllowIP,
		string QuickAutoCreateMrrIP,
		string QuickMrrReasonCodeIP,
		int? QuickCreateItemIP,
		string QuickItemInspFreqIdIP,
		string QuickItemAlertIP,
		string QuickItemTestTypeIP,
		int? QuickItemTestSeqIP) RSQC_GetQuickMrrParmsSp(int? QuickQCSAllow,
		string QuickAutoCreateMrr,
		string QuickMrrReasonCode,
		int? QuickCreateItem,
		string QuickItemInspFreqId,
		string QuickItemAlert,
		int? QuickQCSAllowIP,
		string QuickAutoCreateMrrIP,
		string QuickMrrReasonCodeIP,
		int? QuickCreateItemIP,
		string QuickItemInspFreqIdIP,
		string QuickItemAlertIP,
		string QuickItemTestTypeIP,
		int? QuickItemTestSeqIP)
		{
			ListYesNoType _QuickQCSAllow = QuickQCSAllow;
			QCCharType _QuickAutoCreateMrr = QuickAutoCreateMrr;
			QCCodeType _QuickMrrReasonCode = QuickMrrReasonCode;
			ListYesNoType _QuickCreateItem = QuickCreateItem;
			QCCharType _QuickItemInspFreqId = QuickItemInspFreqId;
			DescriptionType _QuickItemAlert = QuickItemAlert;
			ListYesNoType _QuickQCSAllowIP = QuickQCSAllowIP;
			QCCharType _QuickAutoCreateMrrIP = QuickAutoCreateMrrIP;
			QCCodeType _QuickMrrReasonCodeIP = QuickMrrReasonCodeIP;
			ListYesNoType _QuickCreateItemIP = QuickCreateItemIP;
			QCCharType _QuickItemInspFreqIdIP = QuickItemInspFreqIdIP;
			DescriptionType _QuickItemAlertIP = QuickItemAlertIP;
			QCCharType _QuickItemTestTypeIP = QuickItemTestTypeIP;
			QCTestSeqType _QuickItemTestSeqIP = QuickItemTestSeqIP;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetQuickMrrParmsSp";
				
				appDB.AddCommandParameter(cmd, "QuickQCSAllow", _QuickQCSAllow, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickAutoCreateMrr", _QuickAutoCreateMrr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickMrrReasonCode", _QuickMrrReasonCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickCreateItem", _QuickCreateItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemInspFreqId", _QuickItemInspFreqId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemAlert", _QuickItemAlert, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickQCSAllowIP", _QuickQCSAllowIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickAutoCreateMrrIP", _QuickAutoCreateMrrIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickMrrReasonCodeIP", _QuickMrrReasonCodeIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickCreateItemIP", _QuickCreateItemIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemInspFreqIdIP", _QuickItemInspFreqIdIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemAlertIP", _QuickItemAlertIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemTestTypeIP", _QuickItemTestTypeIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuickItemTestSeqIP", _QuickItemTestSeqIP, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QuickQCSAllow = _QuickQCSAllow;
				QuickAutoCreateMrr = _QuickAutoCreateMrr;
				QuickMrrReasonCode = _QuickMrrReasonCode;
				QuickCreateItem = _QuickCreateItem;
				QuickItemInspFreqId = _QuickItemInspFreqId;
				QuickItemAlert = _QuickItemAlert;
				QuickQCSAllowIP = _QuickQCSAllowIP;
				QuickAutoCreateMrrIP = _QuickAutoCreateMrrIP;
				QuickMrrReasonCodeIP = _QuickMrrReasonCodeIP;
				QuickCreateItemIP = _QuickCreateItemIP;
				QuickItemInspFreqIdIP = _QuickItemInspFreqIdIP;
				QuickItemAlertIP = _QuickItemAlertIP;
				QuickItemTestTypeIP = _QuickItemTestTypeIP;
				QuickItemTestSeqIP = _QuickItemTestSeqIP;
				
				return (Severity, QuickQCSAllow, QuickAutoCreateMrr, QuickMrrReasonCode, QuickCreateItem, QuickItemInspFreqId, QuickItemAlert, QuickQCSAllowIP, QuickAutoCreateMrrIP, QuickMrrReasonCodeIP, QuickCreateItemIP, QuickItemInspFreqIdIP, QuickItemAlertIP, QuickItemTestTypeIP, QuickItemTestSeqIP);
			}
		}
	}
}
