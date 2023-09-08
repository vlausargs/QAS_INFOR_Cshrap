//PROJECT NAME: Data
//CLASS NAME: IRefSetSeparateSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRefSetSeparate
	{
		string RefSetSeparateSp(
			string JobOrdType,
			string JobOrdNum,
			int? JobOrdLine,
			int? JobOrdRelease);
	}
}

