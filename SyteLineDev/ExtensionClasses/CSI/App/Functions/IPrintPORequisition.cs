//PROJECT NAME: Data
//CLASS NAME: IPrintPORequisition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrintPORequisition
	{
		int? PrintPORequisitionSp(
			string StartReqNum = null,
			string EndReqNum = null,
			string UserName = null,
			string LangCode = null);
	}
}

