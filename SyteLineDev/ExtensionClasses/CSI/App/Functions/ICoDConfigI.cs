//PROJECT NAME: Data
//CLASS NAME: ICoDConfigI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoDConfigI
	{
		(int? ReturnCode,
			string rInfobar) CoDConfigISp(
			int? pCoitemCoLine,
			string pCoitemCoNum,
			string pCoitemFeatStr,
			string pCoItemItem,
			Guid? pCoItemRowPointer,
			string pInvparmsFbomBlank,
			string pInvparmsFeatTempl,
			string pItemFeatTempl,
			string pItemJob,
			int? pItemPlanFlag,
			Guid? pItemRowPointer,
			int? pItemSuffix,
			DateTime? pOrderDate,
			string rInfobar);
	}
}

