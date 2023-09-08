//PROJECT NAME: Material
//CLASS NAME: IEcniRevision.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IEcniRevision
	{
		(int? ReturnCode, string OutJob,
		string OutDrawingNbr,
		string Infobar) EcniRevisionSp(string InRevision,
		string InItem,
		string OutJob,
		string OutDrawingNbr,
		string Infobar);
	}
}

