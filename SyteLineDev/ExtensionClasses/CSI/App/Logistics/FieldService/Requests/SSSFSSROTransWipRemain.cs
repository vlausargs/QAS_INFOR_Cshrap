//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROTransWipRemain.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransWipRemain
	{
		int SSSFSSROTransWipRemainSp(string SroNum,
		                             int? SroLine,
		                             ref decimal? WipRemainMatl,
		                             ref decimal? WipRemainLbr,
		                             ref decimal? WipRemainFov,
		                             ref decimal? WipRemainVov,
		                             ref decimal? WipRemainOut,
		                             ref string Infobar);
	}
	
	public class SSSFSSROTransWipRemain : ISSSFSSROTransWipRemain
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransWipRemain(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSROTransWipRemainSp(string SroNum,
		                                    int? SroLine,
		                                    ref decimal? WipRemainMatl,
		                                    ref decimal? WipRemainLbr,
		                                    ref decimal? WipRemainFov,
		                                    ref decimal? WipRemainVov,
		                                    ref decimal? WipRemainOut,
		                                    ref string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			AmountType _WipRemainMatl = WipRemainMatl;
			AmountType _WipRemainLbr = WipRemainLbr;
			AmountType _WipRemainFov = WipRemainFov;
			AmountType _WipRemainVov = WipRemainVov;
			AmountType _WipRemainOut = WipRemainOut;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransWipRemainSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WipRemainMatl", _WipRemainMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WipRemainLbr", _WipRemainLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WipRemainFov", _WipRemainFov, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WipRemainVov", _WipRemainVov, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WipRemainOut", _WipRemainOut, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WipRemainMatl = _WipRemainMatl;
				WipRemainLbr = _WipRemainLbr;
				WipRemainFov = _WipRemainFov;
				WipRemainVov = _WipRemainVov;
				WipRemainOut = _WipRemainOut;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
