//PROJECT NAME: Data
//CLASS NAME: IDisplayShiptoAddressWithPhoneSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisplayShiptoAddressWithPhone
	{
		string DisplayShiptoAddressWithPhoneSp(
			string DropShipNo,
			int? DropSeq,
			string SiteRef);
	}
}

