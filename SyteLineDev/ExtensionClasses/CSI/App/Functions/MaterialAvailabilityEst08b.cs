//PROJECT NAME: Data
//CLASS NAME: MaterialAvailabilityEst08b.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaterialAvailabilityEst08b : IMaterialAvailabilityEst08b
	{
		readonly IApplicationDB appDB;
		
		public MaterialAvailabilityEst08b(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? priorposition,
			int? PhCnt) MaterialAvailabilityEst08bSp(
			int? priorposition,
			string PhItem,
			DateTime? PhDate,
			string PhTreeString,
			decimal? PhRequired,
			int? PhCnt,
			Guid? CurSumId)
		{
			IntType _priorposition = priorposition;
			ItemType _PhItem = PhItem;
			CurrentDateType _PhDate = PhDate;
			LongListType _PhTreeString = PhTreeString;
			QtyTotlType _PhRequired = PhRequired;
			GenericNoType _PhCnt = PhCnt;
			GuidType _CurSumId = CurSumId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MaterialAvailabilityEst08b";
				
				appDB.AddCommandParameter(cmd, "priorposition", _priorposition, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PhItem", _PhItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhDate", _PhDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhTreeString", _PhTreeString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhRequired", _PhRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhCnt", _PhCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurSumId", _CurSumId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				priorposition = _priorposition;
				PhCnt = _PhCnt;
				
				return (Severity, priorposition, PhCnt);
			}
		}
	}
}
