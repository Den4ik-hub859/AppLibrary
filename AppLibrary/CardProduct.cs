using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppLibrary
{
    public partial class CardProduct : UserControl
    {
        public CardProduct()
        {
            InitializeComponent();
        }
        public void FillData(string ISBN, string author, string name, string genre, string publisher,
                     int year_pub, int pages, int totalPairs, int avaliablePairs, bool isOverdue,
                     string annotation, Image productImages)
        {
            lblHeader.Text = $"{ISBN} | {name}";
            lblAuthor.Text = $"{author}\nЖанр: {genre}";
            lblPublish.Text = $"Издательство: {publisher}, год: {year_pub}";
            lblPages.Text = $"Количество страниц: {pages}";
            lblAvailable.Text = $"Экземпляров: {totalPairs}\nДоступно экземпляров: {avaliablePairs}";

            this.Tag = annotation;

            if (productImages != null)
            {
                pbImage.Image = productImages;
            }
            else
            {
                pbImage.Image = Properties.Resources.picture;
            }

            if (isOverdue)
            {
                this.BackColor = ColorTranslator.FromHtml("#D4EDDA");
            }
            else if (avaliablePairs == 0)
            {
                this.BackColor = ColorTranslator.FromHtml("#FFCCCC");
            }
            else if (avaliablePairs >= 1 && avaliablePairs <= 2)
            {
                this.BackColor = ColorTranslator.FromHtml("#FFF3CD");
            }
            else
            {
                this.BackColor = Color.White;
            }
        }
    }
}
