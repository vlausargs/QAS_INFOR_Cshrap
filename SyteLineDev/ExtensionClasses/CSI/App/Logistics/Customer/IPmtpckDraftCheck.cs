//PROJECT NAME: Logistics
//CLASS NAME: IPmtpckDraftCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckDraftCheck
	{
		(int? ReturnCode, string Infobar) PmtpckDraftCheckSp(string PCustNum,
		string PType,
		int? PCheckNum,
		DateTime? PArpmtDueDate,
		DateTime? PPmtpckDueDate,
		string PPmtpckCustNum,
		string PPmtpckInvNum,
		int? PDateCheck,
		string Infobar);
	}
}

