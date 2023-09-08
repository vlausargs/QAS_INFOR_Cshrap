//PROJECT NAME: DataCollection
//CLASS NAME: IDcmatlSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmatlSerialSave
	{
		(int? ReturnCode, string Infobar) DcmatlSerialSaveSp(int? TransNum,
		string SerNum,
		int? DerSelect,
		Guid? RowPointer,
		string Infobar);
	}
}

