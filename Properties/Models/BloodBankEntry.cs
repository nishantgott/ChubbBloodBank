namespace Models.BloodBankEntry
{
    public class BloodBankEntry
    {
        public int Id { get; set; }
        public required string DonorName { get; set; }
        public int Age { get; set; }
        public required string BloodType { get; set; }
        public required string ContactInfo { get; set; }
        public int Quantity { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public required string Status { get; set; }
    }
}

