//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFormatConsumerAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFormatConsumerAddress
	{
		string SSSFSFormatConsumerAddressFn(
			string UsrNum,
			int? UsrSeq);
	}
}

