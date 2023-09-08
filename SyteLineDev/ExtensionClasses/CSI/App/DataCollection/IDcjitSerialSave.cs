//PROJECT NAME: DataCollection
//CLASS NAME: IDcjitSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcjitSerialSave
	{
		int? DcjitSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer);
	}
}

