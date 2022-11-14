namespace Model
{
    public interface IEmployee <E>
    {
      public string EmployeeCode { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string MaidenName { get; set; }
      public int LanguageId { get; set; }
      public string Password { get; set; }
      public byte[] Picture { get; set; }
      public string SSN { get; set; }
      public string FullName { get; set; }
      public string Phone1 { get; set; }
      public string Phone2 { get; set; }
      public string Address1 { get; set; }
      public string Address2 { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string ZipCode { get; set; }
      public string JobCodeId { get; set; }
      public string ExternalID { get; set; }
      public string DepartmentId { get; set; }
      public string Email { get; set; }
      public string StatusCode { get; set; }
      public string PunchId { get; set; }
      public int FileNo { get; set; }
      public bool Deleted { get; set; }
      public int ShiftNo { get; set; }
      public DateTime HireDate { get; set; }
      public DateTime LeaveDate { get; set; }
      public string Notes { get; set; }
      public string Info1 { get; set; }
      public string Info2 { get; set; }
      public string Info3 { get; set; }
      public string Info4 { get; set; }
      public double CommissionPercent { get; set; }
      public string PIN { get; set; }
      public DateTime DOB { get; set; }
      public string Gender { get; set; }
      public byte[] FingerPrint { get; set; }
      public decimal MaxDiscountPercent { get; set; }
      public int CustomerNoReference { get; set; }
      public int HomeStoreNo { get; set; }
      public string CreatedBy { get; set; }
      public DateTime CreationDate { get; set; }
      public string ModifiedBy { get; set; }
      public DateTime ChangeDate { get; set; }
      public bool ChangePassword { get; set; }
      public DateTime PasswordExpDate { get; set; }
      public string JobPosition { get; set; }
      public string JobTypeCode { get; set; }
      public bool PreAllocationMultipleCells { get; set; }
      public bool PostAllocationMultipleCells { get; set; }
      public bool StockBalanceMultipleCells { get; set; }
      public bool StockBalanceShowQtyInput { get; set; }
      public bool StockBalanceShowSoldQty { get; set; }
      public bool StockBalanceShowOnHandQty { get; set; }
      public bool StockBalanceShowOnOrderQty { get; set; }
      public bool StockBalanceShowMinQty { get; set; }
      public bool StockBalanceShowMaxQty { get; set; }
      public bool StockBalanceShowTransferQty { get; set; }
      public bool StockBalanceShowInTransitQty { get; set; }
      public bool StockBalanceShowCommittedQty { get; set; }
      public bool StockBalanceShowAvailableQty { get; set; }
      public bool StockBalanceShowDaysInStock { get; set; }
      public bool StockBalanceShowROI { get; set; }
      public DateTime PasswordDate { get; set; }
      public int UDF1 { get; set; }
      public int UDF2 { get; set; }
      public int UDF3 { get; set; }
      public bool PollCreated { get; set; }
      public bool POApprover1 { get; set; }
      public bool POApprover2 { get; set; }
      public bool POApprover3 { get; set; }
      public byte PollStatusCode { get; set; }
      public byte ResetPollStatusCode { get; set; }



      public List<E> GetList();
      public List<E> GetByEmployeeCode(string sEmployeeCode);
      public void Post(E employee);
      public void Put(E employee);
      public void Delete(E employee);
   }
}
