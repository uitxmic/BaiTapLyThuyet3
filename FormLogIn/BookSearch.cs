using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Client
{
    public partial class BookSearch : Form
    {
        readonly static string APIKey = "AIzaSyBejIyyckY2rxU9FmG9PDhK5p17y7FqO0g";

        public BookSearch()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://www.googleapis.com/books/v1/volumes?q={query}&key={APIKey}";

                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        for (int i = 0; i <= 100; ++i) { progressBar1.Value = i; Thread.Sleep(10); }

                        string jsonResult = await response.Content.ReadAsStringAsync();
                        var books = JsonConvert.DeserializeObject<BookList>(jsonResult);

                        if (books != null && books.items != null)
                        {
                            var bookInfos = books.items.Select(book => new
                            {
                                volumeId = book.id,
                                Title = book.volumeInfo.title,
                                Authors = book.volumeInfo.authors != null ? 
                                    string.Join(", ", book.volumeInfo.authors) : "Unknown",
                                Description = book.volumeInfo.description,
                                Thumbnail = book.volumeInfo.imageLinks?.thumbnail
                            }).ToList();
                            
                            dgvBooks.DataSource = bookInfos;

                            if (!dgvBooks.Columns.Contains("volumeId"))
                            {
                                DataGridViewTextBoxColumn volumeIdColumn = new DataGridViewTextBoxColumn();
                                volumeIdColumn.Name = "volumeId";
                                volumeIdColumn.HeaderText = "Volume ID";
                                dgvBooks.Columns.Add(volumeIdColumn);
                            }

                            dgvBooks.Columns["volumeId"].Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Không có sách nào được tìm thấy.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi gọi API: {response.StatusCode}");
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async Task GetBookDetails(string volumeId)
        {
            BookInfo bookInfo = new BookInfo(volumeId);
            bookInfo.Show();
        }

        private async void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string volumeId = dgvBooks.Rows[e.RowIndex].Cells["volumeId"].Value?.ToString();
                if (!string.IsNullOrEmpty(volumeId))
                {
                    await GetBookDetails(volumeId);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy VolumeId.");
                }
            }
        }
    }

    public class BookList
    {
        public List<Items>? items { get; set; }
    }
    public class Items
    {
        public string? id { get; set; }            // Thêm field id cho Item
        public VolumeInfo? volumeInfo { get; set; }
    }
    public class VolumeInfo
    {
        public string? title { get; set; }

        public string? subtitle { get; set; }        // Phụ đề của sách
        public List<string>? authors { get; set; }   // Danh sách tác giả
        public string? publisher { get; set; }       // Nhà xuất bản
        public string? publishedDate { get; set; }   // Ngày xuất bản
        public string? description { get; set; }     // Mô tả về sách
        public int pageCount { get; set; }          // Số trang
        public List<string>? categories { get; set; } // Danh mục của sách
        public string? language { get; set; }        // Ngôn ngữ
        public ImageLinks? imageLinks { get; set; }   // Liên kết ảnh
    }
    public class ImageLinks
    {
        public string? thumbnail { get; set; }       // URL ảnh bìa nhỏ
        public string? smallThumbnail { get; set; }  // URL ảnh bìa nhỏ hơn (nếu có)
    }

}
