using System.Data;

namespace Model
{
    public interface IReceipt<R, RL, RT>
    {
      public int StoreNo { get; set; }
      public Guid ReceiptId { get; set; }
      public int ReceiptNo { get; set; }
      public string SalesCode { get; set; }
      public DateTime SalesDate { get; set; }
      public string StatusCode { get; set; }
      public int CustomerNo { get; set; }
      public int AddressNo { get; set; }
      public int ShipToCustomerNo { get; set; }
      public int ShipToAddressNo { get; set; }
      public Guid SOId { get; set; }
      public int SOStoreNo { get; set; }
      public int SOShippingId { get; set; }
      public int SONo { get; set; }
      public string SONumber { get; set; }
      public int Flag1 { get; set; }
      public int Flag2 { get; set; }
      public int Flag3 { get; set; }
      public string NoteField { get; set; }
      public string Cashier { get; set; }
      public string DocNumber { get; set; }
      public decimal SubTotal { get; set; }
      public decimal SubTotalWTax { get; set; }
      public DateTime ShippingDate { get; set; }
      public int TaxAreaCode { get; set; }
      public decimal TaxPercent { get; set; }
      public decimal TaxTotal { get; set; }
      public short ShipViaCode { get; set; }
      public decimal ShippingTotal { get; set; }
      public int FeeId { get; set; }
      public decimal FeeTaxPercent { get; set; }
      public decimal FeeTotal { get; set; }
      public decimal FeeTotalWTax { get; set; }
      public decimal FeeTaxAmount { get; set; }
      public decimal PayTotal { get; set; }
      public decimal DiscPercent { get; set; }
      public decimal DiscTotal { get; set; }
      public decimal DiscTotalWTax { get; set; }
      public decimal FCSubTotal { get; set; }
      public decimal FCSubTotalWTax { get; set; }
      public decimal FCTaxTotal { get; set; }
      public decimal FCShippingTotal { get; set; }
      public decimal FCFeeTotal { get; set; }
      public decimal FCFeeTotalWTax { get; set; }
      public decimal FCFeeTaxAmount { get; set; }
      public decimal FCPayTotal { get; set; }
      public decimal FCDiscTotal { get; set; }
      public decimal FCDiscTotalWTax { get; set; }
      public string CreatedBy { get; set; }
      public DateTime CreationDate { get; set; }
      public string ModifiedBy { get; set; }
      public DateTime ChangeDate { get; set; }
      public short LineCount { get; set; }
      public string Version { get; set; }
      public string Notes { get; set; }
      public string Notes2 { get; set; }
      public string Notes3 { get; set; }
      public int WeekId { get; set; }
      public string RegisterId { get; set; }
      public bool VAT { get; set; }
      public byte CurrencyId { get; set; }
      public decimal ExchangeRate { get; set; }
      public bool Invoiced { get; set; }
      public string DocReference { get; set; }
      public int ReverseDocNo { get; set; }
      public bool RewardProcessed { get; set; }
      public bool GLProcessed { get; set; }
      public DateTime GLDate { get; set; }
      public bool DWProcessed { get; set; }
      public DateTime DWDate { get; set; }
      public bool ACCT1Processed { get; set; }
      public DateTime ACCT1Date { get; set; }
      public bool ACCT2Processed { get; set; }
      public DateTime ACCT2Date { get; set; }
      public bool ACCT3Processed { get; set; }
      public DateTime ACCT3Date { get; set; }
      public int SourceStore { get; set; }
      public int LoyaltyPointsEarned { get; set; }
      public string LoyaltyAuthorization { get; set; }
      public string ReasonCode { get; set; }
      public string ManagerOverwrite { get; set; }
      public string ReceiptZipCode { get; set; }
      public decimal TakeBase { get; set; }
      public decimal TakeExchange { get; set; }
      public string Info1 { get; set; }
      public string Info2 { get; set; }
      public string Info3 { get; set; }
      public string Info4 { get; set; }
      public string Info5 { get; set; }
      public string Info6 { get; set; }
      public string Info7 { get; set; }
      public string Info8 { get; set; }
      public string Info9 { get; set; }
      public string Info10 { get; set; }
      public string Info11 { get; set; }
      public string Info12 { get; set; }
      public bool ManualReceipt { get; set; }
      public string ReferenceId { get; set; }
      public string RegisterSN { get; set; }
      public int ZOutNo { get; set; }
      public string CustomerEmail { get; set; }
      public bool EReceipt { get; set; }
      public string EReceiptInfo { get; set; }
      public string CustomerCampaign { get; set; }
      public bool RemoteSale { get; set; }
      public string OriginalCustomerData { get; set; }
      public byte PollStatusCode { get; set; }
      public byte ResetPollStatusCode { get; set; }
      public bool HQHistory { get; set; }
      public List<RL> ReceiptLine { get; set; }
      public List<RT> ReceiptTender { get; set; }


      dynamic GetList();
      dynamic GetByDocNumber(string sDocNumeber);
      dynamic GetByDate(string sDate);

   }
}
