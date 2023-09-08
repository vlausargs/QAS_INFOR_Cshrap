//PROJECT NAME: Data
//CLASS NAME: IGetFirstJobroute.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFirstJobroute
	{
		(int? ReturnCode,
			int? OutCntrlPoint,
			string OutWc,
			int? OutOperNum,
			int? OutNextOper) GetFirstJobrouteSp(
			string InJob,
			int? InSuffix,
			int? OutCntrlPoint,
			string OutWc,
			int? OutOperNum,
			int? OutNextOper);
	}
}

