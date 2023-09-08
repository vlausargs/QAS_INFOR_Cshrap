//PROJECT NAME: Production
//CLASS NAME: IGetAllCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetAllCodes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetAllCodesSp(
			string Class1,
			string Class2 = null,
			string Class3 = null,
			string Class4 = null,
			string Class5 = null,
			string Class6 = null,
			string Class7 = null,
			string Class8 = null,
			string Class9 = null,
			string Class10 = null);
	}
}

