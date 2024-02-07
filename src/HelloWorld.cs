using AElf.Sdk.CSharp;
using Google.Protobuf.WellKnownTypes;

namespace AElf.Contracts.HelloWorld
{
    // Contract class must inherit the base class generated from the proto file
    public class HelloWorld : HelloWorldContainer.HelloWorldBase
    {
        // adding this line is for preparing the contract deployment later, 
        // to differentiate each person's contract. 
        // This is because our testnet does not allow the deployment of two identical contracts.
        const string author = "test-devcontainer-4";
        // A method that modifies the contract state
        public override Empty Update(StringValue input)
        {
            // Set the message value in the contract state
            State.Message.Value = input.Value;
            // Emit an event to notify listeners about something happened during the execution of this method
            Context.Fire(new UpdatedMessage
            {
                Value = input.Value
            });
            return new Empty();
        }

        // A method that read the contract state
        public override StringValue Read(Empty input)
        {
            // Retrieve the value from the state
            var value = State.Message.Value;
            // Wrap the value in the return type
            return new StringValue
            {
                Value = value
            };
        }
    }
    
}
