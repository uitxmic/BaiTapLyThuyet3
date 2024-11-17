using Newtonsoft.Json;

namespace Client
{
    public partial class ListBook : Form
    {
        readonly static string en_api = "QUl6YVN5QmVqSXl5Y2tZMnJ4VTlGbUc5UERoSzVwMTd5N0ZxTzBn";
        readonly static string userId = "113405051969637466754";
        public static int shelfID;
        public int ShelfID { get { return shelfID; } set { shelfID = value; } }
        readonly static string api_key = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(en_api));
        readonly static string requestUrl = $"https://www.googleapis.com/books/v1/users/{userId}/bookshelves/{shelfID}/volumes?key={api_key}";
        
        public ListBook()
        {
            InitializeComponent();
        }
        
        public ListBook(int shelfID)
        {
            InitializeComponent();
            this.ShelfID = shelfID;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    response.EnsureSuccessStatusCode();
                    string responseData = await response.Content.ReadAsStringAsync();
                    var volumesResponse = JsonConvert.DeserializeObject<VolumesResponse>(responseData);
                    if (volumesResponse?.Items != null && volumesResponse.Items.Count > 0)
                    {
                        foreach (var volume in volumesResponse.Items)
                        {
                            var info = volume.VolumeInfo;
                            string? id = (volume.Id).ToString();
                            string? title = info.Title;
                            string? authors = string.Join(", ", info.Authors ?? new List<string>());
                            string? desc = info.Description;
                            string[] item = { id, title, authors, desc };
                            ListViewItem ls = new ListViewItem(item);
                            ListViewItem add = list_book.Items.Add(ls);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No volumes found in this bookshelf.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            list_book.Select();
            if (list_book.SelectedItems.Count == 0) return;
            string volID = list_book.SelectedItems.ToString() ?? "";
            {
                BookInfo ins = new(volID);
                ins.Show();
            }
        }
    }

    public class Volume_Info
    {
        public string? Title;
        public List<string>? Authors;
        public string? Publisher;
        public string? Description;
        public string? PublishedDate;
    }

    public class Volume
    {
        public string? Id;
        public Volume_Info? VolumeInfo;
    }

    public class VolumesResponse
    {
        public string? Kind;
        public List<Volume>? Items;
    }
}
