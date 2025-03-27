namespace HospitalManagement.Services.Contracts
{
    public interface INotificationService
    {
        Task Nofify(int doctorId, int[] patientIds);
    }
}
