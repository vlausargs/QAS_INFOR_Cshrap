//PROJECT NAME: Logistics
//CLASS NAME: IFTSLValidServiceLabor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidServiceLabor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLValidServiceLaborSp(string CallForm,
		string EmpNum,
		string SroNum,
		int? SroLine,
		int? SroOper,
		int? TTImplemented,
		string PartnerId);
	}
}

