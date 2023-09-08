//PROJECT NAME: Data
//CLASS NAME: IFormatPODropShipAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatPODropShipAddress
	{
		string FormatPODropShipAddressFn(
			string PoShipAddr,
			string PoDropShipNo,
			int? PoDropSeq,
			string PoWhse);
	}
}

