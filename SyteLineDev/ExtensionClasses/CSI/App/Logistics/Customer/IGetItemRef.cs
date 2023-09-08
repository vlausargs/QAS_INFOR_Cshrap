//PROJECT NAME: Logistics
//CLASS NAME: IGetItemRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetItemRef
	{
		(int? ReturnCode, string RefType,
		string Infobar) GetItemRefSp(string Item,
		string CalledFrom,
		string RefType,
		string Infobar,
		string Site = null);
	}
}

