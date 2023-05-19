using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace RFR340_HFT_WpfClient
{
    internal class BookWindowViewModel:ObservableRecipient
    {
        public RestService<Book> books { get; set; }

        private Book sBook;

        public Book SBook
        {
            get { return sBook; }
            set
            {
                SetProperty(ref sBook, value);
                OnPropertyChanged();
                (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }



        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public BookWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                books = new RestService<Book>("http://localhost:4738/", "book", "hub");

                CreateBookCommand = new RelayCommand(() =>
                {
                    books.Add(new Book()
                    {
                        Title = SBook.Title,
                        Author = SBook.Author,
                        PublisherID=SBook.PublisherID
                    });
                });

                DeleteBookCommand = new RelayCommand(() =>
                {
                    books.Delete(sBook.BookID);
                },
                () =>
                {
                    return sBook != null;
                }
                );
                UpdateBookCommand = new RelayCommand(() =>
                {
                    books.Update(sBook);
                });

                SBook = new Book();
            }
        }

    }
}
