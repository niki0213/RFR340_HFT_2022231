using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace RFR340_HFT_WpfClient
{
    internal class PublisherWindowViewModel : ObservableRecipient
    {
        public RestService<Publisher> publishers { get; set; }

        private Publisher sPublisher;

        public Publisher SPublisher
        {
            get { return sPublisher; }
            set
            {
                SetProperty(ref sPublisher, value);
                OnPropertyChanged();
                (DeletePublisherCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }



        public ICommand CreatePublisherCommand { get; set; }
        public ICommand DeletePublisherCommand { get; set; }
        public ICommand UpdatePublisherCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PublisherWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                publishers = new RestService<Publisher>("http://localhost:4738/", "publisher", "hub");

                CreatePublisherCommand = new RelayCommand(() =>
                {
                    publishers.Add(new Publisher()
                    {
                       Name = SPublisher.Name
                    });
                });

                DeletePublisherCommand = new RelayCommand(() =>
                {
                    publishers.Delete(SPublisher.PublisherID);
                },
                () =>
                {
                    return SPublisher != null;
                }
                );
                UpdatePublisherCommand = new RelayCommand(() =>
                {
                    publishers.Update(SPublisher);
                });

                SPublisher = new Publisher();
            }
        }

    }
}