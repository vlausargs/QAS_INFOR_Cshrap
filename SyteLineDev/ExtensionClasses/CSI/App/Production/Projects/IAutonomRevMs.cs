//PROJECT NAME: Production
//CLASS NAME: IAutonomRevMs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IAutonomRevMs
	{
		(int? ReturnCode, int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar) AutonomRevMsSp(string InProjNum,
		string InMsNum,
		int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar);
	}
}

