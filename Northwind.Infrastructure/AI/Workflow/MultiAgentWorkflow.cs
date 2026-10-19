using Microsoft.Agents.AI.Workflows;
using Northwind.Application.AI.Agents;
using Northwind.Application.AI.Workflow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.AI.Workflow
{
    public sealed class MultiAgentWorkflow(
        IAgentFactory agentFactory) : IMultiAgentWorkflow
    {
        public Microsoft.Agents.AI.Workflows.Workflow Create()
        {
            var analystAgent = agentFactory.CreateAnalystAgent();

            var architectAgent = agentFactory.CreateArchitectAgent();

            var testingAgent = agentFactory.CreateTestingAgent();

            var developerAgent = agentFactory.CreateDeveloperAgent();

            return AgentWorkflowBuilder.BuildSequential(
                analystAgent,
                architectAgent,
                testingAgent,
                developerAgent);
        }
    }
}
