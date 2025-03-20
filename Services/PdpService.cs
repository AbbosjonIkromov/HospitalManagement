using HospitalManagement.Dtos;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Services
{
    public class PdpService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly PdpSettings _pdpSettings;

        public PdpService(HttpClient httpClient,
                IConfiguration configuration,
                IOptions<PdpSettings> pdpSettings)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _pdpSettings = pdpSettings.Value;
        }

        public async Task<string> GetPdpData()
        {
            _httpClient.BaseAddress = new Uri(_pdpSettings.Endpoint);

            var response = await _httpClient
                .GetAsync($"?database_id={_pdpSettings.DataBaseId}&page_count={_pdpSettings.BatchCount}&all=true");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
