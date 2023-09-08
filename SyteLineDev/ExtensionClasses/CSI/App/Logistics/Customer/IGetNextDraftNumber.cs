//PROJECT NAME: Logistics
//CLASS NAME: IGetNextDraftNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetNextDraftNumber
	{
		(int? ReturnCode, int? NextDraftNumber) GetNextDraftNumberSp(int? NextDraftNumber);
	}
}

