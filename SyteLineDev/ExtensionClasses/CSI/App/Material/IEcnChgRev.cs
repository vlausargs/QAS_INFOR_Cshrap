//PROJECT NAME: Material
//CLASS NAME: IEcnChgRev.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IEcnChgRev
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnChgRevSp(string SelectedItem,
		string NewRev,
		string NewDrawing,
		int? RunMode,
		string Infobar,
		string CalledFrom = null,
		int? CopyUetValues = 0);
	}
}

