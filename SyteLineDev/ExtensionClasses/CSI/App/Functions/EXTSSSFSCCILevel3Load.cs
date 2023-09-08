//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSCCILevel3Load.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSCCILevel3Load : IEXTSSSFSCCILevel3Load
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSCCILevel3Load(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSCCILevel3LoadSp(
			string InvNum,
			string BillType)
		{
			InvNumType _InvNum = InvNum;
			BillingTypeType _BillType = BillType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSCCILevel3LoadSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
