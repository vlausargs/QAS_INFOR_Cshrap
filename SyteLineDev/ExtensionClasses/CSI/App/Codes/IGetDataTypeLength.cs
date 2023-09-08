//PROJECT NAME: Codes
//CLASS NAME: IGetDataTypeLength.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetDataTypeLength
	{
		(int? ReturnCode, int? DataTypeLength,
		string Infobar) GetDataTypeLengthSp(string DataType,
		int? DataTypeLength,
		string Infobar);
	}
}

