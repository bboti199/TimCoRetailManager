using Caliburn.Micro;
using TRMDesktopUI.EventModels;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>
    {
        private SalesViewModel _salesVM;
        private IEventAggregator _events;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;

            _salesVM = salesVM;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEventModel message)
        {
            ActivateItem(_salesVM);
        }
    }
}