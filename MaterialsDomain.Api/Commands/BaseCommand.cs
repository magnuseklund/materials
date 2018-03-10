using System;
using CQRSlite.Commands;

namespace MaterialsDomain.Api.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public Guid Id { get; set; }

        public int ExpectedVersion { get; set;}
    }
}