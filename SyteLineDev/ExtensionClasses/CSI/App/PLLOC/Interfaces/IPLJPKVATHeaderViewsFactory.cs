using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IPLJPKVATHeaderViewsFactory
    {
        (IJPKV7MHeader CreateHeader, IJPKV7MEntity1 CreateEntity1) Create(string SiteRef,
            string TaxRegNum,
            string PLVATSystemCode,
            string PLVATStructureVersion,
            string PLVATFormVariant,
            string PLVATOfficeCode,
            string SubmissionMode,
            DateTime BeginTaxDate,
            DateTime EndTaxDate);

        (IJPKV7MHeader CreateHeader, IJPKV7MEntity1 CreateEntity1) Create(string SiteRef,
            string TaxRegNum,
            string PLVATSystemCode,
            string PLVATStructureVersion,
            string PLVATFormVariant,
            string PLVATOfficeCode,
            string PLVATPhone,
            string PLVATEmailAddr,
            string SubmissionMode,
            DateTime BeginTaxDate,
            DateTime EndTaxDate);
    }
}
