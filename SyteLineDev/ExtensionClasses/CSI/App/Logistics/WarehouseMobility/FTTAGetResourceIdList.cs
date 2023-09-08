//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTAGetResourceIdList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTAGetResourceIdList
	{
		int FTTAGetResourceIdListSP(string Job,
		                            short? Suffix,
		                            int? Operation,
		                            ref string ResID);

		string FTTAGetResourceIdListFn(
			string OrderNumber,
			int? Suffix,
			int? Operation);
	}
	
	public class FTTAGetResourceIdList : IFTTAGetResourceIdList
	{
		readonly IApplicationDB appDB;
		
		public FTTAGetResourceIdList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTAGetResourceIdListSP(string Job,
		                                   short? Suffix,
		                                   int? Operation,
		                                   ref string ResID)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			ApsMsgParmType _ResID = ResID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTAGetResourceIdListSP";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResID", _ResID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ResID = _ResID;
				
				return Severity;
			}
		}

		public string FTTAGetResourceIdListFn(
			string OrderNumber,
			int? Suffix,
			int? Operation)
		{
			OrderNoType _OrderNumber = OrderNumber;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTTAGetResourceIdList](@OrderNumber, @Suffix, @Operation)";

				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
