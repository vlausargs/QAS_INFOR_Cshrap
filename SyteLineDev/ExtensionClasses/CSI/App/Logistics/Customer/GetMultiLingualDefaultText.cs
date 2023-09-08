//PROJECT NAME: CSICustomer
//CLASS NAME: GetMultiLingualDefaultText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetMultiLingualDefaultText
	{
		int GetMultiLingualDefaultTextSp(ref string CoparmCoText1,
		                                 ref string CoparmCoText2,
		                                 ref string CoparmCoText3,
		                                 ref string InvparmTrnTxt1,
		                                 ref string InvparmTrnTxt2,
		                                 ref string InvparmTrnTxt3,
                                         ref string FlatRateCompensationText,
                                         ref string LatePayPenaltyRateText,
                                         ref string Infobar);
	}
	
	public class GetMultiLingualDefaultText : IGetMultiLingualDefaultText
	{
		readonly IApplicationDB appDB;
		
		public GetMultiLingualDefaultText(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetMultiLingualDefaultTextSp(ref string CoparmCoText1,
		                                        ref string CoparmCoText2,
		                                        ref string CoparmCoText3,
		                                        ref string InvparmTrnTxt1,
		                                        ref string InvparmTrnTxt2,
		                                        ref string InvparmTrnTxt3,
                                                ref string FlatRateCompensationText,
                                                ref string LatePayPenaltyRateText,
                                                ref string Infobar)
		{
			ReportTxtType _CoparmCoText1 = CoparmCoText1;
			ReportTxtType _CoparmCoText2 = CoparmCoText2;
			ReportTxtType _CoparmCoText3 = CoparmCoText3;
			ReportTxtType _InvparmTrnTxt1 = InvparmTrnTxt1;
			ReportTxtType _InvparmTrnTxt2 = InvparmTrnTxt2;
			ReportTxtType _InvparmTrnTxt3 = InvparmTrnTxt3;
            FRReportTextType _FlatRateCompensationText = FlatRateCompensationText;
            FRReportTextType _LatePayPenaltyRateText = LatePayPenaltyRateText;
            Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMultiLingualDefaultTextSp";
				
				appDB.AddCommandParameter(cmd, "CoparmCoText1", _CoparmCoText1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoparmCoText2", _CoparmCoText2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoparmCoText3", _CoparmCoText3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvparmTrnTxt1", _InvparmTrnTxt1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvparmTrnTxt2", _InvparmTrnTxt2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InvparmTrnTxt3", _InvparmTrnTxt3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FlatRateCompensationText", _FlatRateCompensationText, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LatePayPenaltyRateText", _LatePayPenaltyRateText, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoparmCoText1 = _CoparmCoText1;
				CoparmCoText2 = _CoparmCoText2;
				CoparmCoText3 = _CoparmCoText3;
				InvparmTrnTxt1 = _InvparmTrnTxt1;
				InvparmTrnTxt2 = _InvparmTrnTxt2;
				InvparmTrnTxt3 = _InvparmTrnTxt3;
                FlatRateCompensationText = _FlatRateCompensationText;
                LatePayPenaltyRateText = _LatePayPenaltyRateText;
                Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
