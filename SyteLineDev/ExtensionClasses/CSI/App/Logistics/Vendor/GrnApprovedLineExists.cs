//PROJECT NAME: CSIVendor
//CLASS NAME: GrnApprovedLineExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGrnApprovedLineExists
	{
		int GrnApprovedLineExistsSp(string GrnNum,
		                            string RefNum,
		                            short? RefLineSuf,
		                            short? RefRelease,
		                            ref string Infobar);
	}
	
	public class GrnApprovedLineExists : IGrnApprovedLineExists
	{
		readonly IApplicationDB appDB;
		
		public GrnApprovedLineExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GrnApprovedLineExistsSp(string GrnNum,
		                                   string RefNum,
		                                   short? RefLineSuf,
		                                   short? RefRelease,
		                                   ref string Infobar)
		{
			GrnNumType _GrnNum = GrnNum;
			PoTrnNumType _RefNum = RefNum;
			PoLineType _RefLineSuf = RefLineSuf;
			PoReleaseType _RefRelease = RefRelease;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GrnApprovedLineExistsSp";
				
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
