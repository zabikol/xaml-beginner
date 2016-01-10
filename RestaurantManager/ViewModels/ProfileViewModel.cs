using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public sealed class ProfileViewModel : ViewModel
    {
        #region Members

        private readonly IMessageService _messageService;
        private int _credentialCount;
        private DateTimeOffset _hiredOn = DateTimeOffset.Now;
        private string _name;

        public int CredentialCount
        {
            get { return _credentialCount; }
            set { _credentialCount = value; NotifyPropertyChanged(); }
        }

        public DateTimeOffset HiredOn
        {
            get { return _hiredOn; }
            set { _hiredOn = value; NotifyPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged(); }
        }

        #endregion Members

        #region Commands

        public ICommand AddCredentialCommand { get; private set; }
        public ICommand SaveProfileCommand { get; private set; }

        #endregion Commands

        public ProfileViewModel(IMessageService messageService)
        {
            _messageService = messageService;
            AddCredentialCommand = new DelegateCommand<object>(AddCredential);
            SaveProfileCommand = new DelegateCommand<object>(SaveProfile);
        }

        private void AddCredential(object parameter)
        {
            CredentialCount++;
            _messageService.ShowDialog("New Credential Added");
        }

        private void SaveProfile(object parameter)
        {
            Profile profileToSave = new Profile();
            profileToSave.FullName = Name;
            profileToSave.HireDate = HiredOn.UtcDateTime;
            profileToSave.NumberOfCredentials = CredentialCount;
            //TODO DataRepository.Save(profileToSave);
        }
    }
}