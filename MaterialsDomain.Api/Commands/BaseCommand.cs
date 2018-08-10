using System;
using CQRSlite.Commands;

namespace MaterialsDomain.Api.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public Guid Id { get; }

        public int ExpectedVersion { get; set; }

        public BaseCommand(Guid id)
        {
            Id = id;
        }
    }
}