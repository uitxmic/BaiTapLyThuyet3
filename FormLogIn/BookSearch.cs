using System.Data;
using Newtonsoft.Json;

namespace Client
{
    public partial class BookSearch : Form
    {
        readonly static string en_api = "QUl6YVN5QmVqSXl5Y2tZMnJ4VTlGbUc5UERoSzVwMTd5N0ZxTzBn";
        readonly static string api_key = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(en_api));

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
                    string url = $"https://www.googleapis.com/books/v1/volumes?q={query}&key={api_key}";

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
                                Title = book?.volumeInfo?.title,
                                Authors = book?.volumeInfo?.authors != null ?
                                    string.Join(", ", book.volumeInfo.authors) : "Unknown",
                                Description = book?.volumeInfo?.description,
                                Thumbnail = book?.volumeInfo?.imageLinks?.thumbnail
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
                            dgvBooks.Columns["Description"].Width = 500;
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

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string? volumeId = dgvBooks.Rows[e.RowIndex].Cells["volumeId"].Value?.ToString();
                if (!string.IsNullOrEmpty(volumeId))
                {
                    BookInfo bookInfo = new BookInfo(volumeId);
                    bookInfo.Show();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy VolumeId.");
                }
            }
        }

        private void btnCreateShelf_Click(object sender, EventArgs e)
        {
            Bookshelf ins = new();
            ins.Show();
        }
    }

    public class BookList
    {
        public List<Items>? items;
    }
    public class Items
    {
        public string? id;
        public VolumeInfo? volumeInfo;
    }
    public class VolumeInfo
    {
        public string? title;

        public string? subtitle;            // Phụ đề của sách
        public List<string>? authors;      // Danh sách tác giả
        public string? publisher;       // Nhà xuất bản
        public string? publishedDate;   // Ngày xuất bản
        public string? description;     // Mô tả về sách
        public int pageCount { get; set; }          // Số trang
        public List<string>? categories; // Danh mục của sách
        public string? language;        // Ngôn ngữ
        public ImageLinks? imageLinks;   // Liên kết ảnh
    }
    public class ImageLinks
    {
        public string? thumbnail;       // URL ảnh bìa nhỏ
        public string? smallThumbnail;  // URL ảnh bìa nhỏ hơn (nếu có)
    }

}
