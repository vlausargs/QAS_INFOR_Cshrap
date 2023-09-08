//PROJECT NAME: Data
//CLASS NAME: IGenerateSerialNumbers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenerateSerialNumbers
	{
		(int? ReturnCode,
			string Infobar) GenerateSerialNumbersSp(
			string Prefix,
			int? Qty,
			int? SerNumWidth,
			string MaxSerNum,
			Guid? TmpSerId,
			string RefStr,
			string Infobar,
			string Item);
	}
}

