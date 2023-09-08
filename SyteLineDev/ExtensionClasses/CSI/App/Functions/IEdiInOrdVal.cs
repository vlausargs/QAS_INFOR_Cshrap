//PROJECT NAME: Data
//CLASS NAME: IEdiInOrdVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInOrdVal
	{
		(int? ReturnCode,
			int? PCustSeq) EdiInOrdValSp(
			Guid? POrdRecid,
			Guid? PTpRecid,
			string PCallFrom,
			int? PCustSeq,
			string Site = null);
	}
}

