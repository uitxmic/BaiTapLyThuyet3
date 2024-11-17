using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualBasic.ApplicationServices;
using Google.Apis;
using Google.Apis.Books.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.Net;
using Google.Apis.Books.v1.Data;
using Newtonsoft.Json;
//using System.Text.Json;

namespace Client
{

    public partial class Bookshelf : Form
    {
        readonly static string apikey = "AIzaSyBejIyyckY2rxU9FmG9PDhK5p17y7FqO0g"; //Placeholder
        //readonly static string auth = string.Empty; //Placeholder
        readonly static string userId = "113405051969637466754"; //
        readonly static string requestUrl = $"https://www.googleapis.com/books/v1/users/{userId}/bookshelves?key={apikey}";
        public Bookshelf()
        {
            InitializeComponent();
        }


        async Task GetBookshelfList()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);


                    response.EnsureSuccessStatusCode();

                    // Read and display the response content
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (responseData != null)
                    {
                        MessageBox.Show(responseData);

                        var items = JsonConvert.DeserializeObject<Response>(responseData);
                        if (items == null)
                        {
                            MessageBox.Show("No response found");
                        }
                        else if (items.Items == null)
                        {
                            MessageBox.Show("No bookshelves found");
                        }
                        else
                        {
                            foreach (var shelf in items.Items)
                            {
                                //MessageBox.Show($"- {shelf.Title} (ID: {shelf.Id}, Volumes: {shelf.VolumeCount})");

                                string? id = Convert.ToString(shelf.id);
                                string? title = shelf.title;
                                string? volcnt = shelf.volumeCount.ToString();
                                string[] item = { id, title, volcnt };
                                //TODO: Somehow suppress warnings about NULL above this line
                                ListViewItem ls = new ListViewItem(item);
                                ListViewItem add = listBS.Items.Add(ls);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        async Task GetBookshelfListOAuth()
        {
            string credPath = "cred.json";
            string[] scope = { BooksService.Scope.Books };
            try
            {
                UserCredential cred = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromFile(credPath).Secrets,
                    scope,
                    "auth_user",
                    CancellationToken.None
                );
                MessageBox.Show("Connect Successful");
                var booksService = new BooksService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = cred,
                    ApplicationName = "Book Show"
                }
                );
                var bookshelvesRequest = booksService.Mylibrary.Bookshelves.List();
                Bookshelves bookshelves = await bookshelvesRequest.ExecuteAsync();
                if (bookshelves.Items != null && bookshelves.Items.Count > 0)
                {
                    //Console.WriteLine("User's Bookshelves:");
                    foreach (var shelf in bookshelves.Items)
                    {
                        //MessageBox.Show($"- {shelf.Title} (ID: {shelf.Id}, Volumes: {shelf.VolumeCount})");

                        string? id = Convert.ToString(shelf.Id);
                        string? title = shelf.Title;
                        string? volcnt = shelf.VolumeCount.ToString();
                        string[] item = { id, title, volcnt };
                        //TODO: Somehow suppress these warnings about NULL above this line
                        ListViewItem ls = new ListViewItem(item);
                        ListViewItem add = listBS.Items.Add(ls);
                    }
                }
                else
                {
                    MessageBox.Show("No bookshelves found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}, {ex.InnerException}");
            }
        }

        private async void btnList_Click(object sender, EventArgs e)
        {
            //await GetBookshelfList();
            await GetBookshelfList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void listBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItemText = (listBS.SelectedItems.ToString() ?? "(none)").ToString();
            MessageBox.Show("Selected: " + selectedItemText);
        }
    }

    public class Item
    {
        public string? kind;
        public int id;
        public string? selfLink;
        public string? title;
        public string? access;
        public string? updated;
        public string? created;
        public int volumeCount;
        public string? volumesLastUpdated;
    }

    public class Response
    {
        public string? kind;
        public List<Item>? Items;
    }
}
