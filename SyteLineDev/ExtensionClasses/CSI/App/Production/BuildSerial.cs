//PROJECT NAME: Production
//CLASS NAME: BuildSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BuildSerial : IBuildSerial
	{
		readonly IApplicationDB appDB;
		
		
		public BuildSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BuildSerialSp(decimal? TransNum,
		string Infobar,
		string ContainerNum = null,
		DateTime? ManufacturedDate = null)
		{
			HugeTransNumType _TransNum = TransNum;
			InfobarType _Infobar = Infobar;
			ContainerNumType _ContainerNum = ContainerNum;
			DateType _ManufacturedDate = ManufacturedDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildSerialSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ContainerNum", _ContainerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturedDate", _ManufacturedDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
