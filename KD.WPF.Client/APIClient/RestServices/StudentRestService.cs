using KD.WPF.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace KD.WPF.Client.APIClient.RestServices
{
    public class StudentRestService : RestServiceBase
    {
        public StudentRestService(IHttpClientFactory httpClientFactory, IClientApplicationConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<List<StudentModel>> GetAllStudentsAsync()
        {
            using (HttpClient client = GetClient())
            {
                HttpRequestMessage request = await PrepareRequestMessageAsync(HttpMethod.Get, string.Format("{0}/api/Students", serverAddress));
                var response = await client.SendAsync(request);
                var payload = DeserializeObject<List<StudentModel>>(await response.Content.ReadAsStringAsync());
                return payload;
            }
        }

        public async Task<StudentModel> GetStudentAsync(Guid studentId)
        {
            using (HttpClient client = GetClient())
            {
                HttpRequestMessage request = await PrepareRequestMessageAsync(HttpMethod.Get, string.Format("{0}/api/Students/{1}", serverAddress, studentId));
                var response = await client.SendAsync(request);
                var payload = DeserializeObject<StudentModel>(await response.Content.ReadAsStringAsync());
                return payload;
            }
        }

        public async Task<StudentModel> CreateStudentAsync(StudentModel student)
        {
            using (HttpClient client = GetClient())
            {
                var response = client.PostAsJsonAsync<StudentModel>(string.Format("{0}/api/Students", serverAddress), student).Result;
                var payload = DeserializeObject<StudentModel>(response.Content.ReadAsStringAsync().Result);
                return payload;
            }
        }

        public async Task<StudentModel> UpdateStudentAsync(Guid studentId, StudentModel student)
        {
            using (HttpClient client = GetClient())
            {
                var request = await PrepareRequestMessageAsync(HttpMethod.Put, string.Format("{0}/api/Students/{1}", serverAddress, studentId));
                var jsonPayload = SerializeObject(student);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                var payload = DeserializeObject<StudentModel>(response.Content.ReadAsStringAsync().Result);
                return payload;
            }
        }


        public async Task DeleteStudentAsync(Guid studentId)
        {           
            using (HttpClient client = GetClient())
            {

                var request = await PrepareRequestMessageAsync(HttpMethod.Delete, string.Format("{0}/api/Students/{1}", serverAddress, studentId));
                var response = await client.SendAsync(request);
                await Task.CompletedTask;
            }
        }
    }
}
