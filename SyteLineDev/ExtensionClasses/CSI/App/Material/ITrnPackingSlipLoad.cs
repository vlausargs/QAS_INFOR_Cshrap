//PROJECT NAME: Material
//CLASS NAME: ITrnPackingSlipLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrnPackingSlipLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) TrnPackingSlipLoadSp(string TrnNum,
		int? BegTrnLine,
		int? EndTrnLine,
		string LineStatT,
		string LineStatC,
		DateTime? BegDueDate,
		DateTime? EndDueDate);
	}
}

