using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class BookInfo : Form
    {
        string volumeId;

        public BookInfo(string volumeId)
        {
            InitializeComponent();
            volumeId = volumeId ?? "";
            Task.Run(() => GetBookDetails(volumeId));

        }
        private async Task GetBookDetails(string volumeId)
        {
            rtbDetails.Clear();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://www.googleapis.com/books/v1/volumes/{volumeId}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResult = await response.Content.ReadAsStringAsync();
                        JObject data = JObject.Parse(jsonResult);

                        string title = data["volumeInfo"]["title"]?.ToString() ?? "N/A";
                        string authors = data["volumeInfo"]["authors"] != null
                            ? string.Join(", ", data["volumeInfo"]["authors"])
                            : "N/A";
                        string description = data["volumeInfo"]["description"]?.ToString() ?? "N/A";
                        string image = data["volumeInfo"]["imageLinks"]?["thumbnail"]?.ToString() ?? "N/A";
                        _ = Task.Run(() => LoadPosterImageAsync(image));
                        rtbDetails.AppendText($"Title: {title}\nAuthors: {authors}\nDescription: {description}");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi gọi API: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin sách: {ex.Message}");
            }
        }

        private async Task LoadPosterImageAsync(string imageUrl)
        {
            try
            {
                using HttpClient client = new();
                var imageStream = await client.GetStreamAsync(imageUrl);
                pictureBox1.Image = Image.FromStream(imageStream);
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

    }
}
