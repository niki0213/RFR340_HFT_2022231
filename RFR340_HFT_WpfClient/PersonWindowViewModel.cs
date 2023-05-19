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
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RFR340_HFT_WpfClient
{
    internal class PersonWindowViewModel : ObservableRecipient
    {
        public RestService<Person> person { get; set; }

        private Person sPerson;

        public Person SPerson
        {
            get { return sPerson; }
            set
            {
                SetProperty(ref sPerson, value);
                OnPropertyChanged();
                (DeletePersonCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }



        public ICommand CreatePersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand UpdatePersonCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public PersonWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                person = new RestService<Person>("http://localhost:4738/", "person", "hub");

                CreatePersonCommand = new RelayCommand(() =>
                {
                    person.Add(new Person()
                    {
                        Name= SPerson.Name,
                        Phone= SPerson.Phone
                    });
                });

                DeletePersonCommand = new RelayCommand(() =>
                {
                    person.Delete(SPerson.PersonID);
                },
                () =>
                {
                    return SPerson != null;
                }
                );
                UpdatePersonCommand = new RelayCommand(() =>
                {
                    person.Update(SPerson);
                });

                SPerson = new Person();
            }
        }

    }
}