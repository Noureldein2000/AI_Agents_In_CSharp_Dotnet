using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Agents.AI.Workflows;


namespace Northwind.Application.AI.Workflow
{
    public interface IMultiAgentWorkflow
    {
        Microsoft.Agents.AI.Workflows.Workflow Create();
    }
}
