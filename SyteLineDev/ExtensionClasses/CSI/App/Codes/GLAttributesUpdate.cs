//PROJECT NAME: Codes
//CLASS NAME: GLAttributesUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GLAttributesUpdate : IGLAttributesUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public GLAttributesUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GLAttributesUpdateSp(int? UpdateAnalysisAttributes,
		int? OverwriteExsiting,
		DateTime? TransDateStarting,
		DateTime? TransDateEnding,
		string AccountStarting,
		string AccountEnding,
		string DimensionStarting,
		string DimensionEnding,
		string Infobar,
        int? CommitSize,
        int? Debug,
        int? TaskID,
        int? ChartCount)
		{
			ListYesNoType _UpdateAnalysisAttributes = UpdateAnalysisAttributes;
			ListYesNoType _OverwriteExsiting = OverwriteExsiting;
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			AcctType _AccountStarting = AccountStarting;
			AcctType _AccountEnding = AccountEnding;
			DimensionNameType _DimensionStarting = DimensionStarting;
			DimensionNameType _DimensionEnding = DimensionEnding;
			LongListType _Infobar = Infobar;
            GenericIntType _CommitSize = CommitSize;
            GenericIntType _Debug = Debug;
            TaskNumType _TaskID = TaskID;
            GenericIntType _ChartCount = ChartCount;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GLAttributesUpdateSp";
				
				appDB.AddCommandParameter(cmd, "UpdateAnalysisAttributes", _UpdateAnalysisAttributes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverwriteExsiting", _OverwriteExsiting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DimensionStarting", _DimensionStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DimensionEnding", _DimensionEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CommitSize", _CommitSize, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Debug", _Debug, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ChartCount", _ChartCount, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
