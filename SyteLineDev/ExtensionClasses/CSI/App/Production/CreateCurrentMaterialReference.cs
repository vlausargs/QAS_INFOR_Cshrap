//PROJECT NAME: Production
//CLASS NAME: CreateCurrentMaterialReference.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreateCurrentMaterialReference : ICreateCurrentMaterialReference
	{
		readonly IApplicationDB appDB;
		
		public CreateCurrentMaterialReference(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateCurrentMaterialReferenceSp(
			string Item,
			int? JobRefOperNum,
			int? JobRefSequence,
			int? JobRefRefSeq,
			string JobRefRefDes,
			string JobRefBubble,
			string JobRefAssySeq,
			string Infobar)
		{
			ItemType _Item = Item;
			OperNumType _JobRefOperNum = JobRefOperNum;
			JobmatlSequenceType _JobRefSequence = JobRefSequence;
			JobRefSeqType _JobRefRefSeq = JobRefRefSeq;
			RefDesignatorType _JobRefRefDes = JobRefRefDes;
			BubbleType _JobRefBubble = JobRefBubble;
			AssemblySeqType _JobRefAssySeq = JobRefAssySeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCurrentMaterialReferenceSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefOperNum", _JobRefOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefSequence", _JobRefSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefRefSeq", _JobRefRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefRefDes", _JobRefRefDes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefBubble", _JobRefBubble, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRefAssySeq", _JobRefAssySeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
