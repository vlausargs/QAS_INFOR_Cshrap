//PROJECT NAME: CSICustomer
//CLASS NAME: GetInteractionRefRowPointer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetInteractionRefRowPointer
	{
		int GetInteractionRefRowPointerSp(string InteractionRefType,
		                                  string RefNum,
		                                  ref Guid? RefRowPointer,
		                                  ref string Description,
		                                  ref string Infobar);
	}
	
	public class GetInteractionRefRowPointer : IGetInteractionRefRowPointer
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionRefRowPointer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetInteractionRefRowPointerSp(string InteractionRefType,
		                                         string RefNum,
		                                         ref Guid? RefRowPointer,
		                                         ref string Description,
		                                         ref string Infobar)
		{
			InteractionRefTypeType _InteractionRefType = InteractionRefType;
			StringType _RefNum = RefNum;
			RowPointerType _RefRowPointer = RefRowPointer;
			DescriptionType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetInteractionRefRowPointerSp";
				
				appDB.AddCommandParameter(cmd, "InteractionRefType", _InteractionRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefRowPointer = _RefRowPointer;
				Description = _Description;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
