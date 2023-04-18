namespace Lesson01.Models;

// TODO L01 TASK 3a: Data annotate the properties.
//                        BookingDate has been done for you as an example.
//                        Refer to worksheet for the validation requirements.
public class SRBooking
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please select a booking date")]
    [DataType(DataType.Date)]
    public DateTime BookingDate { get; set; }

    [Required(ErrorMessage = "Please select a slot")]
    public int SlotId { get; set; }

    [Required(ErrorMessage = "Please enter Name")]
    public string CustName { get; set; } = null!;

    [Required(ErrorMessage = "Please select a Package")]
    [Range(1, 3, ErrorMessage = "Package Id must be between 1 to 3")]
    public int PkgTypeId { get; set; }

    [Required(ErrorMessage = "Please select Duration")]
    [Range(1, 3, ErrorMessage = "Duration must be 1-3 hours")]
    public int Duration { get; set; }

    public bool AOSnack { get; set; }
    public bool AODrink { get; set; }

}
