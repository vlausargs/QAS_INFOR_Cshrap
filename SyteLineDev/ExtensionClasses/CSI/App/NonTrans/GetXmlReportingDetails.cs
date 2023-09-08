//PROJECT NAME: NonTrans
//CLASS NAME: GetXmlReportingDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.NonTrans
{
	public class GetXmlReportingDetails : IGetXmlReportingDetails
	{
		readonly IApplicationDB appDB;
		
		
		public GetXmlReportingDetails(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string IntranetName,
		string XMLReportingURL,
		string XMLReportingFolder,
		string XMLReportingDatasetURL,
		string Infobar) GetXmlReportingDetailsSp(string SiteID,
		string IntranetName,
		string XMLReportingURL,
		string XMLReportingFolder,
		string XMLReportingDatasetURL,
		string Infobar)
		{
			SiteType _SiteID = SiteID;
			IntranetNameType _IntranetName = IntranetName;
			URLType _XMLReportingURL = XMLReportingURL;
			OSLocationType _XMLReportingFolder = XMLReportingFolder;
			URLType _XMLReportingDatasetURL = XMLReportingDatasetURL;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetXmlReportingDetailsSp";
				
				appDB.AddCommandParameter(cmd, "SiteID", _SiteID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntranetName", _IntranetName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "XMLReportingURL", _XMLReportingURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "XMLReportingFolder", _XMLReportingFolder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "XMLReportingDatasetURL", _XMLReportingDatasetURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IntranetName = _IntranetName;
				XMLReportingURL = _XMLReportingURL;
				XMLReportingFolder = _XMLReportingFolder;
				XMLReportingDatasetURL = _XMLReportingDatasetURL;
				Infobar = _Infobar;
				
				return (Severity, IntranetName, XMLReportingURL, XMLReportingFolder, XMLReportingDatasetURL, Infobar);
			}
		}
	}
}
