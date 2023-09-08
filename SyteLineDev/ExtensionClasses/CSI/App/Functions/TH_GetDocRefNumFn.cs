//PROJECT NAME: Data
//CLASS NAME: TH_GetDocRefNumFn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TH_GetDocRefNumFn : ITH_GetDocRefNumFn
	{
		readonly IApplicationDB appDB;
		
		public TH_GetDocRefNumFn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string TH_GetDocRefNumFnFn(
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			decimal? TranNo)
		{
			StringType _RefType = RefType;
			StringType _RefNum = RefNum;
			ShortType _RefLineSuf = RefLineSuf;
			ShortType _RefRelease = RefRelease;
			MatlTransNumType _TranNo = TranNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[TH_GetDocRefNumFn](@RefType, @RefNum, @RefLineSuf, @RefRelease, @TranNo)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranNo", _TranNo, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
