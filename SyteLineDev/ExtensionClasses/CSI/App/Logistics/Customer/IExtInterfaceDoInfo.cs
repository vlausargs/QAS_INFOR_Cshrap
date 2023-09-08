//PROJECT NAME: Logistics
//CLASS NAME: IExtInterfaceDoInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IExtInterfaceDoInfo
	{
		(int? ReturnCode, string DoHdrInfo,
		string DoLineInfo) ExtInterfaceDoInfoSp(string DoNum,
		string InvNum,
		int? InvSeq,
		string DoHdrInfo,
		string DoLineInfo);
	}
}

