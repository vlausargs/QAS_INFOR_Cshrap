//PROJECT NAME: Logistics
//CLASS NAME: GetChartInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetChartInfo : IGetChartInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetChartInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rChartType,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar,
		int? rIsControl) GetChartInfoSp(string pChartAcct,
		string rChartType,
		string rAccessUnit1,
		string rAccessUnit2,
		string rAccessUnit3,
		string rAccessUnit4,
		string rDescription,
		string Infobar,
		string Site = null,
		int? rIsControl = null)
		{
			AcctType _pChartAcct = pChartAcct;
			ChartTypeType _rChartType = rChartType;
			UnitCodeAccessType _rAccessUnit1 = rAccessUnit1;
			UnitCodeAccessType _rAccessUnit2 = rAccessUnit2;
			UnitCodeAccessType _rAccessUnit3 = rAccessUnit3;
			UnitCodeAccessType _rAccessUnit4 = rAccessUnit4;
			DescriptionType _rDescription = rDescription;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _rIsControl = rIsControl;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetChartInfoSp";
				
				appDB.AddCommandParameter(cmd, "pChartAcct", _pChartAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rChartType", _rChartType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit1", _rAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit2", _rAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit3", _rAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccessUnit4", _rAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDescription", _rDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rIsControl", _rIsControl, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rChartType = _rChartType;
				rAccessUnit1 = _rAccessUnit1;
				rAccessUnit2 = _rAccessUnit2;
				rAccessUnit3 = _rAccessUnit3;
				rAccessUnit4 = _rAccessUnit4;
				rDescription = _rDescription;
				Infobar = _Infobar;
				rIsControl = _rIsControl;
				
				return (Severity, rChartType, rAccessUnit1, rAccessUnit2, rAccessUnit3, rAccessUnit4, rDescription, Infobar, rIsControl);
			}
		}
	}
}
