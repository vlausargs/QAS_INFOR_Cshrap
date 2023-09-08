//PROJECT NAME: Material
//CLASS NAME: IGetMaxSerialNumSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetMaxSerialNumSite
	{
		(int? ReturnCode, string SerNum) GetMaxSerialNumSiteSp(string SerNumPrefix,
		string Site = null,
		string SerNum = null,
		string Item = null);
	}
}

