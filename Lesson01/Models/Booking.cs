namespace Lesson01.Models;

// TODO L01 TASK 5a: Data annotate the properties.

public class Booking
{
    public int Id { get; set; }

    //[________(ErrorMessage = "NRIC is required")]
    //[_________________(@"[STFG]\d{7}[A-Z]", ErrorMessage = "Invalid NRIC Format")]
    public string NRIC { get; set; } = null!;

    //[________(ErrorMessage = "Owner name is required")]
    public string OwnerName { get; set; } = null!;

    //[________(ErrorMessage = "Pet name is required")]
    public string PetName { get; set; } = null!;

    //[________(ErrorMessage = "Duration is required")]
    //[_____(1, 5, ErrorMessage = "Duration must be between 1 and 5 days")]
    public int Duration { get; set; }

    //[________(ErrorMessage = "Pet Type is required")]
    public int PetTypeId { get; set; }

    //[________(ErrorMessage = "Feeding Frequency is required")]
    //[_____(0, 2, ErrorMessage = "Feeding Frequency must be between 0 and 2")]
    public int FeedFreq { get; set; }

    //[________(ErrorMessage = "Check-in date is required")]
    [DataType(DataType.Date)]
    public DateTime CheckInDate { get; set; }

    public bool FTCanned { get; set; }
    public bool FTDry { get; set; }
    public bool FTSoft { get; set; }
}

