//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterialLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBillOfMaterialLines
	{
		int LoadESBBillOfMaterialLinesSp(string Item,
		                                 string ParentItem,
		                                 string RevisionID,
		                                 int? OperNum,
		                                 short? BomSeq,
		                                 decimal? QtyReleased,
		                                 string Wc,
		                                 string ParentDescription,
		                                 string Stat,
		                                 string DocRevision,
		                                 ref string Infobar);
	}
	
	public class LoadESBBillOfMaterialLines : ILoadESBBillOfMaterialLines
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBillOfMaterialLines(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBillOfMaterialLinesSp(string Item,
		                                        string ParentItem,
		                                        string RevisionID,
		                                        int? OperNum,
		                                        short? BomSeq,
		                                        decimal? QtyReleased,
		                                        string Wc,
		                                        string ParentDescription,
		                                        string Stat,
		                                        string DocRevision,
		                                        ref string Infobar)
		{
			ItemType _Item = Item;
			ItemType _ParentItem = ParentItem;
			RevisionType _RevisionID = RevisionID;
			OperNumType _OperNum = OperNum;
			EcnBomSeqType _BomSeq = BomSeq;
			QtyPerType _QtyReleased = QtyReleased;
			WcType _Wc = Wc;
			DescriptionType _ParentDescription = ParentDescription;
			JobStatusType _Stat = Stat;
			RevisionType _DocRevision = DocRevision;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBillOfMaterialLinesSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionID", _RevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSeq", _BomSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentDescription", _ParentDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocRevision", _DocRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
