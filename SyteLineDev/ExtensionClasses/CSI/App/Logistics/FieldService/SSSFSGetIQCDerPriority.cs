//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetIQCDerPriority.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIQCDerPriority : ISSSFSGetIQCDerPriority
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIQCDerPriority(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSGetIQCDerPriorityFn(
			string SerNum,
			DateTime? AsOfDate,
			DateTime? IncDate,
			string PriorCode,
			DateTime? DueDate)
		{
			SerNumType _SerNum = SerNum;
			DateTimeType _AsOfDate = AsOfDate;
			DateTimeType _IncDate = IncDate;
			FSIncPriorCodeType _PriorCode = PriorCode;
			DateTimeType _DueDate = DueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetIQCDerPriority](@SerNum, @AsOfDate, @IncDate, @PriorCode, @DueDate)";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDate", _IncDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorCode", _PriorCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
