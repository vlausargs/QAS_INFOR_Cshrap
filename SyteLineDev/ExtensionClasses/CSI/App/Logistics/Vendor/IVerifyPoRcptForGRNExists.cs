//PROJECT NAME: Logistics
//CLASS NAME: IVerifyPoRcptForGRNExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVerifyPoRcptForGRNExists
	{
		(int? ReturnCode, string Infobar) VerifyPoRcptForGRNExistsSp(string GrnNum,
		string VendNum,
		string Infobar);
	}
}

