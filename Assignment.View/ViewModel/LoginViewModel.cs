using Assignment.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Assignment.View.Repositories;
using System.Threading;
using System.Security.Principal;
using System.Net;

namespace Assignment.View.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        //Fields
        private string _userName;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisibile = true;

        private IUserRepository userRepository;

        //Properties
        public string UserName 
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisibile
        {
            get { return _isViewVisibile; }
            set
            {
                _isViewVisibile = value;
                OnPropertyChanged(nameof(IsViewVisibile));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructors 
        public LoginViewModel()
        {
            userRepository= new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if(string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 ||
                Password == null || Password.Length < 3)
                validData= false;
            else 
                validData= true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(UserName, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UserName), null);
                IsViewVisibile = false;
            }
            else
            {
                ErrorMessage = "* Invalid Username or Password";
            }
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
