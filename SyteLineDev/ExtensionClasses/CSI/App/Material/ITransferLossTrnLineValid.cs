//PROJECT NAME: Material
//CLASS NAME: ITransferLossTrnLineValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferLossTrnLineValid
	{
		(int? ReturnCode, string TnrSite,
		string TnrWhse,
		string PLot,
		int? FromLotTracked,
		int? UseFromSite,
		int? GenerateSerialNos,
		string RemoteSerialPrefix,
		string Infobar,
		string PImportDocId,
		int? FromTaxFreeMatl) TransferLossTrnLineValidSp(string PTrnNum,
		int? PTrnLine,
		string TnrSite,
		string TnrWhse,
		string PLot,
		int? FromLotTracked,
		int? UseFromSite,
		int? GenerateSerialNos,
		string RemoteSerialPrefix,
		string Infobar,
		string PImportDocId,
		int? FromTaxFreeMatl);
	}
}

