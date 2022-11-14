using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ReceiptTender : Model.IReceiptTender
    {
        public int StoreNo { get ; set ; }
        public Guid ReceiptId { get ; set ; }
        public int LineId { get ; set ; }
        public byte CurrencyId { get ; set ; }
        public int TenderId { get ; set ; }
        public decimal TakeAmount { get ; set ; }
        public decimal GiveAmount { get ; set ; }
        public decimal ExchangeRate { get ; set ; }
        public string CardName { get ; set ; }
        public string CardNumber { get ; set ; }
        public string CardExpDate { get ; set ; }
        public string CardAuthorization { get ; set ; }
        public string CardHolderName { get ; set ; }
        public string CardSequenceNumber { get ; set ; }
        public string CardUniqueId { get ; set ; }
        public bool EFT { get ; set ; }
        public string CheckNumber { get ; set ; }
        public string CheckCompany { get ; set ; }
        public string CheckFirstName { get ; set ; }
        public string CheckLastName { get ; set ; }
        public string CheckPhone1 { get ; set ; }
        public string CheckPhone2 { get ; set ; }
        public DateTime CheckDOB { get ; set ; }
        public string CheckState { get ; set ; }
        public string CheckDriveLic { get ; set ; }
        public DateTime CheckDriveLicExp { get ; set ; }
        public decimal GiftCertAmount { get ; set ; }
        public string CheckAuthorization { get ; set ; }
        public string GiftCertNumber { get ; set ; }
        public string GiftCertAuthorization { get ; set ; }
        public string GiftCertSequenceNumber { get ; set ; }
        public short PaymentDay { get ; set ; }
        public DateTime PaymentDate { get ; set ; }
        public bool DebitSale { get ; set ; }
        public decimal TakeBase { get ; set ; }
        public decimal TakeExchange { get ; set ; }
        public string Notes { get ; set ; }
        public int PaymentId { get ; set ; }
        public byte[] Signature { get ; set ; }
        public int Quotas { get ; set ; }
        public string DeviceCode { get ; set ; }
        public string QRAuthorization { get ; set ; }
        public string QRUniqueId { get ; set ; }
        public string QRTransactionId { get ; set ; }
        public string QRSequenceNumber { get ; set ; }
        public DateTime QRTransactionDate { get ; set ; }
        public string QRAccountId { get ; set ; }
    }
}
