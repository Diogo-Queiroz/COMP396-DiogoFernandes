using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;

namespace COMP396.Goap
{
    public class AgentTypeFactory : AgentTypeFactoryBase
    {
        public override IAgentTypeConfig Create()
        {
            var factory = new AgentTypeBuilder("COMP396-Agent");
            
            factory.AddCapability<CapabilityConfigFactory>();

            return factory.Build();
        }
    }
}