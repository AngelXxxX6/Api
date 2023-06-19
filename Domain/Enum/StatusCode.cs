namespace Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        UserNotFound = 100,
        PatientNotFound = 101,
        TicketNotFound =  102,
        DoctorNotFound = 103,
    }
}
