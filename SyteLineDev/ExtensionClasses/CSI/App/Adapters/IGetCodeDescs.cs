//PROJECT NAME: Adapters
//CLASS NAME: IGetCodeDescs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Adapters
{
	public interface IGetCodeDescs
	{
		(int? ReturnCode, string PCodeDescs) GetCodeDescsSp(string PClass,
		string PCharCodes = null,
		string PDelimiter = null,
		string PCodeDescs = null);

		string GetCodeDescsFn(
			string PClass,
			string PCharCodes = null,
			string PDelimiter = null);
	}
}

