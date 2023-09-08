//PROJECT NAME: Logistics
//CLASS NAME: IGenerateGUID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateGUID
	{
		(int? ReturnCode, Guid? GUID) GenerateGUIDSp(Guid? GUID);
	}
}

