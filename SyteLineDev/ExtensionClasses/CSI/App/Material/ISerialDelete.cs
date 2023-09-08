//PROJECT NAME: Material
//CLASS NAME: ISerialDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISerialDelete
	{
		(int? ReturnCode, string Infobar) SerialDeleteSp(string FROMWhse,
		string ToWhse,
		string FROMSerNum,
		string ToSerNum,
		string FROMItem,
		string ToItem,
		string FROMLot,
		string ToLot,
		string SerialStat,
		string Infobar,
		string ImportDocId);
	}
}

