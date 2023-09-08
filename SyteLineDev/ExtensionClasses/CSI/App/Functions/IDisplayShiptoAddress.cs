//PROJECT NAME: Data
//CLASS NAME: IDisplayShiptoAddressSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayShiptoAddress
	{
		string DisplayShiptoAddressSp(
			string DropShipNo,
			int? DropSeq,
			string SiteRef);
	}
}

