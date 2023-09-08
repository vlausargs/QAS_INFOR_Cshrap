//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConsumerUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConsumerUpdate
	{
		int? SSSFSUnitConsumerUpdateSp(
			string SerNum,
			string Item,
			string CustNum,
			int? CustSeq,
			string UsrNum,
			int? UsrSeq,
			int? MeterAmt,
			int? CustLookup = 1,
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string City = null,
			string State = null,
			string Zip = null,
			string County = null,
			string Country = null,
			string Contact = null,
			string Email = null,
			string Phone = null,
			string FaxNum = null,
			int? BufferMode = 0);
	}
}

