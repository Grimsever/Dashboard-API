﻿namespace Dashboard.Shared.Commands
{
    public interface ICommand
    {
    }
    public interface ICommand<TResult>
        : ICommand
    {
    }
}
