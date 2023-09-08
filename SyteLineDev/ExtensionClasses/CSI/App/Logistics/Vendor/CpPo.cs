//PROJECT NAME: CSIVendor
//CLASS NAME: CpPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICpPo
	{
		int CpPoSp(string RegOrHist,
		           string SourcePoNum,
		           short? StartLineNum,
		           short? EndLineNum,
		           ref string TargetPoNum,
		           string CopyOption,
		           int? CopyCharges,
		           ref string Infobar);
	}
	
	public class CpPo : ICpPo
	{
		readonly IApplicationDB appDB;
		
		public CpPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CpPoSp(string RegOrHist,
		                  string SourcePoNum,
		                  short? StartLineNum,
		                  short? EndLineNum,
		                  ref string TargetPoNum,
		                  string CopyOption,
		                  int? CopyCharges,
		                  ref string Infobar)
		{
			PoTypeType _RegOrHist = RegOrHist;
			PoNumType _SourcePoNum = SourcePoNum;
			PoLineType _StartLineNum = StartLineNum;
			PoLineType _EndLineNum = EndLineNum;
			PoNumType _TargetPoNum = TargetPoNum;
			GenericCodeType _CopyOption = CopyOption;
			GenericNoType _CopyCharges = CopyCharges;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpPoSp";
				
				appDB.AddCommandParameter(cmd, "RegOrHist", _RegOrHist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourcePoNum", _SourcePoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetPoNum", _TargetPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyCharges", _CopyCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TargetPoNum = _TargetPoNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
