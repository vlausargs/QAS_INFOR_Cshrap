//PROJECT NAME: Data
//CLASS NAME: IGetApsRefFields.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetApsRefFields
	{
		(int? ReturnCode,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRel,
			int? RefSeq) GetApsRefFieldsSp(
			string OrderId,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRel,
			int? RefSeq);
	}
}

