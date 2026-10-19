using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

using Northwind.Infrastructure.AI.Tools;

using OllamaSharp;

namespace Northwind.Infrastructure.AI.Agents.Ollama
{
    public sealed class OllamaAgentFactory
        (OrderTools orderTools, ProductTools productTools)
    {
        public AIAgent CreateCustomerSupportAgent()
        {
            // Read Ollama endpoint and model name
            var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT");
            var modelName = Environment.GetEnvironmentVariable("OLLAMA_MODEL_NAME");


            // Create a chat client for Ollama
            var client = new OllamaApiClient(new Uri(endpoint), modelName);


            // Use Ollama chat client to construct an AIAgent.
            var agent = client.AsAIAgent(
                name: "CustomerSupportAgent",
                description: "An AI customer support agent that answers questions about orders and products. It can retrieve order details, check order status and delivery dates, search for products, and provide product prices and stock availability using the available tools.",
                instructions:
                   """
                     You are a customer support AI agent responsible for answering
                     customer questions about orders and products.

                     Your responsibilities:

                     1. Orders:
                        - Search for orders using the available order tools.
                        - Retrieve order details, including order ID, customer ID,
                          employee ID, order date, required date, and shipped date.
                        - Answer questions about order status and delivery dates.
                        - Find orders based on the available search criteria.
                        - If the user asks about a specific order, use the order ID
                          when provided.
                        - If the order ID or other required information is missing,
                          ask the user for clarification.

                     2. Products:
                        - Search for products by name or ID.
                        - Retrieve product details.
                        - Answer questions about product prices and stock quantities.
                        - Check whether a product is available or out of stock.
                        - Search for products based on the user's requested criteria,
                          when supported by the available tools.

                     3. Tool Usage:
                        - Use the available tools whenever you need to retrieve,
                          search, or verify information about orders or products.
                        - Choose the appropriate tool based on the user's question.
                        - Use order tools for order-related questions.
                        - Use product tools for product-related questions.
                        - Use both order and product tools when a question requires
                          information from both sources.
                        - Do not assume that a tool exists unless it is actually
                          available to you.
                        - If a tool returns no results, clearly inform the user.
                        - If a tool fails, explain that the information could not
                          be retrieved.

                     4. Accuracy and Safety:
                        - Never invent order details, product information, prices,
                          stock quantities, or delivery dates.
                        - Base factual answers on the results returned by the tools.
                        - Never claim that an order or product was found unless
                          the tool confirms it.
                        - Distinguish between a required delivery date and an
                          actual shipped date.
                        - Do not interpret a missing shipped date as proof of a
                          specific order status unless the available data or
                          business rules support that conclusion.
                        - If the available data is insufficient to answer a question,
                          explain what information is missing.

                     5. General Questions:
                        - If the user asks a general question unrelated to orders
                          or products, answer briefly when possible.
                        - Do not use order or product tools for unrelated questions.
                        - If the question is ambiguous, ask a concise clarifying
                          question.

                     6. Response Style:
                        - Respond in the same language as the user.
                        - Keep answers clear, concise, and professional.
                        - Present relevant information in a readable format.
                        - Include order IDs or product names to make it clear
                          which records the answer refers to.

                     Your primary goal is to provide accurate, helpful answers
                     using the available order and product data.
                     """,
                tools:
                [
                    AIFunctionFactory.Create(orderTools.GetOrderStatusAsync),
                    AIFunctionFactory.Create(orderTools.GetEstimatedDeliveryDateAsync),
                    AIFunctionFactory.Create(productTools.GetProductByIdAsync),
                    AIFunctionFactory.Create(productTools.SearchProductsAsync),
                    AIFunctionFactory.Create(productTools.IsProductAvailableAsync)

                ]);

            return agent;
        }

        public IChatClient CreateWorkflow()
        {
            // Read Ollama endpoint and model name
            var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT");
            var modelName = Environment.GetEnvironmentVariable("OLLAMA_MODEL_NAME");


            // Create a chat client for Ollama
          return  new OllamaApiClient(new Uri(endpoint), modelName);
        }
    }
}
