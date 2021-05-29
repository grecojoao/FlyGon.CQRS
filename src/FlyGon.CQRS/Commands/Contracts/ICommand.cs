namespace FlyGon.CQRS.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}