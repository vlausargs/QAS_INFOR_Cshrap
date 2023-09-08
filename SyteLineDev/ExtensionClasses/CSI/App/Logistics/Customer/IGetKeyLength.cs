//PROJECT NAME: Logistics
//CLASS NAME: IGetKeyLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetKeyLength
	{
		(int? ReturnCode, int? KeyLength,
		string Infobar) GetKeyLengthSp(string KeyName,
		int? KeyLength,
		string Infobar);
	}
}

