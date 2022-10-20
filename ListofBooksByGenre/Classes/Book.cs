using System;

namespace ListofBooksByGenre.Classes
{
    public class Book : PropertyChange
    {
        public int isbn;
        public string title;
        public string author;
        public Nullable<int> noOfPages;
        public string publishCompany;
        public LiteraryGenres literaryGenre;
        public Book() { }

        public Book(string title, string author, Nullable<int> noOfPages, string publishCompany, int isbn, string literaryGenre)
        {
            this.title = title;
            this.author = author;
            this.noOfPages = noOfPages;
            this.publishCompany = publishCompany;
            this.isbn = isbn;
            this.literaryGenre = (LiteraryGenres)Enum.Parse(typeof(LiteraryGenres), literaryGenre);
        }
        public int ISBN
        {
            get { return isbn; }
            set { isbn = value; Notifica("ISBN"); }
        }
        public string Title
        {
            get { return title; }
            set { title = value; Notifica("Title"); }
        }
        public string Author
        {
            get { return author; }
            set { author = value; Notifica("Author"); }
        }
        public Nullable<int> NoOfPages
        {
            get { return noOfPages; }
            set { noOfPages = value; Notifica("NoOfPages"); }
        }
        public string PublishCompany
        {
            get { return publishCompany; }
            set { publishCompany = value; Notifica("PublishCompany"); }
        }
        public LiteraryGenres LiteraryGenre
        {
            get { return literaryGenre; }
            set { literaryGenre = value; Notifica("LiteraryGenre"); }
        }
        public Book Clone()
        {
            return (Book)this.MemberwiseClone();
        }
        public void Update(Book NewBook)
        {

            Title = NewBook.Title;
            Author = NewBook.Author;
            NoOfPages = NewBook.NoOfPages;
            PublishCompany = NewBook.PublishCompany;
            LiteraryGenre = NewBook.LiteraryGenre;
            ISBN = NewBook.ISBN;
        }
    }
}
