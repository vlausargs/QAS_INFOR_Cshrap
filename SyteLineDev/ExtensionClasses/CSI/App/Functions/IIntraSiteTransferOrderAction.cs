//PROJECT NAME: Data
//CLASS NAME: IIntraSiteTransferOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIntraSiteTransferOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) IntraSiteTransferOrderActionSp(
			string PlannerCodeStarting,
			string PlannerCodeEnding,
			string ItemStarting,
			string ItemEnding,
			string WhseStarting,
			string WhseEnding,
			DateTime? StartDateBeg,
			DateTime? StartDateEnd,
			string Source);
	}
}

