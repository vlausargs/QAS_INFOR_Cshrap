//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalGetNewSROTransInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSPortalGetNewSROTransInfo
	{
		int SSSFSPortalGetNewSROTransInfoSp(string SroNum,
		                                    string CustNum,
		                                    int? CustSeq,
		                                    string Username,
		                                    ref string SroDescription,
		                                    ref string ShpToName,
		                                    ref string SiteSiteName,
		                                    ref int? SroLine,
		                                    ref string LnSerNum,
		                                    ref string LnItem,
		                                    ref string LnDescription,
		                                    ref int? SroOper,
		                                    ref string OperCode,
		                                    ref string OperDescription,
		                                    ref string PartnerID,
		                                    ref string PartnerName,
		                                    ref string Infobar);
	}
	
	public class SSSFSPortalGetNewSROTransInfo : ISSSFSPortalGetNewSROTransInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPortalGetNewSROTransInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSPortalGetNewSROTransInfoSp(string SroNum,
		                                           string CustNum,
		                                           int? CustSeq,
		                                           string Username,
		                                           ref string SroDescription,
		                                           ref string ShpToName,
		                                           ref string SiteSiteName,
		                                           ref int? SroLine,
		                                           ref string LnSerNum,
		                                           ref string LnItem,
		                                           ref string LnDescription,
		                                           ref int? SroOper,
		                                           ref string OperCode,
		                                           ref string OperDescription,
		                                           ref string PartnerID,
		                                           ref string PartnerName,
		                                           ref string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			UsernameType _Username = Username;
			DescriptionType _SroDescription = SroDescription;
			NameType _ShpToName = ShpToName;
			SiteType _SiteSiteName = SiteSiteName;
			FSSROLineType _SroLine = SroLine;
			SerNumType _LnSerNum = LnSerNum;
			ItemType _LnItem = LnItem;
			DescriptionType _LnDescription = LnDescription;
			FSSROOperType _SroOper = SroOper;
			FSOperCodeType _OperCode = OperCode;
			DescriptionType _OperDescription = OperDescription;
			FSPartnerType _PartnerID = PartnerID;
			NameType _PartnerName = PartnerName;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPortalGetNewSROTransInfoSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroDescription", _SroDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShpToName", _ShpToName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteSiteName", _SiteSiteName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LnSerNum", _LnSerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LnItem", _LnItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LnDescription", _LnDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperCode", _OperCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperDescription", _OperDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerName", _PartnerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SroDescription = _SroDescription;
				ShpToName = _ShpToName;
				SiteSiteName = _SiteSiteName;
				SroLine = _SroLine;
				LnSerNum = _LnSerNum;
				LnItem = _LnItem;
				LnDescription = _LnDescription;
				SroOper = _SroOper;
				OperCode = _OperCode;
				OperDescription = _OperDescription;
				PartnerID = _PartnerID;
				PartnerName = _PartnerName;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
