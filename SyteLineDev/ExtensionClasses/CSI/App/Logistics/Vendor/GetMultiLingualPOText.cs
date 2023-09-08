//PROJECT NAME: CSIVendor
//CLASS NAME: GetMultiLingualPOText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetMultiLingualPOText
	{
		int GetMultiLingualPOTextSp(ref string PoparmPOText1,
		                            ref string PoparmPoText2,
		                            ref string PoparmPoText3,
		                            ref string Infobar);
	}
	
	public class GetMultiLingualPOText : IGetMultiLingualPOText
	{
		readonly IApplicationDB appDB;
		
		public GetMultiLingualPOText(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMultiLingualPOTextSp(ref string PoparmPOText1,
		                                   ref string PoparmPoText2,
		                                   ref string PoparmPoText3,
		                                   ref string Infobar)
		{
			ReportTxtType _PoparmPOText1 = PoparmPOText1;
			ReportTxtType _PoparmPoText2 = PoparmPoText2;
			ReportTxtType _PoparmPoText3 = PoparmPoText3;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMultiLingualPOTextSp";
				
				appDB.AddCommandParameter(cmd, "PoparmPOText1", _PoparmPOText1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoparmPoText2", _PoparmPoText2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoparmPoText3", _PoparmPoText3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoparmPOText1 = _PoparmPOText1;
				PoparmPoText2 = _PoparmPoText2;
				PoparmPoText3 = _PoparmPoText3;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
