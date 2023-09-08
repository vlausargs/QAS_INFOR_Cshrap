//PROJECT NAME: Data
//CLASS NAME: IValidateHostPort.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidateHostPort
	{
		(int? ReturnCode,
			string Infobar) ValidateHostPortSp(
			string PApsHostName,
			int? PApsPortNo,
			Guid? PRowPointer,
			string Infobar);
	}
}

