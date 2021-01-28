using Caliburn.Micro;
using GestionAbsence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsence.ViewModels
{
    class LoginViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        //private IEventAggregator _events;*/
        private string _userName;
        private string _password;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;

        }

        public string PasswordInput
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => PasswordInput);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string UsernameInput
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UsernameInput);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }


        public bool CanLogin
        {
            get
            {
                bool output = false;

                if (UsernameInput?.Length > 0 && PasswordInput?.Length > 0)
                {
                    output = true;
                }

                return output;
            }

        }
        public async Task Login()
        {

            try
            {
                var result = await _apiHelper.Authenticate(UsernameInput, PasswordInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
