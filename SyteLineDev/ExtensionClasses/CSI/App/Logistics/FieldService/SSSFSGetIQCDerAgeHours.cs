//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetIQCDerAgeHours.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIQCDerAgeHours : ISSSFSGetIQCDerAgeHours
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIQCDerAgeHours(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSGetIQCDerAgeHoursFn(
			DateTime? AsOfDate,
			DateTime? AgeBasis,
			string DateBasis)
		{
			DateTimeType _AsOfDate = AsOfDate;
			DateTimeType _AgeBasis = AgeBasis;
			FSPriorDateBasisType _DateBasis = DateBasis;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetIQCDerAgeHours](@AsOfDate, @AgeBasis, @DateBasis)";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeBasis", _AgeBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateBasis", _DateBasis, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
