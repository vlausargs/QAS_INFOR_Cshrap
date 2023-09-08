//PROJECT NAME: Data
//CLASS NAME: IJobProjectedLateForCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobProjectedLateForCustomer
	{
		(int? ReturnCode,
			string Infobar) JobProjectedLateForCustomerSp(
			string AJob,
			int? ASuffix,
			DateTime? AEndDate,
			DateTime? ACompDate,
			string ACustNum,
			string AOrdNum,
			string Infobar);
	}
}

