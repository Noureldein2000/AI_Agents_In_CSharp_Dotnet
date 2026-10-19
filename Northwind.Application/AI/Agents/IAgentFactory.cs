using Microsoft.Agents.AI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.AI.Agents
{
    public interface IAgentFactory
    {
        AIAgent CreateAnalystAgent();

        AIAgent CreateArchitectAgent();

        AIAgent CreateTestingAgent();

        AIAgent CreateDeveloperAgent();
    }
}
