//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBillOfMaterials
	{
		int LoadESBBillOfMaterialsSp(string ParentItem,
		                             string ActionExpression,
		                             string RevisionID,
		                             string Description,
		                             string Stat,
		                             string DocRevision,
		                             ref string Infobar);
	}
	
	public class LoadESBBillOfMaterials : ILoadESBBillOfMaterials
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBillOfMaterials(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBillOfMaterialsSp(string ParentItem,
		                                    string ActionExpression,
		                                    string RevisionID,
		                                    string Description,
		                                    string Stat,
		                                    string DocRevision,
		                                    ref string Infobar)
		{
			ItemType _ParentItem = ParentItem;
			StringType _ActionExpression = ActionExpression;
			RevisionType _RevisionID = RevisionID;
			DescriptionType _Description = Description;
			JobStatusType _Stat = Stat;
			RevisionType _DocRevision = DocRevision;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBillOfMaterialsSp";
				
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionID", _RevisionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
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
