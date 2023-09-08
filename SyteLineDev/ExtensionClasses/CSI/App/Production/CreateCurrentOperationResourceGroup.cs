//PROJECT NAME: Production
//CLASS NAME: CreateCurrentOperationResourceGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreateCurrentOperationResourceGroup : ICreateCurrentOperationResourceGroup
	{
		readonly IApplicationDB appDB;
		
		public CreateCurrentOperationResourceGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateCurrentOperationResourceGroupSp(
			string Item,
			int? JrtResGroupOperNum,
			string JrtResGroupRgid,
			int? JrtResGroupQtyResources,
			string JrtResGroupResactn,
			int? JrtResGroupSequence,
			string Infobar)
		{
			ItemType _Item = Item;
			OperNumType _JrtResGroupOperNum = JrtResGroupOperNum;
			ApsResgroupType _JrtResGroupRgid = JrtResGroupRgid;
			ResourcesType _JrtResGroupQtyResources = JrtResGroupQtyResources;
			ApsCodeType _JrtResGroupResactn = JrtResGroupResactn;
			ApsIntType _JrtResGroupSequence = JrtResGroupSequence;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCurrentOperationResourceGroupSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtResGroupOperNum", _JrtResGroupOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtResGroupRgid", _JrtResGroupRgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtResGroupQtyResources", _JrtResGroupQtyResources, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtResGroupResactn", _JrtResGroupResactn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtResGroupSequence", _JrtResGroupSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
