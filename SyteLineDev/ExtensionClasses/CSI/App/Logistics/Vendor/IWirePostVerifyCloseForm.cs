//PROJECT NAME: Logistics
//CLASS NAME: IWirePostVerifyCloseForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IWirePostVerifyCloseForm
	{
		(int? ReturnCode, string Infobar) WirePostVerifyCloseFormSp(Guid? PSessionID,
		string Infobar);
	}
}

