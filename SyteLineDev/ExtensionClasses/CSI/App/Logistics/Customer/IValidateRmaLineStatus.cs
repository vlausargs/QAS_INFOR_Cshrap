//PROJECT NAME: Logistics
//CLASS NAME: IValidateRmaLineStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateRmaLineStatus
	{
		(int? ReturnCode, string Infobar) ValidateRmaLineStatusSp(string RmaNum, int? RmaLine, string Infobar);
	}
}

