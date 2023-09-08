//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_ContractTBI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_ContractTBI
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ContractTBISp(string ExOptBegCon_num = null,
		string ExOptEndCon_num = null,
		int? ExOptBegCon_line = null,
		int? ExOptEndCon_line = null,
		string ExOptBegcust_num = null,
		string ExOptENDcust_num = null,
		string ExOptBegserv_type = null,
		string ExOptENDserv_type = null,
		DateTime? ExOptRenew_date = null,
		int? Renew_dateOffSET = null,
		int? ExOptConIntNotes = 1,
		int? ExOptConExtNotes = 1,
		int? ExOptCustIntNotes = 1,
		int? ExOptCustExtNotes = 1,
		int? ExOptCustPage = 1,
		string ExOptBillFreq = "ASQBMO",
		int? ExOptContLineIntNotes = 1,
		int? ExOptContLineExtNotes = 1,
		string pSite = null);
	}
}

