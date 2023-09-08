//PROJECT NAME: Material
//CLASS NAME: IGetItemSerialPrefix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetItemSerialPrefix
	{
		(int? ReturnCode, string pItemSerialPrefix,
		string rInfobar) GetItemSerialPrefixSp(string pItem,
		string pSite,
		string pItemSerialPrefix,
		string rInfobar);
	}
}

