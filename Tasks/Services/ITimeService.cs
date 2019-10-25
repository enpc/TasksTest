using System;

namespace Tasks.Services
{
    public interface ITimeService
    {
        DateTime ActualTime { get; }
    }
}