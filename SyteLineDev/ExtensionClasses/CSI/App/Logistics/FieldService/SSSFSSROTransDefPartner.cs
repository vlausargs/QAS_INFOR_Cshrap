//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransDefPartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROTransDefPartner : ISSSFSSROTransDefPartner
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransDefPartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PartnerID,
			string Name,
			string Infobar) SSSFSSROTransDefPartnerSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			string PartnerID,
			string Name,
			string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			FSPartnerType _PartnerID = PartnerID;
			NameType _Name = Name;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransDefPartnerSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PartnerID = _PartnerID;
				Name = _Name;
				Infobar = _Infobar;
				
				return (Severity, PartnerID, Name, Infobar);
			}
		}
	}
}
