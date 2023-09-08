//PROJECT NAME: Production
//CLASS NAME: IPreUpdateMaterialSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPreUpdateMaterialSequence
	{
		(int? ReturnCode, string Infobar) PreUpdateMaterialSequenceSp(string Job,
		int? Suffix,
		int? OperNum,
		string Infobar);
	}
}

