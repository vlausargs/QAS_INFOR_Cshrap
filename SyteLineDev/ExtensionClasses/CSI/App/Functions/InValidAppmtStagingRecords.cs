//PROJECT NAME: Data
//CLASS NAME: InValidAppmtStagingRecords.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InValidAppmtStagingRecords : IInValidAppmtStagingRecords
	{
		readonly IApplicationDB appDB;
		
		public InValidAppmtStagingRecords(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InValidAppmtStagingRecordsFn(
			Guid? PProcessId,
			Guid? RowPointer,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			string PSortNameNum,
			DateTime? PPayDateStarting,
			DateTime? PPayDateEnding)
		{
			GuidType _PProcessId = PProcessId;
			RowPointerType _RowPointer = RowPointer;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			LongDescType _PSortNameNum = PSortNameNum;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[InValidAppmtStagingRecords](@PProcessId, @RowPointer, @PStartingVendNum, @PEndingVendNum, @PStartingVendName, @PEndingVendName, @PSortNameNum, @PPayDateStarting, @PPayDateEnding)";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
