//PROJECT NAME: Data
//CLASS NAME: THACLM_ApptcChecksToVoid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THACLM_ApptcChecksToVoid : ITHACLM_ApptcChecksToVoid
	{
		readonly IApplicationDB appDB;
		
		public THACLM_ApptcChecksToVoid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? THACLM_ApptcChecksToVoidSp(
			string PPayCode,
			string PBankCode,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			int? PStartingCheckNum,
			int? PEndingCheckNum)
		{
			AppmtPayTypeType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			ApCheckNumType _PStartingCheckNum = PStartingCheckNum;
			ApCheckNumType _PEndingCheckNum = PEndingCheckNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THACLM_ApptcChecksToVoidSp";
				
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCheckNum", _PStartingCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCheckNum", _PEndingCheckNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
