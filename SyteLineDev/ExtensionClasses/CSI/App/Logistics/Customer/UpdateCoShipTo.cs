//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCoShipTo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IUpdateCoShipTo
	{
		int UpdateCoShipToSp(Guid? RowPointer,
		                     int? CustSeq,
		                     ref string Infobar);
	}
	
	public class UpdateCoShipTo : IUpdateCoShipTo
	{
		readonly IApplicationDB appDB;
		
		public UpdateCoShipTo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdateCoShipToSp(Guid? RowPointer,
		                            int? CustSeq,
		                            ref string Infobar)
		{
			RowPointerType _RowPointer = RowPointer;
			CustSeqType _CustSeq = CustSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateCoShipToSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
