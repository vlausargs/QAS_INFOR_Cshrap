//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFormatPartnerAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFormatPartnerAddress
	{
		string SSSFSFormatPartnerAddressFn(
			string iPartnerID);
	}
}

