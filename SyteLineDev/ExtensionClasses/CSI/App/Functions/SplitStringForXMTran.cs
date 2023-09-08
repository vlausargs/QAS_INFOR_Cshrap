//PROJECT NAME: Data
//CLASS NAME: SplitStringForXMTran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SplitStringForXMTran : ISplitStringForXMTran
	{
		readonly IApplicationDB appDB;
		
		public SplitStringForXMTran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Char1,
			string Char2,
			string Char3,
			string Char4,
			string Char5,
			string Char6,
			string Char7,
			string Char8) SplitStringForXMTranSp(
			string StringToSplit,
			string Split1,
			string Split2,
			string Char1 = null,
			string Char2 = null,
			string Char3 = null,
			string Char4 = null,
			string Char5 = null,
			string Char6 = null,
			string Char7 = null,
			string Char8 = null)
		{
			StringType _StringToSplit = StringToSplit;
			StringType _Split1 = Split1;
			StringType _Split2 = Split2;
			StringType _Char1 = Char1;
			StringType _Char2 = Char2;
			StringType _Char3 = Char3;
			StringType _Char4 = Char4;
			StringType _Char5 = Char5;
			StringType _Char6 = Char6;
			StringType _Char7 = Char7;
			StringType _Char8 = Char8;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SplitStringForXMTranSp";
				
				appDB.AddCommandParameter(cmd, "StringToSplit", _StringToSplit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Split1", _Split1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Split2", _Split2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Char1", _Char1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char2", _Char2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char3", _Char3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char4", _Char4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char5", _Char5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char6", _Char6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char7", _Char7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Char8", _Char8, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Char1 = _Char1;
				Char2 = _Char2;
				Char3 = _Char3;
				Char4 = _Char4;
				Char5 = _Char5;
				Char6 = _Char6;
				Char7 = _Char7;
				Char8 = _Char8;
				
				return (Severity, Char1, Char2, Char3, Char4, Char5, Char6, Char7, Char8);
			}
		}
	}
}
