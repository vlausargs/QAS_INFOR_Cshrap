//PROJECT NAME: Data
//CLASS NAME: IEcnHist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEcnHist
	{
		(int? ReturnCode,
			string Infobar) EcnHistSp(
			Guid? EcnRowPointer,
			string Infobar);
	}
}

