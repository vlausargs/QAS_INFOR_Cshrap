//PROJECT NAME: Data
//CLASS NAME: ICheckWBSStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckWBSStatus
	{
		(int? ReturnCode,
			string Infobar) CheckWBSStatusSP(
			string ParentSP,
			string ProjNum,
			int? ProjTaskNum,
			string ProjMsNum,
			int? Voucher,
			string Infobar);
	}
}

