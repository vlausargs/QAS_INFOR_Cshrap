//PROJECT NAME: Logistics
//CLASS NAME: IUpdateParmsRsvd1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateParmsRsvd1
	{
		(int? ReturnCode, string Infobar) UpdateParmsRsvd1Sp(int? CoparmsParmKey,
		int? ParmsRsvd1,
		string Infobar);
	}
}

