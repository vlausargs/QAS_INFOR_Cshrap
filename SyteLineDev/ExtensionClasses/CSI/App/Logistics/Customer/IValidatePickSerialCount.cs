//PROJECT NAME: Logistics
//CLASS NAME: IValidatePickSerialCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidatePickSerialCount
	{
		(int? ReturnCode, string Infobar) ValidatePickSerialCountSp(Guid? ProcessId,
		string Infobar);
	}
}

