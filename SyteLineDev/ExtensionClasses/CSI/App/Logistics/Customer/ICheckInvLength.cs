//PROJECT NAME: Logistics
//CLASS NAME: ICheckInvLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckInvLength
	{
		(int? ReturnCode, int? Result,
		string Infobar) CheckInvLengthSp(int? Result,
		string Infobar);
	}
}

