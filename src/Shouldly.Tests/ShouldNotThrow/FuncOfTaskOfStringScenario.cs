﻿#if net40
using System;
using System.Threading;
using System.Threading.Tasks;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldNotThrow
{
    public class FuncOfTaskOfStringScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            var task = Task.Factory.StartNew<string>(() => { throw new RankException(); },
                CancellationToken.None, TaskCreationOptions.None,
                TaskScheduler.Default);

            task.ShouldNotThrow("Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @"task should not throw System.RankException but does
Additional Info:
Some additional context";
            }
        }

        protected override void ShouldPass()
        {
            Task<string> task = Task.Factory.StartNew(() => "Foo",
                CancellationToken.None, TaskCreationOptions.None,
                TaskScheduler.Default);

            var result = task.ShouldNotThrow();
            result.ShouldBe("Foo");
        }
    }
}
#endif