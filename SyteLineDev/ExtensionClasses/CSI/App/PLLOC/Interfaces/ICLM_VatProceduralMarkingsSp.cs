using System;
using System.Data;
using CSI.Data.CRUD;

namespace PLLOC.Interfaces
{
    public interface ICLM_VatProceduralMarkingsSp
    {
        (ICollectionLoadResponse Data, int? ReturnCode) ExecuteSp(DateTime? BeginTaxDate = null,
        DateTime? BeginEndDate = null);
    }
}
