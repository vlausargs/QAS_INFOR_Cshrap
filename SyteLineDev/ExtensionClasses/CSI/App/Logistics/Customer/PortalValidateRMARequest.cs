//PROJECT NAME: CSICustomer
//CLASS NAME: PortalValidateRmaRequest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPortalValidateRmaRequest
	{
		int PortalValidateRmaRequestSp(string CustNum,
		                               string TakenBy,
		                               string LineItem,
		                               string LineCustItem,
		                               decimal? LineQtyToReturnConv,
		                               string CoNum,
		                               short? CoLine,
		                               short? CoRelease,
		                               string LineReasonText,
		                               string LineOrigInvNum,
		                               ref string Infobar);
	}
	
	public class PortalValidateRmaRequest : IPortalValidateRmaRequest
	{
		readonly IApplicationDB appDB;
		
		public PortalValidateRmaRequest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalValidateRmaRequestSp(string CustNum,
		                                      string TakenBy,
		                                      string LineItem,
		                                      string LineCustItem,
		                                      decimal? LineQtyToReturnConv,
		                                      string CoNum,
		                                      short? CoLine,
		                                      short? CoRelease,
		                                      string LineReasonText,
		                                      string LineOrigInvNum,
		                                      ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			TakenByType _TakenBy = TakenBy;
			ItemType _LineItem = LineItem;
			CustItemType _LineCustItem = LineCustItem;
			QtyUnitNoNegType _LineQtyToReturnConv = LineQtyToReturnConv;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			FormEditorType _LineReasonText = LineReasonText;
			InvNumType _LineOrigInvNum = LineOrigInvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalValidateRmaRequestSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TakenBy", _TakenBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineItem", _LineItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineCustItem", _LineCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineQtyToReturnConv", _LineQtyToReturnConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineReasonText", _LineReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineOrigInvNum", _LineOrigInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
