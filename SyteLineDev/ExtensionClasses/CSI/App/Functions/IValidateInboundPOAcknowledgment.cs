//PROJECT NAME: Data
//CLASS NAME: IValidateInboundPOAcknowledgment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateInboundPOAcknowledgment
	{
		int? ValidateInboundPOAcknowledgmentSp(
			Guid? poack_rowpointer,
			Guid? tp_rowpointer,
			string call_from);
	}
}

