using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ETicaretMVC.ApiServices
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> DeleteData(string endPoint, string token = null)
        {
            var baseAddress = "http://localhost:5269/api/"; // API'nin temel adresi burada tanımlanıyor.
            var client = _httpClientFactory.CreateClient(); // HTTP istekleri için bir HttpClient nesnesi oluşturuluyor.

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete, // DELETE isteği yapılacağını belirtiyor (veri silme işlemi için kullanılır).
                RequestUri = new Uri($"{baseAddress}{endPoint}"), // İstek yapılacak URL, baseAddress ve endPoint birleştirilerek oluşturuluyor.
                Headers = { { HeaderNames.Accept, "application/json" } } // İstek başlığında JSON formatında veri kabul edileceği belirtiliyor.
            };

            var responseMessage = await client.SendAsync(requestMessage); // DELETE isteği gönderiliyor ve yanıt bekleniyor.

            return responseMessage.IsSuccessStatusCode; // Yanıt başarılıysa true, değilse false döndürülüyor.
        }


        public async Task<T> GetData<T>(string endPoint, string token = null)
        {
            var baseAddress = "http://localhost:5269/api/"; // API'nin temel adresi burada tanımlanıyor.
            var client = _httpClientFactory.CreateClient(); // HTTP isteklerini yapmak için bir HttpClient nesnesi oluşturuluyor.

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get, // GET isteği yapılacağını belirtiyor (genelde veri almak için kullanılır).
                RequestUri = new Uri($"{baseAddress}{endPoint}"), // İstek yapılacak URL, baseAddress ve endPoint birleştirilerek oluşturuluyor.
                Headers = { { HeaderNames.Accept, "application/json" } } // İstek başlığında JSON formatını kabul edileceği belirtiliyor.
            };

            var responseMessage = await client.SendAsync(requestMessage); // GET isteği gönderiliyor ve yanıt bekleniyor.

            var jsonResponse = await responseMessage.Content.ReadAsStringAsync(); // Yanıtın içeriği (JSON formatında) string olarak alınıyor.

            var responseObject = JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true // JSON'daki özellik adlarının büyük/küçük harf duyarsız şekilde eşleşmesini sağlar.
            });

            return responseObject; // Deserilize edilmiş (T türüne dönüştürülmüş) yanıt döndürülüyor.
        }

        public async Task<bool> PostData(string endPoint, string jsonData, string token = null)
        {
            var baseAddress = "http://localhost:5269/api/"; //// API'nin temel adresi burada tanımlanıyor.
            var client = _httpClientFactory.CreateClient();  // HTTP istekleri için bir HttpClient nesnesi oluşturuluyor.


            var requestMessage = new HttpRequestMessage() //Bir HttpRequestMessage nesnesi oluşturulur ve içine şunlar eklenir:
            {
                Method = HttpMethod.Post, // POST isteği yapılacağını belirtiyor.
                RequestUri = new Uri($"{baseAddress}{endPoint}"),  // İstek yapılacak URL, baseAddress ve endPoint birleştirilerek oluşturuluyor.
                Headers = { { HeaderNames.Accept, "application/json" } }, // İsteğin JSON formatında kabul edilmesini belirtiyor.
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")// Gönderilecek veri (jsonData) JSON formatına çevrilerek istek içeriği olarak ekleniyor.
            };
            var responseMessage = await client.SendAsync(requestMessage);// İstek gönderiliyor ve yanıt asenkron olarak bekleniyor.
            if (!responseMessage.IsSuccessStatusCode)// Eğer yanıt başarı durumunda değilse (ör. 400, 500 hataları).
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();  // Hata detayları okunuyor.
                Console.WriteLine($"Error: {responseMessage.StatusCode}, Content: {errorContent}");  // Hata kodu ve içeriği konsola yazdırılıyor.
            }

            return responseMessage.IsSuccessStatusCode; // İstek başarılıysa true, değilse false döndürülüyor.
           
        }

        public async Task<bool> PutData(string endPoint, string jsonData, string token = null)
        {
            var baseAddress = "http://localhost:5269/api/"; // API'nin temel adresi burada tanımlanıyor.
            var client = _httpClientFactory.CreateClient(); // HTTP istekleri için bir HttpClient nesnesi oluşturuluyor.

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put, // PUT isteği yapılacağını belirtiyor (genelde veri güncelleme için kullanılır).
                RequestUri = new Uri($"{baseAddress}{endPoint}"), // İstek yapılacak URL, baseAddress ve endPoint birleştirilerek oluşturuluyor.
                Headers = { { HeaderNames.Accept, "application/json" } }, // İsteğin JSON formatında kabul edilmesini belirtiyor.
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json") // Gönderilecek veri (jsonData) JSON formatına çevrilerek istek içeriği olarak ayarlanıyor.
            };

            var responseMessage = await client.SendAsync(requestMessage); // PUT isteği gönderiliyor ve yanıt bekleniyor.

            return responseMessage.IsSuccessStatusCode; // Yanıt başarılıysa true, değilse false döndürülüyor.
        }


    }
}
