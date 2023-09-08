//PROJECT NAME: Data
//CLASS NAME: IGetMrpExcMesg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetMrpExcMesg
	{
		string GetMrpExcMesgFn(
			string Item,
			string OrderType,
			string OrderNum,
			int? OrderLineSuf,
			int? OrderRel,
			Guid? RowPointer);
	}
}

