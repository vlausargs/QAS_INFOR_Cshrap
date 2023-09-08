//PROJECT NAME: Logistics
//CLASS NAME: IVerifyAppmtChecksToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVerifyAppmtChecksToPrintPost
	{
		(int? ReturnCode, Guid? PSessionID) VerifyAppmtChecksToPrintPostSp(Guid? PSessionID = null);
	}
}

