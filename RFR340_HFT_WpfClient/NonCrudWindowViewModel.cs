using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RFR340_HFT_2022231.Models.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RFR340_HFT_WpfClient
{
    public class NonCrudWindowViewModel : ObservableRecipient
    {
        public static RestService rest;

        public int PersonID { get; set; }

        public int BookID { get; set; }
        public string LabelC { get; set; }



        private ObservableCollection<BookInfo> bookInfos;

        public ObservableCollection<BookInfo> BookInfos
        {
            get
            {
                return bookInfos;
            }
            set
            {
                bookInfos = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<BookReadCount> bookReadCounts;

        public ObservableCollection<BookReadCount> BookReadCounts
        {
            get
            {
                return bookReadCounts;
            }
            set 
            {
                bookReadCounts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<NotReturned> notReturneds;

        public ObservableCollection<NotReturned> NotReturneds
        {
            get
            {
                return notReturneds;
            }
            set
            {
                notReturneds = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PublisherInfo> publisherInfos;

        public ObservableCollection<PublisherInfo> PublisherInfos
        {
            get
            {
                return publisherInfos;
            }
            set
            {
                publisherInfos = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RentedIt> rentedIts;

        public ObservableCollection<RentedIt> RentedIts
        {
            get
            {
                return rentedIts;
            }
            set
            {
                rentedIts = value;
                OnPropertyChanged();
            }
        }
        public ICommand BookReadCountCommand { get; set; }
        public ICommand HaveReadCommand { get; set; }
        public ICommand PublishedBooksCommand { get; set; }
        public ICommand DidNotReturned { get; set; }
        public ICommand RentedByCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public NonCrudWindowViewModel()
        {
            
                rest = new RestService("http://localhost:4738/", "book");
                BookReadCountCommand = new RelayCommand(() =>
                {
                   
                    BookInfos = null;
                    PublisherInfos = null;
                    NotReturneds = null;
                    RentedIts = null;
                    var BRC = rest.Get<BookReadCount>("method/BookReadCounter");
                    BookReadCounts = new ObservableCollection<BookReadCount>(BRC);
                     LabelC = "How many times each book has been read";
                });
                HaveReadCommand = new RelayCommand(() =>
                {
                    BookReadCounts = null;
                    BookInfos = null;
                    PublisherInfos = null;
                    NotReturneds = null;
                    RentedIts = null;
                    var HR = rest.Get<BookInfo>($"Method/HaveRead?id={PersonID}");
                    BookInfos = new ObservableCollection<BookInfo>(HR);
                    LabelC = $"Which books did {PersonID} read";
                });
                PublishedBooksCommand = new RelayCommand(() =>
                {
                    BookReadCounts = null;
                    BookInfos = null;
                    NotReturneds = null;
                    RentedIts = null;
                    var PB = rest.Get<PublisherInfo>("Method/PublishedBooks");
                    PublisherInfos = new ObservableCollection<PublisherInfo>(PB);
                });
                DidNotReturned = new RelayCommand(() =>
                {
                    BookReadCounts = null;
                    BookInfos = null;
                    PublisherInfos = null;
                    RentedIts = null;
                    var DR = rest.Get<NotReturned>("Method/DidNotReturned");
                    NotReturneds = new ObservableCollection<NotReturned>(DR);
                });
                RentedByCommand = new RelayCommand(() =>
                {
                    BookReadCounts = null;
                    BookInfos = null;
                    PublisherInfos = null;
                    NotReturneds = null;
                    RentedIts = null;
                    var RB = rest.Get<RentedIt>($"Method/RentedBy?id={BookID}");
                    RentedIts = new ObservableCollection<RentedIt>(RB);
                });


        }
    }
}
