using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Dtos
{
    public class PdpSettings
    {
        public string Endpoint { get; set; }

        public string DataBaseId { get; set; }

        public int BatchCount { get; set; }
    }
}
