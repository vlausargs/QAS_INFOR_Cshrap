//PROJECT NAME: Logistics
//CLASS NAME: IPoNumValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoNumValid
	{
		(int? ReturnCode, string OutType) PoNumValidSp(string PoNum,
		string OutType);
	}
}

