//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSPortalValidateIncidentRequest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSPortalValidateIncidentRequest
	{
		int SSSFSPortalValidateIncidentRequestSp(string CustNum,
		                                         string CustSeq,
		                                         string Username,
		                                         string SerNum,
		                                         string Item,
		                                         string Site,
		                                         string PriorCode,
		                                         ref string Infobar);
	}
	
	public class SSSFSPortalValidateIncidentRequest : ISSSFSPortalValidateIncidentRequest
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalValidateIncidentRequest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSPortalValidateIncidentRequestSp(string CustNum,
		                                                string CustSeq,
		                                                string Username,
		                                                string SerNum,
		                                                string Item,
		                                                string Site,
		                                                string PriorCode,
		                                                ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustNumType _CustSeq = CustSeq;
			UsernameType _Username = Username;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			SiteType _Site = Site;
			FSIncPriorCodeType _PriorCode = PriorCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalValidateIncidentRequestSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
