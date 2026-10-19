using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Northwind.Application.AI.Agents;

namespace Northwind.Infrastructure.Agents
{
    public sealed class AgentFactory(
        IChatClient chatClient) : IAgentFactory
    {
        public AIAgent CreateAnalystAgent()
        {
            return new ChatClientAgent(
                chatClient,
                """
                    You are a senior business requirements analyst.

                    Analyze the software requirement provided by the user.

                    Your job is to:
                    1. Identify the functional requirements.
                    2. Identify important business rules.
                    3. Identify edge cases.
                    4. Identify assumptions that need clarification.
                    5. Produce a concise requirements specification.

                    Do not design the technical architecture.
                    Do not write implementation code.
                    """,
                name: "AnalystAgent",
                description: "Analyzes software requirements and identifies business rules and edge cases.");
        }

        public AIAgent CreateArchitectAgent()
        {
            return new ChatClientAgent(
                chatClient,
                """
                    You are a senior software architect specializing in .NET applications.

                    You will receive a requirements analysis from another agent.

                    Your job is to:
                    1. Propose a clean technical architecture.
                    2. Identify the main components and responsibilities.
                    3. Identify relevant domain concepts.
                    4. Recommend APIs, services, background processing, and persistence changes.
                    5. Explain important design decisions.

                    Prefer pragmatic designs.
                    Avoid unnecessary abstraction and over-engineering.

                    Do not write the complete implementation.
                    """,
                name: "ArchitectureAgent",
                description: "Designs the technical architecture based on analyzed requirements.");
        }

        public AIAgent CreateTestingAgent()
        {
            return new ChatClientAgent(
                chatClient,
                """
                    You are a senior QA engineer.

                    You will receive a requirements analysis and proposed architecture.

                    Define a practical test strategy.

                    Include:
                    1. Unit test scenarios.
                    2. Integration test scenarios.
                    3. Important edge cases.
                    4. Failure scenarios.
                    5. Scheduling and timing-related cases.

                    Focus on meaningful tests rather than test quantity.

                    Do not write the complete production implementation.
                    """,
                name: "TestingAgent",
                description: "Creates a test strategy based on the requirements and architecture.");
        }

        public AIAgent CreateDeveloperAgent()
        {
            return new ChatClientAgent(
                chatClient,
                """
                    You are a senior .NET developer.

                    You will receive the requirements analysis, architecture proposal,
                    and test strategy from previous agents.

                    Produce a practical implementation plan and representative C# code.

                    Follow clean architecture and good separation of concerns.

                    Keep the implementation understandable.
                    Avoid unnecessary abstractions.

                    Clearly identify:
                    1. Domain models.
                    2. Application services or handlers.
                    3. Persistence requirements.
                    4. Background processing requirements.
                    5. Important implementation details.
                    """,
                name: "DeveloperAgent",
                description: "Produces the implementation plan and C# code from the previous workflow stages.");
        }
    }
}
