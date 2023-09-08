//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateSourcePoNumForCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidateSourcePoNumForCopy
	{
		int ValidateSourcePoNumForCopySp(string SourcePoNum,
		                                 string RegOrHist,
		                                 ref string SourcePoType,
		                                 ref short? StartLineNum,
		                                 ref short? EndLineNum,
		                                 ref string Infobar);
	}
	
	public class ValidateSourcePoNumForCopy : IValidateSourcePoNumForCopy
	{
		readonly IApplicationDB appDB;
		
		public ValidateSourcePoNumForCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateSourcePoNumForCopySp(string SourcePoNum,
		                                        string RegOrHist,
		                                        ref string SourcePoType,
		                                        ref short? StartLineNum,
		                                        ref short? EndLineNum,
		                                        ref string Infobar)
		{
			PoNumType _SourcePoNum = SourcePoNum;
			PoTypeType _RegOrHist = RegOrHist;
			PoTypeType _SourcePoType = SourcePoType;
			PoLineType _StartLineNum = StartLineNum;
			PoLineType _EndLineNum = EndLineNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSourcePoNumForCopySp";
				
				appDB.AddCommandParameter(cmd, "SourcePoNum", _SourcePoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RegOrHist", _RegOrHist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourcePoType", _SourcePoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SourcePoType = _SourcePoType;
				StartLineNum = _StartLineNum;
				EndLineNum = _EndLineNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
