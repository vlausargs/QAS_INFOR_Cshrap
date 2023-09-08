//PROJECT NAME: Production
//CLASS NAME: IWBSCheckProjWbsValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSCheckProjWbsValid
	{
		(int? ReturnCode, string ValidRefNum,
		string ValidProjType) WBSCheckProjWbsValidSP(string RefType,
		string RefNum,
		string ValidRefNum,
		string ValidProjType);
	}
}

