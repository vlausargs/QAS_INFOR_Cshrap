//PROJECT NAME: Data
//CLASS NAME: IFloorStkReplenCel06LI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFloorStkReplenCel06LI
	{
		(int? ReturnCode,
			string Infobar) FloorStkReplenCel06LISp(
			string pStartPsNum,
			string pEndPsNum,
			string pStartJob,
			string pEndJob,
			int? pStartJobSuffix,
			int? pEndJobSuffix,
			string pStartItem,
			string pEndItem,
			string pStartJobmatlItem,
			string pEndJobmatlItem,
			string pJobType,
			DateTime? pStartDate,
			DateTime? pEndDate,
			string pStartWc,
			string pEndWc,
			int? pSubtractFlrQty,
			string pWarehouse,
			string pSearchField,
			string Infobar);
	}
}

