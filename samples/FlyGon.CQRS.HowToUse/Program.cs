using FlyGon.CQRS.Commands;
using FlyGon.CQRS.Handlers.Contracts;
using FlyGon.Notifications;
using FlyGon.Notifications.Validations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlyGon.CQRS.HowToUse
{
    class SumCommand : Command
    {
        public decimal? ValueOne { get; set; }
        public decimal? ValueTwo { get; set; }

        public SumCommand() { }

        public SumCommand(decimal? valueOne, decimal? valueTwo)
        {
            ValueOne = valueOne;
            ValueTwo = valueTwo;
        }

        public override void Validate()
        {
            AddNotifications(
                new ValidationContract()
                .IsNotNull(ValueOne, "ValueOne", "Invalid value")
                .IsNotNull(ValueTwo, "ValueTwo", "Invalid value"));
        }
    }

    class CalculatorHandler : ICommandHandler<SumCommand, CommandResult>
    {
        public Task<CommandResult> Handle(SumCommand command, CancellationToken cancellationToken = default)
        {
            command.Validate();
            if (command.IsInvalid)
                return Task.FromResult(new CommandResult(false, command.NotificationsMessage(), command.Notifications));

            var calculatedValue = Calculator.Sum((decimal)command.ValueOne, (decimal)command.ValueTwo);
            return Task.FromResult(new CommandResult(true, "Calculation done", calculatedValue));
        }
    }

    class Calculator
    {
        public static decimal Sum(decimal valueOne, decimal valueTwo) =>
            valueOne + valueTwo;
    }

    static class Program
    {
        static void Main()
        {
            var handler = new CalculatorHandler();
            var command = new SumCommand(10, 10);
            var commandResult = handler.Handle(command).Result;
            Console.WriteLine($"Command Result - " +
                $"Sucess: { commandResult.Sucess}, " +
                $"Message: {commandResult.Message}, " +
                $"Calculed value: {(decimal)commandResult.Data}");

            handler = new CalculatorHandler();
            command = new SumCommand(null, null);
            commandResult = handler.Handle(command).Result;
            Console.WriteLine($"Command Result - " +
                $"Sucess: { commandResult.Sucess}, " +
                $"Notifications: {((IReadOnlyCollection<Notification>)commandResult.Data).Count}, " +
                $"Message: {commandResult.Message}");
        }
    }
}