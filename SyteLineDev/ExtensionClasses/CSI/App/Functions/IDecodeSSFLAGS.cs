//PROJECT NAME: Data
//CLASS NAME: IDecodeSSFLAGS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDecodeSSFLAGS
	{
		string DecodeSSFLAGSFn(
			int? SSFLAGS);
	}
}

