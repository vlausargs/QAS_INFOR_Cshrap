//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetQuickMrrParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetQuickMrrParms
	{
		(int? ReturnCode, int? QuickQCSAllow,
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
		int? QuickItemTestSeqIP);
	}
}

