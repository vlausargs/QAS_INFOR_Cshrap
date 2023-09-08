//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListCust
	{
		(int? ReturnCode,
			string Infobar) GenerateOrderPickListCustSp(
			string PCoCoNum,
			string PCoCustNum,
			int? PCoCustSeq,
			string PCoTermsCode,
			string PCoShipCode,
			int? PProcessBatchId,
			string PWhseWhse,
			string Infobar);
	}
}

