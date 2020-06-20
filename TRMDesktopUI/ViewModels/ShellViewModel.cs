using Caliburn.Micro;
using System.Windows.Navigation;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>
    {
        private SalesViewModel _salesVM;
        private readonly ILoggedInUserModel _loggedInUserModel;
        private readonly IAPIHelper _apiHelper;
        private IEventAggregator _events;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel loggedInUserModel, IAPIHelper apiHelper)
        {
            _events = events;

            _salesVM = salesVM;
            _loggedInUserModel = loggedInUserModel;
            _apiHelper = apiHelper;
            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_loggedInUserModel.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void UserManagement()
        {
            ActivateItem(IoC.Get<UserDisplayViewModel>());
        }

        public void LogOut()
        {
            _loggedInUserModel.ResetUserModel();
            _apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}