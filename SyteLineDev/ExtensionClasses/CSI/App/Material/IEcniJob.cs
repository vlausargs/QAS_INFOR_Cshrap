//PROJECT NAME: Material
//CLASS NAME: IEcniJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IEcniJob
	{
		(int? ReturnCode, string OutType,
		string OutStat,
		string OutItem,
		string OutRevision,
		string OutDrawingNbr,
		string OutDescription,
		string Infobar) EcniJobSp(string InEcnitemType,
		string InJob,
		string InSuffix,
		int? InQuick,
		string OutType,
		string OutStat,
		string OutItem,
		string OutRevision,
		string OutDrawingNbr,
		string OutDescription,
		string Infobar);
	}
}

