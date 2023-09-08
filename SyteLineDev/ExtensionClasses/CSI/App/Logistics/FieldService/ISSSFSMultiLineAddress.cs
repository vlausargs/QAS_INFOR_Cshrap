//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSMultiLineAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSMultiLineAddress
	{
		string SSSFSMultiLineAddressSp(
			string Contact = null,
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string CityZip = null,
			string Country = null);
	}
}

