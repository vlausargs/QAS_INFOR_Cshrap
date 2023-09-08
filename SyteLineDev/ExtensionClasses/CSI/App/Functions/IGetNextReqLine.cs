//PROJECT NAME: Data
//CLASS NAME: IGetNextReqLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNextReqLine
	{
		(int? ReturnCode,
			int? ReqLine) GetNextReqLineSp(
			string ReqNum,
			int? ReqLine);
	}
}

