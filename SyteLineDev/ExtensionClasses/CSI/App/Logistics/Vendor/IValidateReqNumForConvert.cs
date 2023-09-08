//PROJECT NAME: Logistics
//CLASS NAME: IValidateReqNumForConvert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateReqNumForConvert
	{
		(int? ReturnCode, int? StartLineNum,
		int? EndLineNum,
		string Infobar) ValidateReqNumForConvertSp(string ReqNum,
		int? StartLineNum,
		int? EndLineNum,
		string Infobar);
	}
}

