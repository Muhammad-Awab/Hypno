namespace Hypnos.Data.Entities
{
    public class EntUserLogin
    {
            public string UserId { get; set; }
            public string? UserName { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string Password { get; set; }
            public string? ContactNo { get; set; }
            public string? BMI { get; set; }
            public string? Height { get; set; }
            public string? Weight { get; set; }
            public string? Neck_Circumference { get; set; }
            public string? Address { get; set; }

            //public string? Role { get; set; } = "User";
            public DateTime? DOB { get; set; }
            public string? Gender { get; set; }
        public string? Pharmacy { get; set; }

        public string? Payment_Info { get; set; }
        


    }
}
