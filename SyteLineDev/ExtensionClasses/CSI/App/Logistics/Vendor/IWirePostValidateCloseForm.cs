//PROJECT NAME: Logistics
//CLASS NAME: IWirePostValidateCloseForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IWirePostValidateCloseForm
	{
		(int? ReturnCode, string Infobar) WirePostValidateCloseFormSp(Guid? PSessionID,
		string AppmtPayType,
		int? bRemitAdvicePrint,
		string Infobar);
	}
}

