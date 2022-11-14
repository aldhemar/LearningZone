namespace Model
{
    public interface IReceiptLine
    {
      public int StoreNo { get; set; }
      public Guid ReceiptId { get; set; }
      public short LineId { get; set; }
      public int CustomerNo { get; set; }
      public DateTime SalesDate { get; set; }
      public string StatusCode { get; set; }
      public string SalesCode { get; set; }
      public string SalesType { get; set; }
      public int SKU { get; set; }
      public string UPC { get; set; }
      public string Clerk { get; set; }
      public string ReasonCode { get; set; }
      public decimal CaseQty { get; set; }
      public decimal PackQty { get; set; }
      public string UOMCode { get; set; }
      public decimal Qty { get; set; }
      public decimal RetailPrice { get; set; }
      public decimal OriginalPrice { get; set; }
      public decimal ExtRetailPrice { get; set; }
      public decimal ExtCost { get; set; }
      public decimal AvgCost { get; set; }
      public decimal TaxAmount { get; set; }
      public decimal TaxPercent { get; set; }
      public decimal DiscAmount { get; set; }
      public decimal DiscPercent { get; set; }
      public bool Package { get; set; }
      public string SerialNumber { get; set; }
      public string RewardCertNumber { get; set; }
      public string LineDescription { get; set; }
      public string LineNotes { get; set; }
      public short TaxAreaCode { get; set; }
      public byte TaxCode { get; set; }
      public decimal OriginalPriceWTax { get; set; }
      public decimal RetailPriceWTax { get; set; }
      public decimal ExtRetailPriceWTax { get; set; }
      public decimal DiscAmountWTax { get; set; }
      public byte PriceLevelId { get; set; }
      public decimal FCRetailPrice { get; set; }
      public decimal ExtFCRetailPrice { get; set; }
      public decimal FCRetailPriceWTax { get; set; }
      public decimal ExtFCRetailPriceWTax { get; set; }
      public decimal FCDiscAmount { get; set; }
      public decimal FCDiscAmountWTax { get; set; }
      public decimal FCTaxAmount { get; set; }
      public decimal GlobalDiscPercent { get; set; }
      public bool HasNotes { get; set; }
      public short SOLineId { get; set; }
      public bool NonInventory { get; set; }
      public string AlternativeLookupCode { get; set; }
      public string DummyItemType { get; set; }
      public int PromoId { get; set; }
      public string Season { get; set; }
      public decimal FirstRetailPrice { get; set; }
      public int PriceEventNo { get; set; }
      public decimal ExtTaxAmount { get; set; }
      public decimal ExtFCTaxAmount { get; set; }
      public string ScannedValue { get; set; }
      public int ComboSKU { get; set; }
      public bool IsMarkDown { get; set; }
   }
}
