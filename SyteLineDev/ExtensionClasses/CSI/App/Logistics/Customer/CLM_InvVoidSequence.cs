//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_InvVoidSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_InvVoidSequence
	{
		DataTable CLM_InvVoidSequenceSp(string PArtranType,
		                                string PVoidThroughInvNum,
		                                string PStartingInvNum,
		                                string PEndingInvNum,
		                                string Pinv_category);
	}
	
	public class CLM_InvVoidSequence : ICLM_InvVoidSequence
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_InvVoidSequence(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_InvVoidSequenceSp(string PArtranType,
		                                       string PVoidThroughInvNum,
		                                       string PStartingInvNum,
		                                       string PEndingInvNum,
		                                       string Pinv_category)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ArtranTypeType _PArtranType = PArtranType;
				InvNumType _PVoidThroughInvNum = PVoidThroughInvNum;
				InvNumType _PStartingInvNum = PStartingInvNum;
				InvNumType _PEndingInvNum = PEndingInvNum;
				InvCategoryType _Pinv_category = Pinv_category;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_InvVoidSequenceSp";
					
					appDB.AddCommandParameter(cmd, "PArtranType", _PArtranType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PVoidThroughInvNum", _PVoidThroughInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartingInvNum", _PStartingInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndingInvNum", _PEndingInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Pinv_category", _Pinv_category, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
