//PROJECT NAME: Logistics
//CLASS NAME: IGetNextDraftNumberWrapper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetNextDraftNumberWrapper
	{
		(int? ReturnCode, int? NextDraftNumber) GetNextDraftNumberWrapperSp(string Type,
		int? NextDraftNumber);
	}
}

