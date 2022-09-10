using InjectionMoldingMachineDataAcquisitionService.Communication.Messages;
using System;



public class CommandMessage
{
    public string MachineId { get; set; }
    public DateTime Timestamp { get; set; }
    public ECommand Command { get; set; }
}

public class CommandMqttMessage
{
    public DateTime Timestamp { get; set; }
    public ECommand Command { get; set; }
}
