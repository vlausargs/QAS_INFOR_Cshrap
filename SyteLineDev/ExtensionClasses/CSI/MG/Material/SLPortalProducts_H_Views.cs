//PROJECT NAME: MaterialExt
//CLASS NAME: SLPortalProducts_H_Views.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLPortalProducts_H_Views")]
	public class SLPortalProducts_H_Views : ExtensionClassBase, ISLPortalProducts_H_Views
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PortalProductsCriteriaSaveSp(Guid? SessionID,
		                                        string Criteria,
		                                        string CriterionTypes,
		                                        string ResellerCustNum,
		                                        string CustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPortalProductsCriteriaSaveExt = new PortalProductsCriteriaSaveFactory().Create(appDb);
				
				var result = iPortalProductsCriteriaSaveExt.PortalProductsCriteriaSaveSp(SessionID,
				                                                                         Criteria,
				                                                                         CriterionTypes,
				                                                                         ResellerCustNum,
				                                                                         CustNum);
				
				
				return result.Value;
			}
		}
	}
}
