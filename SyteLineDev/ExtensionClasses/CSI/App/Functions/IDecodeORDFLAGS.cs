//PROJECT NAME: Data
//CLASS NAME: IDecodeORDFLAGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDecodeORDFLAGS
	{
		string DecodeORDFLAGSFn(
			int? ORDFLAGS);
	}
}

