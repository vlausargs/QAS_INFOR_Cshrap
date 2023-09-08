//PROJECT NAME: Data
//CLASS NAME: IValidateInboundVendorShipNotice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateInboundVendorShipNotice
	{
		int? ValidateInboundVendorShipNoticeSp(
			Guid? vsn_rowpointer,
			Guid? tp_rowpointer,
			string call_FROM);
	}
}

