//PROJECT NAME: Data
//CLASS NAME: IHome_POFundsCommittedSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_POFundsCommittedSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_POFundsCommittedSubSp(
			string pPoType = null,
			string pPoitemStat = null,
			string pPoStat = null,
			int? pPrintVendItem = null,
			int? pSortByCurrCode = null,
			int? pTransDomCurr = null,
			int? pShowDetail = null,
			int? pUseHistRate = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			string pStartVendor = null,
			string pEndVendor = null,
			DateTime? pStartOrderDate = null,
			DateTime? pEndOrderDate = null,
			string pStartVendOrder = null,
			string pEndVendOrder = null,
			string pStartItem = null,
			string pEndItem = null,
			string pStartVendItem = null,
			string pEndVendItem = null,
			DateTime? pStartDueDate = null,
			DateTime? pEndDueDate = null,
			DateTime? pStartRecvDate = null,
			DateTime? pEndRecvDate = null,
			string pStartCurrCode = null,
			string pEndCurrCode = null,
			int? pStartOrderDateOffset = null,
			int? pEndOrderDateOffset = null,
			int? pStartDueDateOffset = null,
			int? pEndDueDateOffset = null,
			int? pStartRecvDateOffset = null,
			int? pEndRecvDateOffset = null,
			int? DisplayHeader = null,
			int? pStartPoRel = null,
			int? pEndPoRel = null,
			int? TaskId = null);
	}
}

