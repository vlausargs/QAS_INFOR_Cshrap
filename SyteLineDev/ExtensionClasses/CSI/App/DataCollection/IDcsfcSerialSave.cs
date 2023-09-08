//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcSerialSave
	{
		(int? ReturnCode, string Infobar) DcsfcSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		string Infobar);
	}
}

