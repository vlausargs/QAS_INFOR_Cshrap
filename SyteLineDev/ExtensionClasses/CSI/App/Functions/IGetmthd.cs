//PROJECT NAME: Data
//CLASS NAME: IGetmthd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetmthd
	{
		(int? ReturnCode,
			int? PSortMethod) GetmthdSp(
			string PSort,
			int? PSortMethod,
			string pSite = null);
	}
}

