//PROJECT NAME: Logistics
//CLASS NAME: IVoidInvPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IVoidInvPost
	{
		(int? ReturnCode, string Infobar) VoidInvPostSp(string PArtranType,
		string PInvNum,
		string PReason,
		string Infobar = null);
	}
}

