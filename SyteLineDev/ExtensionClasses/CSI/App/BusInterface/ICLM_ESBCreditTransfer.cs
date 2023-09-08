//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCreditTransfer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCreditTransfer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCreditTransferSp(DateTime? PCheckDate,
		int? PCheckNum,
		string PBankCode,
		string DocumentID);
	}
}

