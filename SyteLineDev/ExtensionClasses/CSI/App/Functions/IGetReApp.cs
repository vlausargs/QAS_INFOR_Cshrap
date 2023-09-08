//PROJECT NAME: Data
//CLASS NAME: IGetReApp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetReApp
	{
		(int? ReturnCode,
			int? PReApp,
			string POpenType) GetReAppSp(
			string PCustNum,
			int? PCheckNum,
			int? PReApp,
			string POpenType);
	}
}

