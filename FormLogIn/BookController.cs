using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class BookController
    {
        private readonly HttpClient _httpClient;
        public BookController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetBooksAsync(string query)
        {
            string url = $"https://www.googleapis.com/books/v1/volumes?q={query}&key=AIzaSyDV-pJe7Zk4qyOCCl2QL-Sq-j8calCQCzU";
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Vary", "Origin");
            _httpClient.DefaultRequestHeaders.Add("Vary", "X-Origin");
            _httpClient.DefaultRequestHeaders.Add("Vary", "Referer");
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            HttpResponseMessage response; 
            try 
            { 
                response = await _httpClient.GetAsync(url); 
            }
            catch (HttpRequestException e)
            { 
                // Xử lý lỗi khi không thể kết nối đến API
                throw new Exception("Không thể kết nối đến API. Vui lòng kiểm tra kết nối mạng hoặc URL của bạn.", e); } 
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync(); 
                try 
                { 
                    var errorJson = JsonDocument.Parse(errorContent); 
                    var errorDetail = errorJson.RootElement.GetProperty("detail").GetString(); 
                    throw new Exception(errorDetail); }
                catch (JsonException) 
                { 
                    // Xử lý lỗi khi không thể phân tích cú pháp JSON trả về
                    throw new Exception($"Yêu cầu không thành công với trạng thái: {response.StatusCode}, Nội dung lỗi: {errorContent}"); 
                } 
            } 
            return await response.Content.ReadAsStringAsync();
        }

    }
}
