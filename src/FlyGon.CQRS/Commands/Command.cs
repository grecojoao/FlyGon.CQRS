using FlyGon.CQRS.Commands.Contracts;
using FlyGon.Notifications;

namespace FlyGon.CQRS.Commands
{
    public abstract class Command : Notifiable, ICommand
    {
        public abstract void Validate();
    }
}