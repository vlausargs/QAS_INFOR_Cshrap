//PROJECT NAME: Logistics
//CLASS NAME: ISchedFormatAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISchedFormatAddress
	{
		string SchedFormatAddressSp(
			string Name,
			string Addr1,
			string Addr2,
			string Addr3,
			string Addr4,
			string City,
			string State,
			string Zip,
			string Country);
	}
}

