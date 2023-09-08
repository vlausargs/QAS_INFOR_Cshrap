//PROJECT NAME: Material
//CLASS NAME: IGetListSourceForTrnLines.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetListSourceForTrnLines
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetListSourceForTrnLinesSp(string STrnNum = null,
		string ETrnNum = null);
	}
}

