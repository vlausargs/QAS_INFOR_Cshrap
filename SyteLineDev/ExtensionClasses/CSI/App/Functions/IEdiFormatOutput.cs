//PROJECT NAME: Data
//CLASS NAME: IEdiFormatOutput.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiFormatOutput
	{
		string EdiFormatOutputFn(
			string Row,
			string String,
			int? Position,
			int? Length);
	}
}

