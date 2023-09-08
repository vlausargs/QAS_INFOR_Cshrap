//PROJECT NAME: Data
//CLASS NAME: ConvertAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertAcct : IConvertAcct
	{
		readonly IApplicationDB appDB;
		
		public ConvertAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertAcctFn(
			string OldAcct,
			int? RawAcctFlds,
			string FillFmt1,
			string FillFmt2,
			string FillFmt3,
			int? RawAcctPos1,
			int? RawAcctPos2,
			int? AcctLen1,
			int? AcctLen2,
			int? AcctChar1,
			string NilAcct,
			string LeadingSpaceChar)
		{
			AcctType _OldAcct = OldAcct;
			AcctFieldsType _RawAcctFlds = RawAcctFlds;
			AcctFmtType _FillFmt1 = FillFmt1;
			AcctFmtType _FillFmt2 = FillFmt2;
			AcctFmtType _FillFmt3 = FillFmt3;
			AcctPosType _RawAcctPos1 = RawAcctPos1;
			AcctPosType _RawAcctPos2 = RawAcctPos2;
			AcctLenType _AcctLen1 = AcctLen1;
			AcctLenType _AcctLen2 = AcctLen2;
			ListCharIntType _AcctChar1 = AcctChar1;
			AcctType _NilAcct = NilAcct;
			StringType _LeadingSpaceChar = LeadingSpaceChar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertAcct](@OldAcct, @RawAcctFlds, @FillFmt1, @FillFmt2, @FillFmt3, @RawAcctPos1, @RawAcctPos2, @AcctLen1, @AcctLen2, @AcctChar1, @NilAcct, @LeadingSpaceChar)";
				
				appDB.AddCommandParameter(cmd, "OldAcct", _OldAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RawAcctFlds", _RawAcctFlds, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FillFmt1", _FillFmt1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FillFmt2", _FillFmt2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FillFmt3", _FillFmt3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RawAcctPos1", _RawAcctPos1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RawAcctPos2", _RawAcctPos2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLen1", _AcctLen1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctLen2", _AcctLen2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctChar1", _AcctChar1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NilAcct", _NilAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadingSpaceChar", _LeadingSpaceChar, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
