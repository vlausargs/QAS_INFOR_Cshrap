//PROJECT NAME: Material
//CLASS NAME: IEcnCpEcn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IEcnCpEcn
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnCpEcnSp(string FromEcnType,
		int? FromEcnNum,
		string FromEcnStat,
		string FromEcnJobType,
		int? FromBeginEcnLine,
		int? FromEndEcnLine,
		int? ToEcnNum,
		string EcnLineOption,
		int? RunMode,
		string Infobar);
	}
}

