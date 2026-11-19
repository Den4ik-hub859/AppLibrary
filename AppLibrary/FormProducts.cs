using AppLibrary.Models;
using AppLibrary.Properties;

namespace AppLibrary
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
            this.Load += FormProducts_Load;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {
            LoadProducts();
            flowLayoutPanelProducts.Dock = DockStyle.Fill;
            flowLayoutPanelProducts.AutoScroll = true;
        }

        private void LoadProducts()
        {
            flowLayoutPanelProducts.Controls.Clear();

            using (var db = new MyDbContext())
            {
                var books = db.Books
                    .Select(b => new
                    {
                        Book = b,
                        dateOfLoan = db.BookLoans
                            .Where(l => l.Isbn == b.Isbn)
                            .Select(l => (DateOnly?)l.DateIssue)
                            .FirstOrDefault(),

                        GenreName = b.Genre.GenreName,
                        AuthorName = b.Author.AuthorName,
                        PublisherName = b.PublishHouse.PublishHouseName
                    })
                    .ToList();

                foreach (var p in books)
                {
                    CardProduct card = new CardProduct();

                    Image productImg = LoadProductPhoto(p.Book.Image);

                    var oneMonthAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

                    bool isOverdue = p.dateOfLoan.HasValue && p.dateOfLoan.Value < oneMonthAgo;

                    card.FillData(
                        ISBN: p.Book.Isbn,
                        author: p.AuthorName,
                        name: p.Book.BookName,
                        genre: p.GenreName,
                        publisher: p.PublisherName,
                        year_pub: p.Book.YearPub,
                        pages: p.Book.Pages,
                        totalPairs: p.Book.Copies,
                        avaliablePairs: p.Book.Available,
                        isOverdue: isOverdue,
                        annotation: p.Book.Annotation,
                        productImages: productImg
                    );

                    flowLayoutPanelProducts.Controls.Add(card);
                }
            }
        }

        private Image LoadProductPhoto(string? photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl))
            {
                object obj = Resources.ResourceManager.GetObject(photoUrl);
                if (obj != null)
                {
                    return (Image)obj;
                }
            }
            return Resources.picture;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}