//PROJECT NAME: Finance
//CLASS NAME: IGetFiscalPeriods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetFiscalPeriods
	{
		(int? ReturnCode, DateTime? rPer1Start,
		DateTime? rPer2Start,
		DateTime? rPer3Start,
		DateTime? rPer4Start,
		DateTime? rPer5Start,
		DateTime? rPer6Start,
		DateTime? rPer7Start,
		DateTime? rPer8Start,
		DateTime? rPer9Start,
		DateTime? rPer10Start,
		DateTime? rPer11Start,
		DateTime? rPer12Start,
		DateTime? rPer13Start,
		DateTime? rPer1End,
		DateTime? rPer2End,
		DateTime? rPer3End,
		DateTime? rPer4End,
		DateTime? rPer5End,
		DateTime? rPer6End,
		DateTime? rPer7End,
		DateTime? rPer8End,
		DateTime? rPer9End,
		DateTime? rPer10End,
		DateTime? rPer11End,
		DateTime? rPer12End,
		DateTime? rPer13End,
		string Infobar) GetFiscalPeriodsSp(int? pFiscalYear,
		DateTime? rPer1Start,
		DateTime? rPer2Start,
		DateTime? rPer3Start,
		DateTime? rPer4Start,
		DateTime? rPer5Start,
		DateTime? rPer6Start,
		DateTime? rPer7Start,
		DateTime? rPer8Start,
		DateTime? rPer9Start,
		DateTime? rPer10Start,
		DateTime? rPer11Start,
		DateTime? rPer12Start,
		DateTime? rPer13Start,
		DateTime? rPer1End,
		DateTime? rPer2End,
		DateTime? rPer3End,
		DateTime? rPer4End,
		DateTime? rPer5End,
		DateTime? rPer6End,
		DateTime? rPer7End,
		DateTime? rPer8End,
		DateTime? rPer9End,
		DateTime? rPer10End,
		DateTime? rPer11End,
		DateTime? rPer12End,
		DateTime? rPer13End,
		string Infobar);
	}
}

