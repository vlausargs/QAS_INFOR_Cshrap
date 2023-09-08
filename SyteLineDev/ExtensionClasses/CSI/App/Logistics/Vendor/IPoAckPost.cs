//PROJECT NAME: Logistics
//CLASS NAME: IPoAckPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoAckPost
	{
		(int? ReturnCode, string Infobar) PoAckPostSp(Guid? PoackRowPointer,
		Guid? VendTpRowPointer,
		string Infobar);
	}
}

