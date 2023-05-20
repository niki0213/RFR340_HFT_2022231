using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_WpfClient
{
    internal class RentWindowViewModel : ObservableRecipient
    {
        public RestService<Rent> rents { get; set; }

        private Rent sRent;

        public Rent SRent
        {
            get { return sRent; }
            set
            {
                SetProperty(ref sRent, value);
                OnPropertyChanged();
                (DeleteRentCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }



        public ICommand CreateRentCommand { get; set; }
        public ICommand DeleteRentCommand { get; set; }
        public ICommand UpdateRentCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RentWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                rents = new RestService<Rent>("http://localhost:4738/", "rent", "hub");

                CreateRentCommand = new RelayCommand(() =>
                {
                    rents.Add(new Rent()
                    {
                        BookID = SRent.BookID,
                        PersonID= SRent.PersonID,
                        Back=SRent.Back,

                    });
                });

                DeleteRentCommand = new RelayCommand(() =>
                {
                    rents.Delete(SRent.RentID);
                },
                () =>
                {
                    return SRent != null;
                }
                );
                UpdateRentCommand = new RelayCommand(() =>
                {
                    rents.Update(SRent);
                });

                SRent = new Rent();
            }
        }

    }
}