//PROJECT NAME: Production
//CLASS NAME: SetPrintQuoteSectionPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class SetPrintQuoteSectionPrice : ISetPrintQuoteSectionPrice
	{
		readonly IApplicationDB appDB;
		
		
		public SetPrintQuoteSectionPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SetPrintQuoteSectionPriceSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		int? SectionNum,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			PP_QuoteSectionType _SectionNum = SectionNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetPrintQuoteSectionPriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SectionNum", _SectionNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
