//PROJECT NAME: Codes
//CLASS NAME: IGetISOUMInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetISOUMInfo
	{
		(int? ReturnCode,
		string ISOUMDescription) GetISOUMInfoSp(
			string ISOUMCode,
			string ISOUMDescription = null);
	}
}

