using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Proxy.Annotations;

namespace Proxy
//viewmodel
//mvvm
{
    //Think of a db entry
    //model
    public class Human 
        //: INotifyPropertyChanged, IDataErrorInfo one approach
    {
        public string FirstName, LastName;
    }

    
    
    //view = ui
    public class PersonViewModel 
        : INotifyPropertyChanged
    {
        private readonly Human _human;
        public PersonViewModel(Human human)
        {
            this._human = human;
        }

        public string FirstName
        {
            get => _human.FirstName;
            //setter is interesting
            set
            {
                if (_human.FirstName == value) return;
                _human.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get => _human.LastName;
            //setter is interesting
            set
            {
                if (_human.LastName == value) return;
                _human.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}".Trim();
            set
            {
                if (value == null)
                {
                    FirstName = LastName = null;
                    return;
                }

                var items = value.Split();
                if (items.Length > 0)
                {
                    FirstName = items[0];
                }

                if (items.Length > 1)
                {
                    LastName = items[1];
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
