//PROJECT NAME: Data
//CLASS NAME: IRefSetSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRefSet
	{
		string RefSetSp(
			string JobOrdType,
			string JobOrdNum,
			int? JobOrdLine,
			int? JobOrdRelease);
	}
}

