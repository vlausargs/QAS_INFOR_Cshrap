//PROJECT NAME: Logistics
//CLASS NAME: ICARaSCustAddrExtraction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICARaSCustAddrExtraction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CARaSCustAddrExtractionSp(string StartCustNum,
		string EndCustNum,
		int? ExtractAll);
	}
}

