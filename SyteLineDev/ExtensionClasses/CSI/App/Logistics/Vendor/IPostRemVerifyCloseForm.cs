//PROJECT NAME: Logistics
//CLASS NAME: IPostRemVerifyCloseForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPostRemVerifyCloseForm
	{
		(int? ReturnCode, string Infobar) PostRemVerifyCloseFormSP(Guid? PSessionID,
		string Infobar);
	}
}

