using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Cache
{
    public enum SQLPagedRecordStreamBookmarkID { 
        MyReport_Rpt, 
        Rpt_EstimateJobCostDetail_Job, 
        Rpt_EstimateJobCostDetail_Jobroute, 
        Rpt_EstimateJobCostDetail_Jobmatl,
        CLM_ExecutiveShipmentRevenue_Coitem,
        CLM_ExecutiveShipmentRevenue_Um
    }
    public enum SQLPagedRecordBunchBookmarkID { BunchingBookmark }
    public enum MGBookmark { Bookmark }
    public enum IdoMethodCallBoundedMemoryCacheNamespace { MyReport_Rpt }
    public enum MGSessionVariableBasedCacheNamespace { MyReport_Rpt }

    public enum CachePageSize { XSmall = 10, Small = 50, Middle = 500, Large = 2000, XLarge = 5000 }

    public enum LoadType
    {
        First,
        Next
    }

    public enum BunchType
    {
        Load,
        Insert,
        Update,
        Delete
    }
}