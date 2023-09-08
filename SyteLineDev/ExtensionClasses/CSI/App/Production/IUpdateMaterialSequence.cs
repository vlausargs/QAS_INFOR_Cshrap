//PROJECT NAME: Production
//CLASS NAME: IUpdateMaterialSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IUpdateMaterialSequence
	{
		(int? ReturnCode, string Infobar) UpdateMaterialSequenceSp(string Job,
		int? Suffix,
		int? OperNum,
		string Infobar);
	}
}

