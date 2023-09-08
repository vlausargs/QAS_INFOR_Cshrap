//PROJECT NAME: Production
//CLASS NAME: ICLM_JobRouteOEE.cs

using CSI.Data.CRUD;

namespace CSI.Production
{
	public interface ICLM_JobRouteOEE
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_JobRouteOEESp(
			decimal? OEE);
	}
}

