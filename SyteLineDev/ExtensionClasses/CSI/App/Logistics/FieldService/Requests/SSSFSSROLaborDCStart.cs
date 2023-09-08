//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROLaborDCStart
	{
		(int? ReturnCode, string Infobar) SSSFSSROLaborDCStartSp(string PartnerId,
		string Type,
		Guid? RowPointer,
		string Infobar = null,
		string SroNum = null,
		int? SroLine = null,
		int? SroOper = null,
		DateTime? StartDate = null);
	}
	
	public class SSSFSSROLaborDCStart : ISSSFSSROLaborDCStart
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROLaborDCStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROLaborDCStartSp(string PartnerId,
		string Type,
		Guid? RowPointer,
		string Infobar = null,
		string SroNum = null,
		int? SroLine = null,
		int? SroOper = null,
		DateTime? StartDate = null)
		{
			FSPartnerType _PartnerId = PartnerId;
			StringType _Type = Type;
			RowPointer _RowPointer = RowPointer;
			Infobar _Infobar = Infobar;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateType _StartDate = StartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROLaborDCStartSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
