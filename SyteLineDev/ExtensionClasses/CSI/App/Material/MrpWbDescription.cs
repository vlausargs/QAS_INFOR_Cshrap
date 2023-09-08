//PROJECT NAME: Material
//CLASS NAME: MrpWbDescription.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbDescription : IMrpWbDescription
	{
		readonly IApplicationDB appDB;
		
		public MrpWbDescription(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MrpWbDescriptionFn(
			string MrpWbRefType,
			string MrpWbRefNum,
			int? MrpWbRefLineSuf,
			int? MrpWbRefRelease,
			int? MrpWbRefSeq,
			string MrpWbItem)
		{
			RefTypeIJKMNOTType _MrpWbRefType = MrpWbRefType;
			UnknownRefNumLastTranType _MrpWbRefNum = MrpWbRefNum;
			UnknownRefLineType _MrpWbRefLineSuf = MrpWbRefLineSuf;
			UnknownRefReleaseType _MrpWbRefRelease = MrpWbRefRelease;
			JobmatlProjmatlSeqType _MrpWbRefSeq = MrpWbRefSeq;
			ItemType _MrpWbItem = MrpWbItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpWbDescription](@MrpWbRefType, @MrpWbRefNum, @MrpWbRefLineSuf, @MrpWbRefRelease, @MrpWbRefSeq, @MrpWbItem)";
				
				appDB.AddCommandParameter(cmd, "MrpWbRefType", _MrpWbRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbRefNum", _MrpWbRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbRefLineSuf", _MrpWbRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbRefRelease", _MrpWbRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbRefSeq", _MrpWbRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbItem", _MrpWbItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
