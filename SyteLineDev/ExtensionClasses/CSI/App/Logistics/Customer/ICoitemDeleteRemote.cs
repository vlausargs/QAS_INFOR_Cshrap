//PROJECT NAME: Logistics
//CLASS NAME: ICoitemDeleteRemote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemDeleteRemote
	{
		int? CoitemDeleteRemoteSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string CoCustNum,
			string CoOrigSite);
	}
}

